using UnityEngine;

namespace Febucci.UI.Core
{
    [UnityEngine.Scripting.Preserve]
    [EffectInfo(tag: TAnimTags.bh_Shake)]
    class ShakeBehavior : BehaviorBase
    {
        public float shakeStrength;
        public float shakeDelay;

        float timePassed;

        int randIndex;

        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            shakeDelay = data.defaults.shakeDelay;
            shakeStrength = data.defaults.shakeStrength;
            ClampValues();
        }

        void ClampValues()
        {
            shakeDelay = Mathf.Clamp(shakeDelay, 0.002f, 500);
        }

        public override void Initialize(int charactersCount)
        {
            base.Initialize(charactersCount);

            randIndex = Random.Range(0, TextUtilities.fakeRandomsCount);
            lastRandomIndex = randIndex;
        }


        public override void SetModifier(string modifierName, string modifierValue)
        {
            switch (modifierName)
            {
                //amplitude
                case "a": ApplyModifierTo(ref shakeStrength, modifierValue); break;
                //delay
                case "d": ApplyModifierTo(ref shakeDelay, modifierValue); break;
            }

            ClampValues();
        }

        int lastRandomIndex;
        public override void Calculate()
        {
            timePassed += time.deltaTime;
            //Changes the shake direction if enough time passed
            if (timePassed >= shakeDelay)
            {
                timePassed = 0;

                randIndex = Random.Range(0, TextUtilities.fakeRandomsCount);

                //Avoids repeating the same index twice 
                if (lastRandomIndex == randIndex)
                {
                    randIndex++;
                    if (randIndex >= TextUtilities.fakeRandomsCount)
                        randIndex = 0;
                }

                lastRandomIndex = randIndex;
            }
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            data.vertices.MoveChar
                (
                    TextUtilities.fakeRandoms[
                                            Mathf.RoundToInt((charIndex + randIndex) % (TextUtilities.fakeRandomsCount - 1))
                                            ] * shakeStrength * uniformIntensity
                    );
        }


        public override string ToString()
        {
            return $"shake delay: {shakeDelay}\n" +
                $"strength: {shakeStrength}" +
                $"\n{ base.ToString()}";
        }

    }
}