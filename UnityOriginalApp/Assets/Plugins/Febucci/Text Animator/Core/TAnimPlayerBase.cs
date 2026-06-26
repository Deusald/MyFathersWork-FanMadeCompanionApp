using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

namespace Febucci.UI.Core
{
    [System.Serializable]
    public class CharacterEvent : UnityEvent<char> { }

    /// <summary>
    /// Base class for all TextAnimatorPlayers (typewriters). <br/>
    /// - Manual: <see href="https://www.textanimator.febucci.com/docs/text-animator-players/">TextAnimatorPlayers</see>.<br/>
    /// </summary>
    /// <remarks>
    /// If you want to use the default TextAnimatorPlayer, see: <see cref="TextAnimatorPlayer"/><br/>
    /// <br/>
    /// You can also create custom typewriters by inheriting from this class. <br/>
    /// Manual: <see href="https://www.textanimator.febucci.com/docs/writing-custom-tanimplayers-c-sharp/">Writing Custom TextAnimatorPlayers (C#)</see>
    /// </remarks>
    [DisallowMultipleComponent]
    [RequireComponent(typeof(TextAnimator))]
    public abstract class TAnimPlayerBase : MonoBehaviour
    {
        [System.Flags]
        enum StartTypewriterMode
        {
            /// <summary>
            /// Typewriter starts typing ONLY if you invoke "StartShowingText" from any of your script.
            /// </summary>
            FromScriptOnly = 0,

            /// <summary>
            /// Typewriter automatically starts/resumes from the "OnEnable" method
            /// </summary>
            OnEnable = 1,

            /// <summary>
            /// Typewriter automatically starts once you call "ShowText" method [includes Easy Integration]
            /// </summary>
            OnShowText = 2,

            AutomaticallyFromAllEvents = OnEnable | OnShowText //legacy support for unity 2018.x [instead of automatic recognition in 2019+] 
        }

        #region Variables

        #region Management Variables

        string textToShow = string.Empty;
        TextAnimator _textAnimator;

        /// <summary>
        /// The TextAnimator Component linked to this typewriter
        /// </summary>
        public TextAnimator textAnimator
        {
            get
            {
                if (_textAnimator != null)
                    return _textAnimator;

#if UNITY_2019_2_OR_NEWER
                if(!TryGetComponent(out _textAnimator))
                {
                    Debug.LogError($"TextAnimator: Text Animator component is null on GameObject {gameObject.name}");
                }
#else
                _textAnimator = GetComponent<TextAnimator>();
                Assert.IsNotNull(_textAnimator, $"Text Animator component is null on GameObject {gameObject.name}");
#endif

                return _textAnimator;
            }
        }


        /// <summary>
        /// <c>true</c> if the typewriter is currently showing letters.
        /// </summary>
        protected bool isBaseInsideRoutine => isInsideRoutine;
        bool isInsideRoutine = false;

        /// <summary>
        /// <c>true</c> if the player wants to skip the typewriter.<br/>
        /// You can check/modify its value and also call <see cref="SkipTypewriter"/> to set it to <c>true</c>.
        /// </summary>
        /// <remarks>
        /// P.S. It is reset back to <c>false</c> every time you show a new text.
        /// </remarks>
        protected bool wantsToSkip = false;


        #endregion

        #region Typewriter settings
        /// <summary>
        /// <c>true</c> if the typewriter is enabled
        /// </summary>
        [Tooltip("True if you want to shows the text dynamically")]
        [SerializeField] public bool useTypeWriter = true;

        [SerializeField, Tooltip("Controls from which method(s) the typewriter will automatically start/resume. Default is 'Automatic'")]
        StartTypewriterMode startTypewriterMode = StartTypewriterMode.AutomaticallyFromAllEvents;

        #region Typewriter Skip
        [SerializeField]
        bool canSkipTypewriter = true;
        [SerializeField]
        bool hideAppearancesOnSkip = false;
        [SerializeField, Tooltip("True = plays all remaining events once the typewriter has been skipped")]
        bool triggerEventsOnSkip = false;
        #endregion


        [SerializeField, Tooltip("True = resets the typewriter speed every time a new text is set/shown")] bool resetTypingSpeedAtStartup = true;

        /// <summary>
        /// Typewriter's speed (acts like a multiplier)<br/>
        /// You can change this value or invoke <see cref="SetTypewriterSpeed(float)"/>
        /// </summary>
        protected float typewriterPlayerSpeed = 1;


        #endregion

        #endregion

        #region Events
        /// <summary>
        /// Called once the text is completely shown. <br/>
        /// If the typewriter is enabled, this event is called once it has ended showing all letters.
        /// </summary>
        public UnityEvent onTextShowed;

        /// <summary>
        /// Called once the typewriter starts showing text.<br/>
        /// It is only invoked when the typewriter is enabled.
        /// </summary>
        public UnityEvent onTypewriterStart;

        /// <summary>
        /// Called once a character has been shown by the typewriter.<br/>
        /// It is only invoked when the typewriter is enabled.
        /// </summary>
        public CharacterEvent onCharacterVisible;

        #endregion

