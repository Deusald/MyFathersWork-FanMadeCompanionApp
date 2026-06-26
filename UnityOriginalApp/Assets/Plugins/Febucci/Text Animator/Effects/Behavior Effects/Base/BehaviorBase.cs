namespace Febucci.UI.Core
{
    /// <summary>
    /// Base class for all behavior effects.<br/>
    /// Inherit from this class if you want to create your own Behavior Effect in C#.
    /// </summary>
    public abstract class BehaviorBase : EffectsBase
    {
        public abstract void SetDefaultValues(BehaviorDefaultValues data);

        /// <summary>
        /// Invoked when there is a modifier in your rich text tag, eg. &#60;shake a=3&#62;
        /// </summary>
        /// <remarks>You can also use the following helper methods:
        /// - <see cref="EffectsBase.ApplyModifierTo"/>
        /// - <see cref="FormatUtils.ParseFloat"/>
        /// </remarks>
        /// <param name="modifierName">modifier name. eg. in &#60;shake a=3&#62; this string is "a"</param>
        /// <param name="modifierValue">modifier value. eg. in &#60;shake a=3&#62; this string is "3"</param>
        /// <example>
        /// <code>
        /// float amplitude = 2;
        /// //[...]
        /// public override void SetModifier(string modifierName, string modifierValue){
        ///     switch(modifierName){
        ///         //changes the 'amplitude' variable based on the modifier written in the tag
        ///         //eg. when you write a tag like &#60;shake a=3&#62;
        ///         case "a": ApplyModifierTo(ref amplitude, modifierValue); return;
        ///     }
        /// }
        /// </code>
        /// </example>
        public abstract void SetModifier(string modifierName, string modifierValue);

        [System.Obsolete("This variable will be removed from next versions. Please use 'time.timeSinceStart' instead")]
        public float animatorTime => time.timeSinceStart;
        [System.Obsolete("This variable will be removed from next versions. Please use 'time.deltaTime' instead")]
        public float animatorDeltaTime => time.deltaTime;
        
        /// <summary>
        /// Contains data/settings from the TextAnimator component that is linked to (and managing) this effect.
        /// </summary>
        public TextAnimator.TimeData time { get; private set; }

        internal void SetAnimatorData(in TextAnimator.TimeData time)
        {
            this.time = time;
        }

#if UNITY_EDITOR
        //Used only in the editor to set again modifiers if we change values in the inspector

        System.Collections.Generic.List<Modifier> modifiers { get; set; } = new System.Collections.Generic.List<Modifier>();

        internal void EDITOR_RecordModifier(string name, string value)
        {
            modifiers.Add(new Modifier
            {
                name = name,
                value = value,
            });
        }

        internal void EDITOR_ApplyModifiers()
        {
            for (int i = 0; i < modifiers.Count; i++)
            {
                SetModifier(modifiers[i].name, modifiers[i].value);
            }
        }
#endif
    }
}