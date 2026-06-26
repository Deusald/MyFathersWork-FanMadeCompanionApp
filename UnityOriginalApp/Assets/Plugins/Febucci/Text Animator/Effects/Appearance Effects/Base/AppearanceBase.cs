namespace Febucci.UI.Core
{
    /// <summary>
    /// Base class for all appearance effects. <br/>
    /// Inherit from this class if you want to create your own Appearance Effect in C#.
    /// </summary>
    public abstract class AppearanceBase : EffectsBase
    {
        public float effectDuration = .3f;
        
        [System.Obsolete("This variable will be removed from next versions. Please use 'effectDuration' instead")]
        protected float showDuration => effectDuration;

        /// <summary>
        /// Initializes the effect's default values. It is called before the effect is applied to letters.
        /// </summary>
        /// <remarks>
        /// Use this to assign values to your effect.
        /// </remarks>
        /// <example>
        /// <code>
        /// effectDuration = data.defaults.sizeDuration;
        /// amplitude = data.defaults.sizeAmplitude;
        /// </code>
        /// </example>
        /// <param name="data"></param>
        public abstract void SetDefaultValues(AppearanceDefaultValues data);

        public virtual bool CanShowAppearanceOn(float timePassed)
        {
            return timePassed <= effectDuration;
        }
    }
}