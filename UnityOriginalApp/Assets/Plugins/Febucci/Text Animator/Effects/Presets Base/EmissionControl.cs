using UnityEngine;

namespace Febucci.UI.Core
{
    [System.Serializable]
    internal struct EmissionControl
    {
#pragma warning disable 0649 //disables warning 0649, "value declared but never assigned", since Unity actually assigns the variable in the inspector through the [SerializeField] attribute, but the compiler doesn't know this and throws warnings
        [SerializeField, Attributes.MinValue(0)] int cycles;

        [SerializeField] AnimationCurve attackCurve;
        [SerializeField, Attributes.MinValue(0)] float overrideDuration;
        [SerializeField] bool continueForever;
        [SerializeField] AnimationCurve decayCurve;
#pragma warning restore 0649

        [System.NonSerialized] float maxDuration;
        [System.NonSerialized] AnimationCurve intensityOverDuration;
        [System.NonSerialized] float passedTime;
        [System.NonSerialized] float cycleDuration;

        [System.NonSerialized] public float effectWeigth;


        public void Initialize(float effectsMaxDuration)
        {
            effectWeigth = 0;
            passedTime = 0;

            Keyframe[] totalKeys = new Keyframe[
                attackCurve.length + (continueForever ? 0 : decayCurve.length)
                ];

            for (int i = 0; i < attackCurve.length; i++)
            {
                totalKeys[i] = attackCurve[i];
            }

            if (!continueForever)
            {
                if (overrideDuration > 0)
                {
                    effectsMaxDuration = overrideDuration;
                }

                float attackDuration = attackCurve.CalculateCurveDuration();

                for (int i = attackCurve.length; i < totalKeys.Length; i++)
                {
                    totalKeys[i] = decayCurve[i - attackCurve.length];
                    totalKeys[i].time += effectsMaxDuration + attackDuration;
                }
            }

            intensityOverDuration = new AnimationCurve(totalKeys);
            intensityOverDuration.preWrapMode = WrapMode.Loop;
            intensityOverDuration.postWrapMode = WrapMode.Loop;

            this.cycleDuration = intensityOverDuration.CalculateCurveDuration();
            maxDuration = cycleDuration * cycles;
        }

        public float IncreaseEffectTime(float deltaTime)
        {
            if (deltaTime == 0)
                return passedTime;

            passedTime += deltaTime;

            if (passedTime < 0)
                passedTime = 0;

            //inside duration
            if (passedTime > cycleDuration) //increases cycle
            {
                if (continueForever)
                {
                    effectWeigth = 1;
                    return passedTime;
                }
            }

            //outside cycles
            if (cycles > 0 && passedTime >= maxDuration)
            {
                effectWeigth = 0;
                return 0;
            }

            effectWeigth = intensityOverDuration.Evaluate(passedTime);

            return passedTime;
        }
    }
}