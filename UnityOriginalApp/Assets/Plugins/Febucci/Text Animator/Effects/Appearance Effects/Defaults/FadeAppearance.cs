using UnityEngine;

namespace Febucci.UI.Core
{
    [UnityEngine.Scripting.Preserve]
    [EffectInfo(tag: TAnimTags.ap_Fade)]
    class FadeAppearance : AppearanceBase
    {

        public override void SetDefaultValues(AppearanceDefaultValues data)
        {
            effectDuration = data.defaults.fadeDuration;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            //from transparent to real color
            data.colors.LerpUnclamped(Color.clear, Tween.EaseInOut(1 - (data.passedTime / effectDuration)));
        }
    }

}