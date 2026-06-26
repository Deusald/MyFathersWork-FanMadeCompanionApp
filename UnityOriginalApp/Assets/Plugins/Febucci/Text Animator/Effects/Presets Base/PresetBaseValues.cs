using UnityEngine;

namespace Febucci.UI.Core
{
    [System.Serializable]
    internal class PresetBaseValues
    {
#pragma warning disable 0649 //disabling the error or unity will throw "field is never assigned" [..], because we actually assign the variables from the custom drawers
        public string effectTag;

        [SerializeField] public FloatCurve movementX;
        [SerializeField] public FloatCurve movementY;
        [SerializeField] public FloatCurve movementZ;

        [SerializeField] public FloatCurve scaleX;
        [SerializeField] public FloatCurve scaleY;

        [SerializeField] public FloatCurve rotX;
        [SerializeField] public FloatCurve rotY;
        [SerializeField] public FloatCurve rotZ;

        [SerializeField] public ColorCurve color;
#pragma warning restore 0649
        public float GetMaxDuration()
        {
            float GetEffectEvaluatorDuration(EffectEvaluator effect)
            {
                if (effect.isEnabled)
                    return effect.GetDuration();
                return 0;
            }

            return Mathf.Max
                (
                    GetEffectEvaluatorDuration(movementX),
                    GetEffectEvaluatorDuration(movementY),
                    GetEffectEvaluatorDuration(movementZ),
                    GetEffectEvaluatorDuration(scaleX),
                    GetEffectEvaluatorDuration(scaleY),
                    color.enabled ? color.GetDuration() : 0
                );
        }

        public virtual void Initialize(bool isAppearance)
        {
            int baseIdentifier = isAppearance ? 3 : 0;

            movementX.Initialize(baseIdentifier);
            movementY.Initialize(baseIdentifier);
            movementZ.Initialize(baseIdentifier);

            scaleX.Initialize(baseIdentifier + 1);
            scaleY.Initialize(baseIdentifier + 1);

            rotX.Initialize(baseIdentifier + 2);
            rotY.Initialize(baseIdentifier + 2);
            rotZ.Initialize(baseIdentifier + 2);

            color.Initialize(isAppearance);
        }
    }

}