namespace Febucci.UI.Core
{
    /// <summary>
    /// Base class for TextAnimator effects' categories<br/>
    /// Please do not inherit from this class directly, but do from <see cref="AppearanceBase"/> or <see cref="BehaviorBase"/>
    /// </summary>
    public abstract class EffectsBase
    {
        /// <summary>
        /// Effect's tag without symbols, eg. "shake"
        /// </summary>
        public string effectTag { get; private set; }


        /// <summary>
        /// Intensity used to uniform effects that behave differently based on screen or font sizes.
        /// </summary>
        /// <remarks>
        /// Multiply this by your effect values only if they behave differently with different screen resolutions, font sizes or similar. (e.g. adding or subtracting vectors)
        /// </remarks>
        public float uniformIntensity = 1;
        
        [System.Obsolete("This value will be removed from next versions. Please use 'uniformIntensity' instead")]  public float effectIntensity => uniformIntensity;

        #region Internal/Core
        //---Methods used only by TextAnimator's internal workflow---//

        internal class RegionManager
        {
            public string entireRichTextTag;
            System.Collections.Generic.List<TextRegion> textRegions = new System.Collections.Generic.List<TextRegion>();

            struct TextRegion
            {
                public int startIndex;
                public int endIndex;

                public TextRegion(int startIndex)
                {
                    this.startIndex = startIndex;
                    this.endIndex = int.MaxValue;
                }
            }

            internal bool IsLastRegionClosed()
            {
                return textRegions.Count > 0 && textRegions[textRegions.Count - 1].endIndex != int.MaxValue;
            }

            internal void AddRegion(int startIndex)
            {
                textRegions.Add(new TextRegion(startIndex));
            }

            internal bool TryReutilizingWithTag(string richTextTag, int indexNewRegionStart)
            {
                if (!entireRichTextTag.Equals(richTextTag))
                    return false;

                if (!IsLastRegionClosed())
                    return true;

                AddRegion(indexNewRegionStart);
                return true;
            }


            internal void CloseEffect(int index)
            {
                var region = textRegions[textRegions.Count - 1];
                region.endIndex = index;
                textRegions[textRegions.Count - 1] = region;
            }

            internal bool IsCharInsideRegion(int charIndex)
            {
                foreach (var region in textRegions)
                {
                    if (charIndex >= region.startIndex && charIndex < region.endIndex)
                        return true;
                }

                return false;
            }

        }

        internal RegionManager regionManager = new RegionManager();

        /// <summary>
        /// For internal use only. Sets the effect settings such as tags, instead of a constructor.
        /// </summary>
        /// <param name="effectTag"></param>
        internal void _Initialize(string effectTag, string entireRichTextTag)
        {
            this.effectTag = effectTag;
            this.regionManager.entireRichTextTag = entireRichTextTag;
        }
        #endregion

        #region Utilities
        //---Methods you can use in your classes---//

        /// <summary>
        /// Applies the modifier by performing a multiplication to the given value.
        /// </summary>
        /// <param name="value">The effect's value you want to modify</param>
        /// <param name="modifierValue">The modifier value. eg. "0.5"</param>
        /// <example>
        /// <code>
        /// string modifier = "0.5";
        /// float amplitude = 1;
        /// ApplyModifierTo(ref amplitude, modifier);
        /// //amplitude becomes 0.5
        /// </code>
        /// </example>
        protected void ApplyModifierTo(ref float value, string modifierValue)
        {
            if (FormatUtils.ParseFloat(modifierValue, out float multiplier))
            {
                value *= multiplier;
            }
        }
        #endregion

        #region Effect Methods
        //---Methods you can override in your classes---//

        /// <summary>
        /// Invoked upon effect creation
        /// </summary>
        /// <param name="charactersCount"></param>
        public virtual void Initialize(int charactersCount) { }

        /// <summary>
        /// Called once per frame, before applying the effect to letters.
        /// Example: You could use this to calculate the effect variables that are indiependant from specific letters
        /// </summary>
        public virtual void Calculate() { }

        /// <summary>
        /// Called once for each letter, per each frame.<br/>
        /// Use this to apply the effect to a letter/character, by modifying its <see cref="CharacterData"/> values.
        /// </summary>
        /// <param name="data">Letters' values like position and colors. It might have been already modified by previous effects.</param>
        /// <param name="charIndex">Letter index/position in the text.</param>
        public abstract void ApplyEffect(ref CharacterData data, int charIndex);

        #endregion
    }
}