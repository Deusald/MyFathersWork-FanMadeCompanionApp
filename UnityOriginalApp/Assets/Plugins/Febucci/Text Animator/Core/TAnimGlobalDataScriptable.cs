using UnityEngine;
using TagFormatting = Febucci.UI.Core.TAnimBuilder.TagFormatting;

namespace Febucci.UI.Core
{
    /// <summary>
    /// Stores TextAnimator's global data, shared in all your project (eg. Global Behaviors and Appearances).<br/>
    /// Must be placed inside the Resources Path <see cref="resourcesPath"/><br/>
    /// - Manual: <see href="https://www.textanimator.febucci.com/docs/creating-effects-in-the-inspector/#global-effects">Creating Global Effects</see>
    /// </summary>
    [System.Serializable]
    [CreateAssetMenu(fileName = "TextAnimator GlobalData", menuName = "TextAnimator/Create Global Text Animator Data")]
    public class TAnimGlobalDataScriptable : ScriptableObject
    {
        /// <summary>
        /// Resources Path where the scriptable object must be stored
        /// </summary>
        public const string resourcesPath = "TextAnimator GlobalData";

        [SerializeField]
        internal PresetBehaviorValues[] globalBehaviorPresets = new PresetBehaviorValues[0];

        [SerializeField]
        internal PresetAppearanceValues[] globalAppearancePresets = new PresetAppearanceValues[0];

        [SerializeField]
        internal string[] customActions = new string[0];


        [SerializeField] internal bool customTagsFormatting = false;
        [SerializeField] internal TagFormatting tagInfo_behaviors = new TagFormatting('<', '>');
        [SerializeField] internal TagFormatting tagInfo_appearances = new TagFormatting('{', '}');
    }

}