using UnityEngine;

namespace Febucci.UI.Core
{
    [UnityEngine.Scripting.Preserve]
    [EffectInfo(tag: TAnimTags.bh_Pendulum)]
    class PendulumBehavior : BehaviorSine
    {
        int targetVertex1;
        int targetVertex2;

        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            frequency = data.defaults.pendFrequency;
            amplitude = data.defaults.pendAmplitude;
            waveSize = data.defaults.pendWaveSize;

            if (data.defaults.pendInverted)
            {
                //anchored at the bottom
                targetVertex1 = 0;
                targetVertex2 = 3;
            }
            else
            {
                //anchored at the top
                targetVertex1 = 1;
                targetVertex2 = 2;
            }
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            data.vertices.RotateChar(
                Mathf.Sin(-time.timeSinceStart * frequency + waveSize * charIndex) * amplitude,
                (data.vertices[targetVertex1] + data.vertices[targetVertex2]) / 2 //bottom center as their rotation pivot
                );
        }
    }

}