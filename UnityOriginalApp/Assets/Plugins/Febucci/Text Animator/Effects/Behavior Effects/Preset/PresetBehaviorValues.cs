using UnityEngine;

namespace Febucci.UI.Core
{
    [System.Serializable]
    internal class PresetBehaviorValues : PresetBaseValues
    {
#pragma warning disable 0649 //disabling the error or unity will throw "field is never assigned" [..], because we actually assign the variables from the custom drawers
        [SerializeField] public EmissionControl emission;
#pragma warning restore 0649

        public override void Initialize(bool isAppearance)
        {
            base.Initialize(isAppearance);
            emission.Initialize(GetMaxDuration());

        }
    }

}