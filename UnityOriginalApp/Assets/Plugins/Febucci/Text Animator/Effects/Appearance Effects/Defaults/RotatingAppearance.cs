using UnityEngine;

namespace Febucci.UI.Core
{
    [UnityEngine.Scripting.Preserve]
    [EffectInfo(tag: TAnimTags.ap_Rot)]
    class RotatingAppearance : AppearanceBase
    {

        float targetAngle;
        public override void SetDefaultValues(AppearanceDefaultValues data)
        {
            effectDuration = data.defaults.rotationDuration;
            targetAngle = data.defaults.rotationStartAngle;
        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {

            data.vertices.RotateChar(
                Mathf.Lerp(
                    targetAngle,
                    0,
                    Tween.EaseInOut(data.passedTime / effectDuration)
                    )
                );
        }

    }

}