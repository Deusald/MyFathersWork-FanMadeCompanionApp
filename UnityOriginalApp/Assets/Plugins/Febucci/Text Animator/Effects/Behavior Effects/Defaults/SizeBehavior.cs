using UnityEngine;

namespace Febucci.UI.Core
{
    [UnityEngine.Scripting.Preserve]
    [EffectInfo(tag: TAnimTags.bh_Incr)]
    sealed class SizeBehavior : BehaviorSine
    {
        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            amplitude = data.defaults.sizeAmplitude * -1 + 1;
            frequency = data.defaults.sizeFrequency;
            waveSize = data.defaults.sizeWaveSize;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            data.vertices.LerpUnclamped(
                data.vertices.GetMiddlePos(),
                (Mathf.Cos(time.timeSinceStart* frequency + charIndex * waveSize) + 1) / 2f * amplitude);
        }
    }
}