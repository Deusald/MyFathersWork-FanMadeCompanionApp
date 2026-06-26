#if UNITY_EDITOR
#define CHECK_ERRORS //used to check text errors 
#endif

#if TA_Naninovel
#define INTEGRATE_NANINOVEL
#endif

using Febucci.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace Febucci.UI
{
    /// <summary>
    /// The main TextAnimator component. Add this near to a TextMeshPro component in order to enable effects. It can also be used in combination with a TextAnimatorPlayer in order to display letters dynamically (like a typewriter).<br/>
    /// - See also: <seealso cref="TextAnimatorPlayer"/><br/>
    /// - Manual: <see href="https://www.textanimator.febucci.com/docs/how-to-add-effects-to-your-texts/">How to add effects to your texts</see><br/>
    /// </summary>
    [HelpURL("https://www.textanimator.febucci.com/docs/how-to-add-effects-to-your-texts/")]
    [AddComponentMenu("Febucci/TextAnimator/TextAnimator")]
    [RequireComponent(typeof(TMP_Text)), DisallowMultipleComponent]
    public class TextAnimator : MonoBehaviour
    {

        #region Types (Structs + Enums)

        /// <summary>
        /// Contains TextAnimator's current time values.
        /// </summary>
        [System.Serializable]
        public struct TimeData
        {
            /// <summary>
            /// Time passed since the textAnimator started showing the very first letter
            /// </summary>
            public float timeSinceStart { get; private set; }

            /// <summary>
            /// TextAnimator's Component delta time, could be Scaled or Unscaled
            /// </summary>
            public float deltaTime { get; private set; }

            internal void ResetData()
            {
                timeSinceStart = 0;
            }

            internal void IncreaseTime()
            {
                timeSinceStart += deltaTime;
            }

            internal void UpdateDeltaTime(TimeScale timeScale)
            {
                deltaTime = timeScale == TimeScale.Unscaled ? Time.unscaledDeltaTime : Time.deltaTime;

                //To avoid possible desync errors etc., effects can't be played backwards. 
                if (deltaTime < 0)
                    deltaTime = 0;
            }
        }

        [System.Serializable]
        class AppearancesContainer
        {
            [SerializeField]
            public string[] tags = new string[] { TAnimTags.ap_Size };  //starts with a size effect by default

            public AppearanceDefaultValues values = new AppearanceDefaultValues();
        }

        internal struct InternalAction
        {
            public TypewriterAction action;

            public int charIndex;
            public bool triggered;
            public int internalOrder;
        }


        enum ShowTextMode : byte
        {
            Hidden = 0,
            Shown = 1,
            UserTyping = 2
        }

        /// <summary>
        /// TextAnimator's effects time scale, which could match unity's Time.deltaTime or Time.unscaledDeltaTime
        /// </summary>
        public enum TimeScale
        {
            Scaled,
            Unscaled,
        }

        #endregion

        private void Awake()
        {
            Canvas[] canvases = new Canvas[0];
            canvases = gameObject.GetComponentsInParent<Canvas>(true);

            //-----
            //TMPro UI references a canvas, but if it's null [in its case, the object is inactive] it doesn't generate the mesh and it throws error(s).
            //These variables manages a canvas also if its' disabled.
            //-----

            if (canvases.Length > 0)
            {
                parentCanvas = canvases[0];
                hasParentCanvas = parentCanvas != null;
            }

#if INTEGRATE_NANINOVEL
            reveablelText = GetComponent<Naninovel.UI.IRevealableText>();
            isNaninovelPresent = reveablelText != null;
#endif

            //If we're checking text from TMPro, prevents its very first set text to appear for one frame and then disappear
            if (triggerAnimPlayerOnChange)
            {
                tmproText.renderMode = TextRenderFlags.DontRender;
            }

            m_time.UpdateDeltaTime(timeScale);
        }

        #region Variables

        TAnimPlayerBase _tAnimPlayer;
        /// <summary>
        /// Linked TAnimPlayer to this component
        /// </summary>
        TAnimPlayerBase tAnimPlayer
        {
            get
            {
                if (_tAnimPlayer != null)
                    return _tAnimPlayer;

#if UNITY_2019_2_OR_NEWER
                if (!TryGetComponent(out _tAnimPlayer))
                {
                    Debug.LogError($"Text Animator component is null on GameObject {gameObject.name}");
                }
#else
                _tAnimPlayer = GetComponent<TAnimPlayerBase>();
                Assert.IsNotNull(_tAnimPlayer, $"Text Animator Player component is null on GameObject {gameObject.name}");
#endif

                return _tAnimPlayer;
            }
        }

        #region Inspector

        [SerializeField, Tooltip("If true, the typewriter is triggered automatically once the TMPro text changes (requires a TextAnimatorPlayer component). Otherwise, it shows the entire text instantly.")]
        bool triggerAnimPlayerOnChange = false;

        [SerializeField]
        float effectIntensityMultiplier = 50;

        [UnityEngine.Serialization.FormerlySerializedAs("defaultAppearance"), SerializeField, Header("Text Appearance")]
        AppearancesContainer appearancesContainer = new AppearancesContainer();

        [SerializeField] string[] tags_fallbackBehaviors = new string[0];
        [SerializeField] BehaviorDefaultValues behaviorValues = new BehaviorDefaultValues();

        //Global effect values
#pragma warning disable 0649
        [SerializeField] BuiltinBehaviorsDataScriptable scriptable_globalBehaviorsValues;
        [SerializeField] BuiltinAppearancesDataScriptable scriptable_globalAppearancesValues;
#pragma warning restore 0649

        [SerializeField, Tooltip("True if you want effects to have the same intensities even if text is larger/smaller than default (example: when TMPro's AutoSize changes the size based on screen size)")]
        bool useDynamicScaling = false;
        [SerializeField, Tooltip("Used for scaling, represents the text's size where/when effects intensity behave like intended.")]
        float referenceFontSize = -1;

        #endregion

        #region Public Variables

        TMP_Text _tmproText;

        /// <summary>
        /// The TextMeshPro component linked to this TextAnimator
        /// </summary>
        public TMP_Text tmproText
        {
            get
            {
                if (_tmproText != null)
                    return _tmproText;

#if UNITY_2019_2_OR_NEWER
                if (!TryGetComponent(out _tmproText))
                {
                    Debug.LogError("TextAnimator: TMproText component is null.");
                }
#else
                _tmproText = GetComponent<TMP_Text>();
                Assert.IsNotNull(tmproText, $"TextMeshPro component is null on Object {gameObject.name}");
#endif

                return _tmproText;
            }

            private set
            {
                _tmproText = value;
            }
        }

        #region Time

        /// <summary>
        /// Effects timescale, you can set it to scaled or unscaled.
        /// It also affects the TextAnimatorPlayer, if there is one linked to this TextAnimator.
        /// </summary>
        public TimeScale timeScale = TimeScale.Scaled;

        [Obsolete("This value will be removed from the next versions. Please use 'time.deltaTime' instead")]
        public float deltaTime => m_time.deltaTime;
        #endregion

        #region Events
        /// <summary>
        /// Delegate used for TextAnimator's events. Listeners can subscribe to: <see cref="onEvent"/>. <br/>
        /// - Manual: <see href="https://www.textanimator.febucci.com/docs/triggering-events-while-typing/">Triggering Events while typing</see>
        /// </summary>
        /// <param name="message"></param>
        public delegate void MessageEvent(string message);

        /// <summary>
        /// Invoked by the typewriter once it reaches a message tag while showing letters.<br/>
        /// - Manual: <see href="https://www.textanimator.febucci.com/docs/triggering-events-while-typing/">Triggering Events while typing</see>
        /// </summary>
        public event MessageEvent onEvent;
        #endregion

        string latestText;
        /// <summary>
        /// The text stored in the TextAnimator component, without TextAnimator's tags.
        /// </summary>
        public string text { get => latestText; private set => latestText = value; }

        /// <summary>
        /// <c>true</c> if the text is entirely visible.
        /// </summary>
        /// <remarks>
        /// You can use this to check if all the letters have been shown.
        /// </remarks>
        public bool allLettersShown => visibleCharacters >= tmproText.textInfo.characterCount;

        /// <summary>
        /// The latest TextMeshPro character shown by the typewriter.
        /// </summary>
        public TMP_CharacterInfo latestCharacterShown { get; private set; }

        #endregion

        #region Managament variables

        /// <summary>
        /// Contains TextAnimator's current time values.
        /// </summary>
        public TimeData time => m_time;
        TimeData m_time;

#if INTEGRATE_NANINOVEL //Naninovel integration
        bool isNaninovelPresent;
        Naninovel.UI.IRevealableText reveablelText;
#endif

        bool forceMeshRefresh;
        bool skipAppearanceEffects;

        //----- TMPro workaround -----
        bool hasParentCanvas;
        Canvas parentCanvas;
        //-----

        //----- TMPro values cache -----
        bool autoSize;
        Rect sourceRect;
        Color sourceColor;
        //-----
        int visibleCharacters = 0;

        bool hasText = false;
        internal bool hasActions { get; private set; }


        int latestTriggeredEvent = 0;
        int latestTriggeredAction = 0;

        #endregion

        #region Text Elements

        TMP_TextInfo textInfo;

        Character[] characters = new Character[0];


        List<BehaviorBase> behaviorEffects = new List<BehaviorBase>();
        List<AppearanceBase> appearanceEffects = new List<AppearanceBase>();
        AppearanceBase[] fallbackAppearanceEffects;
        BehaviorBase[] fallbackBehaviorEffects;

        List<InternalAction> typewriterActions = new List<InternalAction>();
        List<EventMarker> eventMarkers = new List<EventMarker>();

        #endregion

        #endregion

        #region Public Component Methods

        #region For setting the Text
        /// <summary>
        /// Method to set the TextAnimator's text and apply its tags (effects/actions/tmpro/...).
        /// </summary>
        /// <param name="text">Source text, including rich text tags</param>
        /// <param name="hideText"><c>true</c> = sets the text but hides it (visible characters = 0). Mostly used to let the typewriter show letters after setting the text</param>
        public void SetText(string text, bool hideText)
        {
            _SetText(text, hideText ? ShowTextMode.Hidden : ShowTextMode.Shown);
        }

        /// <summary>
        /// Appends the given text to the already existing TMPro's one, applying its tags etc.
        /// </summary>
        /// <param name="text">Text to append, including rich text tags</param>
        /// <param name="hideText"><c>true</c> = appends the text but hides it. Mostly used to let the typewriter show the remaining letters.</param>
        public void AppendText(string text, bool hideText)
        {
            //Prevents appending an empty text
            if (string.IsNullOrEmpty(text))
                return;

            //The user is appending to an empty text
            //so we set it instead
            if (!hasText)
            {
                SetText(text, hideText);
                return;
            }

            _ApplyTextToCharacters(this.text + _FormatText(text, textInfo.characterCount));
        }
        #endregion

        #region For the typewriter
        /// <summary>
        /// Tries to return the next character in the text.
        /// </summary>
        /// <example>
        /// <code>
        /// if (textAnimatorComponent.TryGetNextCharacter(out TMP_CharacterInfo nextChar))
        /// {
        ///     ///[...]
        /// }
        /// </code>
        /// </example>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryGetNextCharacter(out TMP_CharacterInfo result)
        {
            if (visibleCharacters < textInfo.characterCount)
            {
                result = textInfo.characterInfo[visibleCharacters];
                return true;
            }

            result = default;
            return false;
        }

        /// <summary>
        /// Increases the visible characters count in the text.
        /// It also triggers events (if any)
        /// </summary>
        /// <returns>Returns the latest shown character</returns>
        public char IncreaseVisibleChars()
        {
            if (!hasText)
            {
                Debug.LogWarning("Text Animator: can't increase visible letters count yet because the text has not been set.");
                return ' ';
            }

            if (visibleCharacters > textInfo.characterCount || visibleCharacters < 0)
                return ' ';

            latestCharacterShown = textInfo.characterInfo[visibleCharacters];

            for (int i = 0; i < textInfo.characterCount; i++)
            {
                if (i >= visibleCharacters || !textInfo.characterInfo[i].isVisible)
                {
                    characters[i].data.passedTime = 0;
                }
            }

            TryTriggeringEvent(int.MaxValue); //Invokes all events that are after the current letter (but on the same TMPro index)

            visibleCharacters++;

            if (textInfo.characterInfo[visibleCharacters - 1].isVisible)
            { //might be a space or sprite

                return textInfo.characterInfo[visibleCharacters - 1].character;
            }

            return ' ';
        }

        /// <summary>
        /// Turns all characters visible at the end of the frame (i.e. "a typewriter skip")
        /// </summary>
        /// <param name="skipAppearanceEffects">Set this to true if you want all letters to appear instantly (without any appearance effect)</param>
        public void ShowAllCharacters(bool skipAppearanceEffects)
        {
            visibleCharacters = textInfo.characterCount;
            this.skipAppearanceEffects = skipAppearanceEffects;
        }

        /// <summary>
        /// Triggers all the remaining TextAnimator's events.
        /// </summary>
        public void TriggerRemainingEvents()
        {
            if (eventMarkers.Count <= 0)
                return;

            for (int i = latestTriggeredEvent; i < eventMarkers.Count; i++)
            {
                if (!eventMarkers[i].triggered)
                {
                    var _event = eventMarkers[i];
                    _event.triggered = true;
                    onEvent?.Invoke(eventMarkers[i].eventMessage);
                }
            }

            latestTriggeredEvent = eventMarkers.Count - 1;
        }
        #endregion

        /// <summary>
        /// Forces refreshing the mesh at the end of the frame
        /// </summary>
        public void ForceMeshRefresh()
        {
            forceMeshRefresh = true;
        }

        #region Obsolete

        [Obsolete("Please use the method 'SetText' instead. This method is obsolete and will be removed from the next versions.")]
        public void SyncText(string text, bool hideText)
        {
            SetText(text, hideText);
        }
        #endregion

        #endregion

        #region Public Static Methods

        /// <summary>
        /// <c>true</c> if behavior effects are enabled globally (in all TextAnimators).
        /// </summary>
        /// <remarks>
        /// To modify this value, invoke: <see cref="EnableBehaviors(bool)"/>
        /// </remarks>
        public static bool effectsBehaviorsEnabled => enabled_globalBehaviors;

        /// <summary>
        /// <c>true</c> if appearance effects are enabled globally (in all TextAnimators).
        /// </summary>
        /// <remarks>
        /// To modify this value, invoke: <see cref="EnableAppearances(bool)(bool)"/>
        /// </remarks>
        public static bool effectsAppearancesEnabled => enabled_globalAppearances;

        static bool enabled_globalAppearances = true;
        static bool enabled_globalBehaviors = true;

        /// <summary>
        /// Enables/Disables all effects for all TextAnimators.
        /// </summary>
        public static void EnableAllEffects(bool enabled)
        {
            EnableAppearances(enabled);
            EnableBehaviors(enabled);
        }

        /// <summary>
        /// Enables/Disables Appearances effects globally (for all TextAnimators)
        /// </summary>
        /// <param name="enabled"></param>
        /// /// <remarks>To check if behaviors are enabled, refer to <see cref="effectsAppearancesEnabled"/></remarks>
        public static void EnableAppearances(bool enabled)
        {
            enabled_globalAppearances = enabled;
        }

        /// <summary>
        /// Enables/Disables Behavior effects globally (for all TextAnimators)
        /// </summary>
        /// <param name="enabled"></param>
        /// <remarks>To check if behaviors are enabled, refer to <see cref="effectsBehaviorsEnabled"/></remarks>
        public static void EnableBehaviors(bool enabled)
        {
            enabled_globalBehaviors = enabled;
        }


        bool enabled_localBehaviors = true;
        bool enabled_localAppearances = true;


        /// <summary>
        /// Enables/disables Behavior effects for this specific TextAnimator component.
        /// </summary>
        /// <remarks>
        /// To disable effects on all TextAnimators, please see <see cref="EnableAppearances(bool)(bool)"></see>
        /// </remarks>
        /// <param name="value"></param>
        public void EnableBehaviorsLocally(bool value)
        {
            enabled_localBehaviors = value;
        }

        /// <summary>
        /// Enables/disables Appearance effects for this specific TextAnimator component.
        /// </summary>
        /// <remarks>
        /// To disable effects on all TextAnimators, please see <see cref="EnableAppearances(bool)(bool)"></see>
        /// </remarks>
        /// <param name="value"></param>
        public void EnableAppearancesLocally(bool value)
        {
            enabled_localAppearances = value;
        }

        #endregion

        #region Effects Database
        bool databaseBuilt = false;
        Dictionary<string, Type> localBehaviors = new Dictionary<string, Type>();
        Dictionary<string, Type> localAppearances = new Dictionary<string, Type>();

        void BuildTagsDatabase()
        {

            if (databaseBuilt)
                return;

            TAnimBuilder.InitializeGlobalDatabase();

            databaseBuilt = true;

            #region Global built-in effects values

            //replaces local appearances data with global scriptable data
            if (scriptable_globalAppearancesValues)
            {
                appearancesContainer.values.defaults = scriptable_globalAppearancesValues.effectValues;
            }

            //replaces local behavior data with global scriptable data
            if (scriptable_globalBehaviorsValues)
            {
                behaviorValues.defaults = scriptable_globalBehaviorsValues.effectValues;
            }
            #endregion

            //adds local behavior presets
            for (int i = 0; i < behaviorValues.presets.Length; i++)
            {
                TAnimBuilder.TryAddingPresetToDictionary(ref localBehaviors, behaviorValues.presets[i].effectTag, typeof(PresetBehavior));
            }

            //Adds local appearance presets
            for (int i = 0; i < appearancesContainer.values.presets.Length; i++)
            {
                TAnimBuilder.TryAddingPresetToDictionary(ref localAppearances, appearancesContainer.values.presets[i].effectTag, typeof(PresetAppearance));
            }


            #region Fallback appearing effects

            //TODO make a generic method for both

            var temp_fallbackAppearanceEffects = new List<AppearanceBase>();
            //Default appearance effects
            for (int i = 0; i < appearancesContainer.tags.Length; i++)
            {
                if (appearancesContainer.tags[i].Length <= 0)
                {
                    continue;
                }

                //effect has already been added
                if (temp_fallbackAppearanceEffects.GetIndexOfEffect(appearancesContainer.tags[i]) >= 0)
                {
                    continue;
                }

                if (TryGetAppearingClassFromTag(appearancesContainer.tags[i], appearancesContainer.tags[i], 0, out AppearanceBase effectBase))
                {
                    effectBase.regionManager.AddRegion(0);
                    temp_fallbackAppearanceEffects.Add(effectBase);
                }
                else
                {
                    Debug.LogError($"TextAnimator: Appearance Tag '{appearancesContainer.tags[i]}' is not recognized.", this.gameObject);
                }
            }

            this.fallbackAppearanceEffects = temp_fallbackAppearanceEffects.ToArray();


            var temp_fallbackBehaviorEffects = new List<BehaviorBase>();
            //Default behavior effects
            for (int i = 0; i < tags_fallbackBehaviors.Length; i++)
            {
                if (tags_fallbackBehaviors[i].Length <= 0)
                {
                    continue;
                }

                //effect has already been added
                if (temp_fallbackBehaviorEffects.GetIndexOfEffect(tags_fallbackBehaviors[i]) >= 0)
                {
                    continue;
                }

                if (TryGetBehaviorClassFromTag(tags_fallbackBehaviors[i], tags_fallbackBehaviors[i], 0, out BehaviorBase effectBase))
                {
                    effectBase.regionManager.AddRegion(0);
                    temp_fallbackBehaviorEffects.Add(effectBase);
                }
                else
                {
                    Debug.LogError($"TextAnimator: Behavior Tag '{tags_fallbackBehaviors[i]}' is not recognized.", this.gameObject);
                }
            }

            this.fallbackBehaviorEffects = temp_fallbackBehaviorEffects.ToArray();

            #endregion


        }
        #endregion

        #region Effects Creation/Instancing

        bool TryGetBehaviorClassFromTag(string tag, string entireRichTextTag, int regionStartIndex, out BehaviorBase effectBase)
        {
            //Global Tags
            if (TAnimBuilder.TryGetGlobalBehaviorFromTag(tag, entireRichTextTag, out effectBase))
            {
                effectBase.SetDefaultValues(behaviorValues); //<-- add this
                effectBase.regionManager.AddRegion(regionStartIndex);
                return true;
            }

            //Local tags
            if (TAnimBuilder.TryGetEffectClassFromTag(localBehaviors, tag, entireRichTextTag, out effectBase))
            {
                effectBase.SetDefaultValues(behaviorValues); //<-- add this
                effectBase.regionManager.AddRegion(regionStartIndex);
                return true;
            }

            effectBase = default;
            return false;

        }

        bool TryGetAppearingClassFromTag(string tag, string entireRichTextTag, int startIndex, out AppearanceBase effectBase)
        {
            //Global Tags
            if (TAnimBuilder.TryGetGlobalAppearanceFromTag(tag, entireRichTextTag, out effectBase))
            {
                effectBase.regionManager.AddRegion(startIndex);
                return true;
            }

            //Local tags
            if (TAnimBuilder.TryGetEffectClassFromTag(localAppearances, tag, entireRichTextTag, out effectBase))
            {
                effectBase.regionManager.AddRegion(startIndex);
                return true;
            }

            effectBase = default;
            return false;
        }

        #endregion

        #region Management Methods

        #region Tags Processing
        const char m_closureSymbol = '/';
        const char m_eventSymbol = '?';

        bool TryProcessingAppearanceTag(string richTextTag, int realTextIndex)
        {
            //Closure tag, eg. '/'
            if (richTextTag[0] == m_closureSymbol)
            {
                #region Tries closing effect
                return appearanceEffects.CloseSingleOrAllEffects(richTextTag.Substring(1, richTextTag.Length - 1), realTextIndex);
                #endregion
            }
            else
            {
                //Avoids creating a new class if the same effect has already been instanced
                for (int i = 0; i < appearanceEffects.Count; i++)
                {
                    if (appearanceEffects[i].regionManager.TryReutilizingWithTag(richTextTag, realTextIndex))
                        return true;
                }

                #region Tries adding effect
                if (TryGetAppearingClassFromTag(richTextTag, richTextTag, realTextIndex, out AppearanceBase effectBase))
                {
                    effectBase.SetDefaultValues(appearancesContainer.values);
                    appearanceEffects.TryAddingNewRegion(effectBase);

                    return true;
                }
                #endregion
                return false;
            }
        }

        bool TryProcessingBehaviorTag(string richTextTag, int realTextIndex, ref int internalEventActionIndex)
        {
            if (richTextTag[0] == m_eventSymbol)
            {
                richTextTag = richTextTag.Substring(1, richTextTag.Length - 1);

                #region Tries firing event

                if (richTextTag.Length == 0) //prevents from adding an empty callback
                    return false;

                eventMarkers.Add(new EventMarker
                {
                    charIndex = realTextIndex,
                    eventMessage = richTextTag,
                    internalOrder = internalEventActionIndex,
                });

                internalEventActionIndex++; //increases internal events and features order
                return true;

                #endregion
            }
            else if (richTextTag[0] == m_closureSymbol)
            {
                richTextTag = richTextTag.Substring(1, richTextTag.Length - 1);

                #region Tries closing effect

                bool closedRegion = false;

                //Closes all the regions
                if (richTextTag.Length <= 1) //tag is </>
                {
                    //Closes ALL the region opened until now
                    for (int k = 0; k < behaviorEffects.Count; k++)
                    {
                        closedRegion = behaviorEffects.CloseElement(k, realTextIndex);
                    }
                }
                //Closes the current region
                else
                {
                    closedRegion = behaviorEffects.CloseRegionNamed(richTextTag, realTextIndex);
                }

                return closedRegion;

                #endregion
            }
            else
            {
                #region Tries adding effect

                //All the tags inside the "< >" region (without the opening and ending chars, '<' and '>') separated by a space
                string[] tags = richTextTag.Split(' ');

                string firstTag = tags[0];

                //Avoids creating a new effect if the same one has already been instanced
                for (int i = 0; i < behaviorEffects.Count; i++)
                {
                    if (behaviorEffects[i].regionManager.TryReutilizingWithTag(richTextTag, realTextIndex))
                        return true;
                }

                //Creates a behavior effect
                if (TryGetBehaviorClassFromTag(firstTag, richTextTag, realTextIndex, out BehaviorBase behaviorEffect))
                {
                    behaviorEffect.SetDefaultValues(behaviorValues);

                    #region Sets Modifiers
                    //Searches for modifiers inside the < > region (after the first tag, which we used to check the type of effect to add)
                    for (int tagIndex = 1; tagIndex < tags.Length; tagIndex++)
                    {
                        int equalsIndex = tags[tagIndex].IndexOf('=');

                        //we've found an "=" symbol, so we're setting the modifier
                        if (equalsIndex >= 0)
                        {
                            //modifier name, from start to the equals symbol
                            string modifierName = tags[tagIndex].Substring(0, equalsIndex);

                            //Numeric value of the modifier (the part after the equal symbol)
                            string modifierValueName = tags[tagIndex].Substring(equalsIndex + 1);
                            //modifierValueName = modifierValueName.Replace('.', ','); //replaces dots with commas

                            behaviorEffect.SetModifier(modifierName, modifierValueName);

#if UNITY_EDITOR
                            behaviorEffect.EDITOR_RecordModifier(modifierName, modifierValueName);
#endif

                        }
                    }
                    #endregion

                    behaviorEffects.TryAddingNewRegion(behaviorEffect);
                    return true;
                }

                //No effect found
                return false;

                #endregion
            }

        }

        bool TryProcessingActionTag(string entireTag, int realTextIndex, ref int internalEventActionIndex)
        {
            //First part of the tag, "<ciao>" becomes "ciao"
            string firstPartTag = entireTag.Substring(1, entireTag.Length - 2);


            //Trims from the equal symbol. If it's "<ciao=3>" it becomes "ciao"
            int trimmeredIndex = entireTag.IndexOf('=');
            if (trimmeredIndex >= 0)
            {
                firstPartTag = firstPartTag.Substring(0, trimmeredIndex - 1);
            }

            //Checks if the tag is a recognized action
            if (TAnimBuilder.IsDefaultAction(firstPartTag) || TAnimBuilder.IsCustomAction(firstPartTag))
            {
                hasActions = true;

                InternalAction m_action = default;
                m_action.action = new TypewriterAction();

                m_action.action.actionID = firstPartTag;
                m_action.charIndex = realTextIndex;
                m_action.action.parameters = new List<string>();

                //the tag has also a part after the equal
                if (trimmeredIndex >= 0)
                {
                    //creates its parameters

                    string finalPartTag = entireTag.Substring(firstPartTag.Length + 2);

                    finalPartTag = finalPartTag
                        .Substring(0, finalPartTag.Length - 1);

                    //Splits parameters
                    m_action.action.parameters = finalPartTag.Split(',').ToList();
                }

                m_action.internalOrder = internalEventActionIndex;
                typewriterActions.Add(m_action);
                internalEventActionIndex++;

                return true;
            }

            return false;

        }

        #endregion

        bool noparseEnabled = false;
        int internalEventActionIndex = 0;

        List<int> temp_effectsToApply = new List<int>(); //temporary


        void _SetText(string text, ShowTextMode showTextMode)
        {
            //Prevents to calculate everything for an empty text
            if (text.Length <= 0)
            {
                hasText = false;
                text = string.Empty;
                tmproText.text = string.Empty;
                tmproText.ClearMesh();
                return;
            }

            BuildTagsDatabase();

            #region Resets text variables

            skipAppearanceEffects = false;
            hasActions = false;
            noparseEnabled = false;
            m_time.ResetData(); //resets time

            behaviorEffects.Clear();
            appearanceEffects.Clear();
            eventMarkers.Clear();
            typewriterActions.Clear();
            latestTriggeredEvent = 0;
            latestTriggeredAction = 0;
            internalEventActionIndex = 0;

            #endregion

            #region Adds Fallback Effects

            //fallback effects are added at the end of the list
            for (int i = 0; i < fallbackAppearanceEffects.Length; i++)
            {
                appearanceEffects.Add(fallbackAppearanceEffects[i]);
            }

            //fallback effects are added at the end of the list
            for (int i = 0; i < fallbackBehaviorEffects.Length; i++)
            {
                behaviorEffects.Add(fallbackBehaviorEffects[i]);
            }

            #endregion

            _ApplyTextToCharacters(_FormatText(text, 0));

            //--------
            //Decides how many characters to show
            //--------

            void HideAllCharacters()
            {
                visibleCharacters = 0;

                for (int i = 0; i < textInfo.characterCount; i++)
                {
                    if (i >= visibleCharacters)
                    {
                        characters[i].data.passedTime = 0;
                    }
                }

                if (visibleCharacters <= 0 && characters.Length > 0)
                {
                    characters[0].data.passedTime = 0;
                }

            }

            void ShowAllCharacters()
            {
                visibleCharacters = textInfo.characterCount;

                //resets letters time
                for (int i = 0; i < textInfo.characterCount; i++)
                {
                    characters[i].data.passedTime = 0;
                }
            }

            switch (showTextMode)
            {
                case ShowTextMode.Hidden:
                    HideAllCharacters();
                    break;
                case ShowTextMode.Shown:
                    ShowAllCharacters();
                    break;
                case ShowTextMode.UserTyping:
                    visibleCharacters = textInfo.characterCount;

#if INTEGRATE_NANINOVEL
                    //Hides characters based on naninovel's progress 
                    for (int i = 0; i < characters.Length; i++)
                    {
                        if (i >= Mathf.CeilToInt(Mathf.Clamp01(reveablelText.RevealProgress) * textInfo.characterCount))
                        {
                            characters[i].data.passedTime = 0;
                        }
                    }
#endif

                    if (visibleCharacters - 1 < characters.Length && visibleCharacters - 1 >= 0)
                        characters[visibleCharacters - 1].data.passedTime = 0; //user is typing, the latest letter has time reset
                    break;
            }
        }


        private string _FormatText(string text, int startCharacterIndex)
        {
            System.Text.StringBuilder temp_realText = new System.Text.StringBuilder();

#if CHECK_ERRORS
            EDITOR_CompatibilityCheck(text);
#endif

            temp_realText.Clear();

            //Temporary variables
            string entireTag;
            string entireLoweredTag;
            string richTextTag;

            int indexOfClosing;
            int indexOfNextOpening;

            for (int i = 0, realTextIndex = startCharacterIndex; i < text.Length; i++)
            {
                #region Local Methods
                void AppendCurrentCharacterToText()
                {
                    temp_realText.Append(text[i]);
                    realTextIndex++;
                }

                bool TryGetClosingCharacter(out char _closingCharacter)
                {
                    if (text[i] == TAnimBuilder.tag_behaviors.charOpeningTag)
                    {
                        _closingCharacter = TAnimBuilder.tag_behaviors.charClosingTag;
                        return true;
                    }
                    else if (text[i] == TAnimBuilder.tag_appearances.charOpeningTag)
                    {
                        _closingCharacter = TAnimBuilder.tag_appearances.charClosingTag;
                        return true;
                    }

                    _closingCharacter = default;
                    return false;
                }

                //Pastes the entire tag (eg. <ciao>) to the text
                void AppendCurrentTagToText()
                {
                    temp_realText.Append(entireTag);
                    realTextIndex += entireTag.Length;
                }

                #endregion

                if (TryGetClosingCharacter(out char closingCharacter))
                {
                    indexOfNextOpening = text.IndexOf(text[i], i + 1);
                    indexOfClosing = text.IndexOf(closingCharacter, i + 1);

                    //Checks if the tag is closed correctly and valid
                    if (
                        indexOfClosing >= 0  //the tag ends somewhere
                            && (
                                indexOfNextOpening > indexOfClosing || //next opening char is further from the closing (example, at first pos "<hello> <" is ok, "<<hello>" is wrong)
                                indexOfNextOpening < 0 //there isn't a next opening char
                            )
                        )
                    {
                        //entire tag found, including < and >
                        entireTag = (text.Substring(i, indexOfClosing - i + 1));
                        entireLoweredTag = entireTag.ToLower();
                        richTextTag = entireLoweredTag.Substring(1, entireLoweredTag.Length - 2);

                        #region Processes Tags
                        if (richTextTag.Length < 1) //avoids an empty tag
                        {
                            AppendCurrentTagToText();
                        }
                        else
                        {
                            if (closingCharacter == TAnimBuilder.tag_appearances.charClosingTag)
                            {
                                if (noparseEnabled || !TryProcessingAppearanceTag(richTextTag, realTextIndex))
                                {
                                    AppendCurrentTagToText();
                                }
                            }
                            else //behavior effects
                            {
                                switch (TMP_TextUtilities.StringHexToInt(richTextTag))
                                {
                                    //<noparse>
                                    case 268414974: noparseEnabled = true; AppendCurrentTagToText(); break;
                                    case -20482: noparseEnabled = false; AppendCurrentTagToText(); break;


                                    default:

                                        if (noparseEnabled)
                                        {
                                            AppendCurrentTagToText();
                                        }
                                        else
                                        {
                                            if (!TryProcessingBehaviorTag(richTextTag, realTextIndex, ref internalEventActionIndex))
                                            {
                                                if (!TryProcessingActionTag(entireLoweredTag, realTextIndex, ref internalEventActionIndex))
                                                {
                                                    AppendCurrentTagToText();
                                                }
                                            }
                                        }
                                        break;
                                }


                            }
                        }
                        #endregion

                        //"skips" all the characters inside the tag, so we'll go back adding letters again
                        i = indexOfClosing;

                    }
                    else //tag is not closed correctly - pastes the tag opening/closing character (eg. '<')
                    {
                        AppendCurrentCharacterToText();
                    }
                }
                else
                {
                    AppendCurrentCharacterToText();
                }
            }

            return temp_realText.ToString();
        }

        void _ApplyTextToCharacters(string text)
        {
            //Applies the formatted to the component in order to get the proper TextInfo
            {
                //Avoids rendering the text for half a frame
                tmproText.renderMode = TextRenderFlags.DontRender;

                tmproText.text = text; //<-- sets the text
                tmproText.ForceMeshUpdate();

                textInfo = tmproText.GetTextInfo(tmproText.text);

            }

            #region Characters Setup
            //Resizes characters array
            if (characters.Length < textInfo.characterCount)
                Array.Resize(ref characters, textInfo.characterCount);

            for (int i = 0; i < textInfo.characterCount; i++)
            {
                characters[i].data.tmp_CharInfo = textInfo.characterInfo[i];

                //Calculates which effects are applied to this character

                #region Sources and data

                //Creates sources and data arrays only the first time
                if (!characters[i].initialized)
                {
                    characters[i].sources.vertices = new Vector3[TextUtilities.verticesPerChar];
                    characters[i].sources.colors = new Color32[TextUtilities.verticesPerChar];

                    characters[i].data.vertices = new Vector3[TextUtilities.verticesPerChar];
                    characters[i].data.colors = new Color32[TextUtilities.verticesPerChar];
                }

                try
                {
                    //Copies source data from the mesh info
                    for (byte k = 0; k < TextUtilities.verticesPerChar; k++)
                    {
                        //vertices
                        characters[i].sources.vertices[k] = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices[textInfo.characterInfo[i].vertexIndex + k];

                        //colors
                        characters[i].sources.colors[k] = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].colors32[textInfo.characterInfo[i].vertexIndex + k];
                    }
                }
                catch (Exception e)
                {
                    Debug.Log("Exception : " + e);
                }
                #endregion

                void SetEffectsDependency<T>(ref int[] indexes, List<T> effects, int fallbackEffectsCount) where T : EffectsBase
                {
                    temp_effectsToApply.Clear();

                    //Checks if the character is inside a region of any effect, if yes we add a pointer to it
                    for (int l = fallbackEffectsCount; l < effects.Count; l++)
                    {
                        if (effects[l].regionManager.IsCharInsideRegion(textInfo.characterInfo[i].index))
                        {
                            temp_effectsToApply.Add(l);
                        }
                    }

                    indexes = new int[temp_effectsToApply.Count];
                    for (int x = 0; x < temp_effectsToApply.Count; x++)
                    {
                        indexes[x] = temp_effectsToApply[x];
                    }
                }

                //Assigns effects
                SetEffectsDependency(ref characters[i].indexBehaviorEffects, behaviorEffects, fallbackBehaviorEffects.Length);
                SetEffectsDependency(ref characters[i].indexAppearanceEffects, appearanceEffects, fallbackAppearanceEffects.Length);

                #region Fallback Effects
                //TODO generic method for both

                //Assigns fallbacks appearances if there are no effects on the current characters
                if (fallbackAppearanceEffects.Length > 0 && characters[i].indexAppearanceEffects.Length <= 0)
                {
                    characters[i].indexAppearanceEffects = new int[fallbackAppearanceEffects.Length];
                    for (int x = 0; x < fallbackAppearanceEffects.Length; x++)
                    {
                        characters[i].indexAppearanceEffects[x] = x; //fallback effects are added at the start of the array
                    }
                }

                //Assigns fallbacks behaviors if there are no effects on the current characters
                if (fallbackBehaviorEffects.Length > 0 && characters[i].indexBehaviorEffects.Length <= 0)
                {
                    characters[i].indexBehaviorEffects = new int[fallbackBehaviorEffects.Length];
                    for (int x = 0; x < fallbackBehaviorEffects.Length; x++)
                    {
                        characters[i].indexBehaviorEffects[x] = x; //fallback effects are added at the start of the array
                    }
                }
                #endregion

                //calculates appearance duration
                //for (int k = 0; k < characters[i].indexAppearanceEffects.Length; k++)
                //{
                //    characters[i].appearanceDuration = Mathf.Max(characters[i].appearanceDuration, appearanceEffects[characters[i].indexAppearanceEffects[k]].effectDuration);
                //}
            }
            #endregion

            #region Updates variables
            hasText = text.Length > 0;
            autoSize = tmproText.enableAutoSizing;
            this.text = tmproText.text;
            #endregion

            //Avoids the next text to be rendered for half a frame
            tmproText.renderMode = TextRenderFlags.DontRender;

            #region Effects and Features Initialization

            SetupEffectsIntensity();

            for (int i = 0; i < this.appearanceEffects.Count; i++)
            {
                this.appearanceEffects[i].SetDefaultValues(appearancesContainer.values);
            }

            for (int i = 0; i < behaviorEffects.Count; i++)
            {
                behaviorEffects[i].Initialize(characters.Length);
            }

            for (int i = 0; i < appearanceEffects.Count; i++)
            {
                appearanceEffects[i].Initialize(characters.Length);
            }

            #endregion

            CopyMeshSources();
        }

        void TryTriggeringEvent(int maxInternalOrder)
        {
            //Calls all events markers until the current shown visible character
            for (int i = latestTriggeredEvent; i < eventMarkers.Count; i++)
            {
                if (!eventMarkers[i].triggered && //current event must not be triggered already
                    eventMarkers[i].charIndex <= textInfo.characterInfo[visibleCharacters].index && //triggers any event until the current character
                    eventMarkers[i].internalOrder < maxInternalOrder
                    )
                {
                    var _event = eventMarkers[i];
                    _event.triggered = true;
                    eventMarkers[i] = _event;

                    latestTriggeredEvent = i;
                    onEvent?.Invoke(eventMarkers[i].eventMessage);
                }
            }
        }

        /// <summary>
        /// Tries to get an action in the current position of the text
        /// </summary>
        /// <param name="action">Initialized feature</param>
        /// <returns>True if we have found one action  in the current text position</returns>
        internal bool TryGetAction(out TypewriterAction action)
        {
            if (visibleCharacters >= textInfo.characterCount) //avoids searching if text has ended
            {
                action = default;
                return false;
            }

            for (int i = latestTriggeredAction; i < typewriterActions.Count; i++)
            {
                if (typewriterActions[i].charIndex == textInfo.characterInfo[visibleCharacters].index &&
                    !typewriterActions[i].triggered)
                {
                    //tries triggering event, if it's written before function
                    TryTriggeringEvent(typewriterActions[i].internalOrder);

                    var typAction = typewriterActions[i];
                    typAction.triggered = true;
                    typewriterActions[i] = typAction;

                    action = typAction.action;

                    latestTriggeredAction = i;
                    return true;
                }
            }

            action = default;
            return false;
        }

        /// <summary>
        /// Assigns intensity multiplier and effect values/parameters to effects
        /// </summary>
        void SetupEffectsIntensity()
        {
            float intensity = effectIntensityMultiplier;

            if (useDynamicScaling)
            {
                //multiplies by font size
                intensity *= tmproText.fontSize / referenceFontSize;
            }

            for (int i = 0; i < behaviorEffects.Count; i++)
            {
                behaviorEffects[i].uniformIntensity = intensity;
            }

            for (int i = 0; i < appearanceEffects.Count; i++)
            {
                appearanceEffects[i].uniformIntensity = intensity;
            }

        }

        #endregion

        #region Mesh

        int tmpFirstVisibleCharacter;
        void CopyMeshSources()
        {
            forceMeshRefresh = false;
            autoSize = tmproText.enableAutoSizing;
            sourceRect = tmproText.rectTransform.rect;
            sourceColor = tmproText.color;
            tmpFirstVisibleCharacter = tmproText.firstVisibleCharacter;

            SetupEffectsIntensity();
            try
            {
                //Updates the characters sources
                for (int i = 0; i < textInfo.characterCount; i++)
                {
                    //if (!textInfo.characterInfo[i].isVisible)
                    //    continue;

                    //Updates TMP char info
                    characters[i].data.tmp_CharInfo = textInfo.characterInfo[i];

                    //Updates vertices
                    for (byte k = 0; k < TextUtilities.verticesPerChar; k++)
                    {
                        characters[i].sources.vertices[k] = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices[textInfo.characterInfo[i].vertexIndex + k];
                    }

                    //Updates colors
                    for (byte k = 0; k < TextUtilities.verticesPerChar; k++)
                    {
                        characters[i].sources.colors[k] = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].colors32[textInfo.characterInfo[i].vertexIndex + k];
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("exception : " + e);
            }
        }

        /// <summary>
        /// Applies the changes to the text component
        /// </summary>
        void UpdateMesh()
        {
            //Updates the mesh
            for (int i = 0; i < textInfo.characterCount; i++)
            {
                //Avoids updating if we're on an invisible character, like a spacebar
                //Do not switch this with "i<visibleCharacters", since the plugin has to update not yet visible characters
                if (!textInfo.characterInfo[i].isVisible)
                {
                    continue;
                }

                //Updates TMP char info
                textInfo.characterInfo[i] = characters[i].data.tmp_CharInfo;

                //Updates vertices
                for (byte k = 0; k < TextUtilities.verticesPerChar; k++)
                {
                    textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices[textInfo.characterInfo[i].vertexIndex + k] = characters[i].data.vertices[k];
                }

                //Updates colors
                for (byte k = 0; k < TextUtilities.verticesPerChar; k++)
                {
                    textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].colors32[textInfo.characterInfo[i].vertexIndex + k] = characters[i].data.colors[k];
                }
            }

            tmproText.UpdateVertexData();
        }

        #endregion


        private void Update()
        {
            //TMPRO's text changed, setting the text again
            if (!tmproText.text.Equals(text))
            {
                if (hasParentCanvas && !parentCanvas.isActiveAndEnabled)
                    return;

                //trigers anim player
                if (triggerAnimPlayerOnChange && tAnimPlayer != null)
                {

#if TA_NoTempFix
                    tAnimPlayer.ShowText(tmproText.text);
#else

                    //temp fix, opening and closing this TMPro tag (which won't be showed in the text, acting like they aren't there) because otherwise
                    //there isn't any way to trigger that the text has changed, if it's actually the same as the previous one.

                    if (tmproText.text.Length <= 0) //forces clearing the mesh during the tempFix, without the <noparse> tags
                        tAnimPlayer.ShowText("");
                    else
                        tAnimPlayer.ShowText($"<noparse></noparse>{tmproText.text}");
#endif

                }
                else //user is typing from TMPro
                {
                    _SetText(tmproText.text, ShowTextMode.UserTyping);
                }

                return;
            }

            if (!hasText)
                return;


            m_time.UpdateDeltaTime(timeScale);
            m_time.IncreaseTime();

            #region Effects Calculation

            for (int i = 0; i < behaviorEffects.Count; i++)
            {
                behaviorEffects[i].SetAnimatorData(m_time);
                behaviorEffects[i].Calculate();
            }

            for (int i = 0; i < appearanceEffects.Count; i++)
            {
                appearanceEffects[i].Calculate();
            }
            #endregion

            for (int i = 0; i < textInfo.characterCount; i++)
            {

#if INTEGRATE_NANINOVEL
                //If we're integrating naninovels, shows characters based on its reveal component
                if (isNaninovelPresent)
                {
                    if (reveablelText.RevealProgress < (float)i / textInfo.characterCount)
                        continue;
                }
#endif

                //applies effects only if the character is visible in TMPro
                //otherwise the UVs etc. are all distorted
                if (!textInfo.characterInfo[i].isVisible || i >= visibleCharacters)
                {
                    characters[i].data.passedTime = 0;
                    characters[i].Hide();
                    continue;
                }

                characters[i].data.passedTime += m_time.deltaTime;


                characters[i].ResetColors();
                characters[i].ResetVertices();

                //behaviors
                if (enabled_globalBehaviors && enabled_localBehaviors)
                {
                    for (int l = 0; l < characters[i].indexBehaviorEffects.Length; l++)
                    {
                        behaviorEffects[
                            characters[i].indexBehaviorEffects[l] //indexes of the effect to apply
                            ].ApplyEffect(ref characters[i].data, i);
                    }
                }

                //appearances
                if (enabled_globalAppearances && enabled_localAppearances && !skipAppearanceEffects)
                {
                    for (int l = 0; l < characters[i].indexAppearanceEffects.Length; l++)
                    {

                        if (appearanceEffects[characters[i].indexAppearanceEffects[l]].CanShowAppearanceOn(characters[i].data.passedTime))
                        {
                            appearanceEffects[
                                characters[i].indexAppearanceEffects[l]
                                ].ApplyEffect(ref characters[i].data, i);
                        }
                    }
                }

            }


            UpdateMesh();

            //TMPro's component changed, recalculating mesh
            //P.S. Must be placed after everything else.
            if (tmproText.havePropertiesChanged
                || forceMeshRefresh
                //changing the properties below doesn't seem to trigger 'havePropertiesChanged', so we're checking them manually
                || tmproText.enableAutoSizing != autoSize
                || tmproText.rectTransform.rect != sourceRect
                || tmproText.color != sourceColor
                || tmproText.firstVisibleCharacter != tmpFirstVisibleCharacter
                )
            {
                tmproText.ForceMeshUpdate();
                CopyMeshSources();
            }

        }

        private void OnEnable()
        {
            //The mesh might have changed when the gameObject was disabled (eg. change of "autoSize")
            forceMeshRefresh = true;

#if UNITY_EDITOR
            TAnim_EditorHelper.onChangesApplied += EDITORONLY_ResetEffects;
#endif
        }

#if UNITY_EDITOR
        #region Editor
#if CHECK_ERRORS
        void EDITOR_CompatibilityCheck(string text)
        {
            #region Text
            string textLower = text.ToLower();
            string errorsLog = "";

            //page
            if ((textLower.Contains("<page=")))
            {
                errorsLog += "- Tag <page> is not compatible\n";
            }

            if (errorsLog.Length > 0)
            {
                Debug.LogError($"TextAnimator: Given text not accepted [expand for more details]\n\nText:'{text}'\n\nErrors:\n{errorsLog}", this.gameObject);
            }
            #endregion
        }
#endif

        [ContextMenu("Toggle Appearances (all scripts)")]
        void EDITORONLY_ToggleAppearances()
        {
            if (!Application.isPlaying)
                return;

            EnableAppearances(!enabled_globalAppearances);
        }

        [ContextMenu("Toggle Behaviors (all scripts)")]
        void EDITORONLY_ToggleBehaviors()
        {
            if (!Application.isPlaying)
                return;

            EnableBehaviors(!enabled_globalBehaviors);
        }

        private void OnDisable()
        {
            TAnim_EditorHelper.onChangesApplied -= EDITORONLY_ResetEffects;
        }

        void EDITORONLY_ResetEffects()
        {
            if (!Application.isPlaying)
                return;

            if (behaviorEffects != null && appearanceEffects != null)
            {
                for (int i = 0; i < behaviorEffects.Count; i++)
                {
                    behaviorEffects[i].SetDefaultValues(behaviorValues);
                }

                for (int i = 0; i < appearanceEffects.Count; i++)
                {
                    appearanceEffects[i].SetDefaultValues(appearancesContainer.values);
                }

                SetupEffectsIntensity();

                for (int i = 0; i < behaviorEffects.Count; i++)
                {
                    behaviorEffects[i].EDITOR_ApplyModifiers();
                }
            }
        }
        #endregion
#endif
    }
}