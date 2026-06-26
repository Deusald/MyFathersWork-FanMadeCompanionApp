namespace Febucci.UI.Core
{
    /// <summary>
    /// Attribute used to set effect settings
    /// </summary>
    /// <example>
    /// In order to set a "jump" tag to the below class:
    /// <code>
    /// [EffectInfo(tag: "jump")]
    /// public class JumpEffect : BehaviorEffect
    /// {
    /// ///[...]
    /// </code>
    /// </example>
    [System.AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class EffectInfoAttribute : System.Attribute
    {
        public readonly string tag;
        public EffectInfoAttribute(string tag)
        {
            this.tag = tag;
        }
    }
}