        /// <summary>
        /// Shows remains letters dynamically
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private IEnumerator ShowRemainingCharacters()
        {
            if (!textAnimator.allLettersShown)
            {
                isInsideRoutine = true;
                wantsToSkip = false;

                onTypewriterStart?.Invoke();

                IEnumerator WaitTime(float time)
                {
                    if (time > 0)
                    {
                        float t = 0;
                        while (t <= time && !HasSkipped())
                        {
                            t += textAnimator.time.deltaTime;
                            yield return null;
                        }
                    }
                }

                float timeToWait;
                char characterShown;

                if (resetTypingSpeedAtStartup)
                    typewriterPlayerSpeed = 1;

                float typewriterTagsSpeed = 1;

                bool HasSkipped()
                {
                    return canSkipTypewriter && wantsToSkip;
                }

                float timePassed = 0;

                float deltaTime;
                UpdateDeltaTime();

                void UpdateDeltaTime()
                {
                    deltaTime = textAnimator.time.deltaTime * typewriterPlayerSpeed * typewriterTagsSpeed;
                }

                //Shows character by character until all are shown
                while (!textAnimator.allLettersShown)
                {
                    //searches for actions [before the character, incl. at the very start of the text]
                    if (textAnimator.hasActions)
                    {
                        //loops until features ended (there could be multiple ones in the same text position, example: when two tags are next to eachother without spaces
                        while (textAnimator.TryGetAction(out TypewriterAction action))
                        {
                            //Default features
                            switch (action.actionID)
                            {
                                case "waitfor":
                                    float waitTime;
                                    FormatUtils.TryGetFloat(action.parameters, 0, 1f, out waitTime);
                                    yield return WaitTime(waitTime);
                                    break;

                                case "waitinput":
                                    yield return WaitInput();
                                    break;

                                case "speed":
                                    FormatUtils.TryGetFloat(action.parameters, 0, 1, out typewriterTagsSpeed);

                                    //clamps speed (time cannot go backwards!)
                                    if (typewriterTagsSpeed <= 0)
                                    {
                                        typewriterTagsSpeed = 0.001f;
                                    }

                                    break;

                                //Action is custom
                                default:
                                    yield return DoCustomAction(action);
                                    break;
                            }

                        }
                    }


                    //increases the visible chars count and stores the new one
                    characterShown = textAnimator.IncreaseVisibleChars();
                    UpdateDeltaTime();

                    //triggers event unless it's a space
                    if (characterShown != ' ')
                    {
                        onCharacterVisible?.Invoke(characterShown);
                    }

                    //gets the time to wait based on the newly character showed
                    timeToWait = WaitTimeOf(characterShown);

                    //waiting less time than a frame, we don't wait yet
                    if (timeToWait < deltaTime)
                    {
                        timePassed += timeToWait;

                        if (timePassed >= deltaTime) //waits only if we "surpassed" a frame duration
                        {
                            yield return null;
                            timePassed %= deltaTime;
                        }
                    }
                    else
                    {
                        while (timePassed < timeToWait && !HasSkipped())
                        {
                            OnTypewriterCharDelay();
                            timePassed += deltaTime;
                            yield return null;
                            UpdateDeltaTime();
                        }

                        timePassed %= timeToWait;
                    }

                    //Skips typewriter
                    if (HasSkipped())
                    {
                        textAnimator.ShowAllCharacters(hideAppearancesOnSkip);

                        if (triggerEventsOnSkip)
                        {
                            textAnimator.TriggerRemainingEvents();
                        }

                        break;
                    }
                }

                // triggers the events at the end of the text
                // 
                // the typewriter is arrived here without skipping
                // meaning that all events were triggered and we only
                // have to fire the ones at the very end
                // (outside tmpro's characters count length)
                if (!canSkipTypewriter || !wantsToSkip)
                {
                    textAnimator.TriggerRemainingEvents();
                }

                isInsideRoutine = false;

                textToShow = string.Empty; //text has been showed, no need to store it now

                onTextShowed?.Invoke();
            }
        }

        #region Public Methods

        /// <summary>
        /// Sets the TextAnimator text. If enabled, it also starts showing letters dynamically. <br/>
        /// - Manual: <see href="https://www.textanimator.febucci.com/docs/text-animator-players/">Text Animator Players</see>
        /// </summary>
        /// <param name="text"></param>
        /// <remarks>
        /// If the typewriter is enabled but its start mode (editable in the Inspector) doesn't include <see cref="StartTypewriterMode.OnShowText"/>, this method won't start showing letters. You'd have to manually call <see cref="StartShowingText"/> in order to start the typewriter, or include different "start modes" like <see cref="StartTypewriterMode.OnEnable"/> and let the script manage it automatically.
        /// </remarks>
        public void ShowText(string text)
        {
            StopShowingText();

            if (string.IsNullOrEmpty(text))
            {
                textToShow = string.Empty;
                textAnimator.SetText(string.Empty, true);
                return;
            }

            textToShow = text;

            wantsToSkip = false;

            textAnimator.SetText(textToShow, useTypeWriter);

            if (!useTypeWriter)
            {
                onTextShowed?.Invoke();
            }
            else
            {
                if (startTypewriterMode.HasFlag(StartTypewriterMode.OnShowText))
                {
                    StartShowingText();
                }
            }
        }

