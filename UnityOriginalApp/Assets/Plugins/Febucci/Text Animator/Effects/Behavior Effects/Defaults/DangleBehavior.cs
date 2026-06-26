using UnityEngine;

namespace Febucci.UI.Core
{
    [UnityEngine.Scripting.Preserve]
    [EffectInfo(tag: TAnimTags.bh_Dangle)]
    class DangleBehavior : BehaviorSine
    {
        float sin;

        int targetIndex1;
        int targetIndex2;

        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            amplitude = data.defaults.dangleAmplitude;
            frequency = data.defaults.dangleFrequency;
            waveSize = data.defaults.dangleWaveSize;

            //bottom
            if (data.defaults.dangleAnchorBottom)
            {
                targetIndex1 = 1;
                targetIndex2 = 2;
            }
            else
            {
                targetIndex1 = 0;
                targetIndex2 = 3;
            }

        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            sin = Mathf.Sin(frequency * time.timeSinceStart + charIndex * waveSize) * amplitude * uniformIntensity;

            //moves one side (top or bottom) torwards one direction
            data.vertices[targetIndex1] += Vector3.right * sin;
            data.vertices[targetIndex2] += Vector3.right * sin;
        }
    }
}