using UnityEngine;

namespace Febucci.UI.Core
{
    [System.Serializable]
    internal class FloatCurve : EffectEvaluator
    {
#pragma warning disable 0649 //disabling the error or unity will throw "field is never assigned" [..], because we actually assign the variables from the custom drawers
        public bool enabled;

        [SerializeField] protected float amplitude;
        [SerializeField] protected AnimationCurve curve;

        [SerializeField, HideInInspector] protected float defaultReturn;

        [SerializeField, Range(0, 100)] protected float charsTimeOffset; //clamping to 100 because it repeates the behavior after it

        [System.NonSerialized] float calculatedDuration;
#pragma warning restore 0649

        public bool isEnabled => enabled;

        public float GetDuration()
        {
            return calculatedDuration;
        }

        bool isAppearance;

        public void Initialize(int type)
        {
            calculatedDuration = curve.CalculateCurveDuration();

            isAppearance = type >= 3;

            switch (type)
            {
                //mov
                default:
                case 0: defaultReturn = 0; break;

                //scale
                case 1: defaultReturn = 1; break;

                //rot
                case 2: defaultReturn = 0; break;

                //app mov
                case 3: defaultReturn = 0; break;

                //app scale
                case 4: defaultReturn = 1; break;

                //app rot
                case 5: defaultReturn = 0; break;

            }
        }

        public float Evaluate(float time, int characterIndex)
        {
            if (!enabled)
                return defaultReturn;

            if (isAppearance)
            {
                return Mathf.LerpUnclamped(amplitude, defaultReturn, curve.Evaluate(time) * Mathf.Cos(Mathf.Deg2Rad * (characterIndex * charsTimeOffset / 2f)));
            }


            //behavior
            return curve.Evaluate(time + characterIndex * (charsTimeOffset / 100f)) * amplitude;
        }
    }
}