        #region Typewriter
        /// <summary>
        /// Starts showing letters dynamically (if there text is not already entirely shown)
        /// </summary>
        [ContextMenu("Start Showing Text")]
        public void StartShowingText()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) //prevents from firing in edit mode from the context menu
                return;
#endif

            if (!useTypeWriter)
            {
                Debug.LogWarning("TextAnimator: couldn't start typewriter because 'useTypewriter' is disabled");
                return;
            }

            if (!gameObject.activeInHierarchy)
            {
                Debug.LogWarning("TextAnimator: couldn't start typewriter because the gameobject is not active");
                return;
            }

            if (!isInsideRoutine) //starts only if it is not already typing
            {
                StartCoroutine(ShowRemainingCharacters());
            }
        }


        [ContextMenu("Skip Typewriter")]
        /// <summary>
        /// Skips the typewriter animation (if it's currently showing)
        /// </summary>
        public void SkipTypewriter()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) //prevents from firing in edit mode from the context menu
                return;
#endif
            wantsToSkip = true;
        }


        /// <summary>
        /// Stops showing letters dynamically, leaving the text as it is.
        /// </summary>
        [ContextMenu("Stop Showing Text")]
        public void StopShowingText()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying) //prevents from firing in edit mode from the context menu
                return;
#endif
            //Stops only if we're inside the routine
            if (isInsideRoutine)
            {
                isInsideRoutine = false;
                StopAllCoroutines();
            }

            textToShow = string.Empty;
        }

        /// <summary>
        /// Makes the typewriter slower/faster, by setting its internal speed multiplier.
        /// </summary>
        /// <param name="value"></param>
        /// <example>
        /// If the typewriter has to wait <c>1</c> second to show the next letter but you set the typewriter speed to <c>2</c>, the typewriter will wait <c>0.5</c> seconds.
        /// </example>
        /// <remarks>
        /// The minimum value is 0.001
        /// </remarks>
        public void SetTypewriterSpeed(float value)
        {
            typewriterPlayerSpeed = Mathf.Clamp(value, .001f, value);
        }
        #endregion

        #endregion

        #region Virtual/Abstract Methods
        /// <summary>
        /// Waits for user input in order to continue showing text. Invoked when there is a waitinput action tag (Manual: <see href="http://localhost:4000/docs/performing-actions-while-typing/">Performing Actions while Typing</see>)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// You can customize this based on your project inputs.
        /// </remarks>
        protected abstract IEnumerator WaitInput();

        /// <summary>
        /// Returns the typewriter's waiting time based on a given character/letter.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        /// <remarks>
        /// You can customize this in your custom typewriter for your game.<br/>
        /// Some variables/methods that you could use here:<br/>
        /// - <seealso cref="TextAnimator.latestCharacterShown"/><br/>
        /// - <seealso cref="TextAnimator.TryGetNextCharacter(out TMPro.TMP_CharacterInfo)"/><br/>
        /// </remarks>
        /// <example>
        /// Waiting more time if the character is puntuaction.
        /// <code>
        /// protected override float WaitTimeOf(char character)
        /// {
        ///     if (char.IsPunctuation(character))
        ///         return .06f;
        /// 
        ///     return .03f;
        /// }
        /// </code>
        /// </example>
        protected abstract float WaitTimeOf(char character);

        /// <summary>
        /// Override this method in order to implement custom actions in your typewriter.<br/>
        /// - Manual: <see href="https://www.textanimator.febucci.com/docs/writing-custom-actions-c-sharp/">Writing Custom Actions C#</see>
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        protected virtual IEnumerator DoCustomAction(TypewriterAction action)
        {
            throw new System.NotImplementedException($"TextAnimator: Custom Action not implemented with type: {action.actionID}. If you did implement it, please do not call the base method from your overridden one.");
        }

        /// <summary>
        /// Invoked for every frame the typewriter is waiting to show the next letter.<br/>
        /// </summary>
        /// <remarks>
        /// You could use this in order to speed up the waiting time based on the player input. <br/>
        /// - See: <see cref="SetTypewriterSpeed(float)"/>
        /// </remarks>
        protected virtual void OnTypewriterCharDelay()
        {

        }

        #endregion

        /// <summary>
        /// Unity's default MonoBehavior 'OnDisable' callback.
        /// </summary>
        /// <remarks>
        /// P.S. If you're overriding this method, don't forget to invoke the base one.
        /// </remarks>
        protected virtual void OnDisable()
        {
            isInsideRoutine = false;
        }

        /// <summary>
        /// Unity's default MonoBehavior 'OnEnable' callback.
        /// </summary>
        /// <remarks>
        /// P.S. If you're overriding this method, don't forget to invoke the base one.
        /// </remarks>
        protected virtual void OnEnable()
        {
            if (!useTypeWriter)
                return;

            if (!startTypewriterMode.HasFlag(StartTypewriterMode.OnEnable))
                return;

            StartShowingText();
        }
    }

}