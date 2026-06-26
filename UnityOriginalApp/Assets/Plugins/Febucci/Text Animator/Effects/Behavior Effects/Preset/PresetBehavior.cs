using UnityEngine;
namespace Febucci.UI.Core
{
    [UnityEngine.Scripting.Preserve]
    [EffectInfo(tag: "")]
    class PresetBehavior : BehaviorBase
    {
        bool enabled;

        //modifiers
        float timeSpeed;
        float weightMult;

        //management
        Matrix4x4 matrix;
        Vector3 offset;
        Quaternion rotationQua;

        float uniformEffectTime;

        bool hasTransformEffects;

        bool isOnOneCharacter;

        float weight = 1;
        EmissionControl emissionControl;

        PresetAppearance.ThreeAxisEffector movement;
        PresetAppearance.ThreeAxisEffector rotation;
        PresetAppearance.TwoAxisEffector scale;

        bool setColor;
        Color32 color;
        ColorCurve colorCurve;

        public override void SetDefaultValues(BehaviorDefaultValues data)
        {
            weightMult = 1;
            timeSpeed = 1;

            uniformEffectTime = 0;
            weight = 0;
            isOnOneCharacter = false;

            enabled = false;


            void AssignValues(PresetBehaviorValues result)
            {
                float showDuration = 0;
                emissionControl = result.emission;

                enabled = PresetAppearance.SetPreset(
                    false,
                    result,
                    ref movement,
                    ref showDuration,
                    ref rotation,
                    ref scale,
                    ref rotationQua,
                    ref hasTransformEffects,
                    ref setColor,
                    ref colorCurve);

                emissionControl.Initialize(showDuration);
            }

            PresetBehaviorValues values;

            //searches for local presets first, which override global presets
            if (TAnimBuilder.GetPresetFromArray(effectTag, data.presets, out values))
            {
                AssignValues(values);
                return;
            }

            //global presets
            if (TAnimBuilder.TryGetGlobalPresetBehavior(effectTag, out values))
            {
                AssignValues(values);
                return;
            }
        }

        public override void SetModifier(string modifierName, string modifierValue)
        {
            switch (modifierName)
            {
                case "f": //frequency, increases the time speed
                    ApplyModifierTo(ref timeSpeed, modifierValue);
                    break;

                case "a": //increase the amplitude
                    ApplyModifierTo(ref weightMult, modifierValue);
                    break;
            }
        }

        public override void Calculate()
        {
            if (!isOnOneCharacter)
                return;

            uniformEffectTime = emissionControl.IncreaseEffectTime(time.deltaTime * timeSpeed);

        }

        public override void ApplyEffect(ref CharacterData data, int charIndex)
        {
            if (!enabled)
                return;

            if (!isOnOneCharacter)
                isOnOneCharacter = data.passedTime > 0;

            weight = emissionControl.effectWeigth * weightMult;

            if (weight == 0) //no effect
                return;

            if (hasTransformEffects)
            {
                offset = (data.vertices[0] + data.vertices[2]) / 2f;

                //weighted rotation
                rotationQua.eulerAngles = rotation.EvaluateEffect(uniformEffectTime, charIndex) * weight;

                matrix.SetTRS(
                    movement.EvaluateEffect(uniformEffectTime, charIndex) * uniformIntensity * weight,
                    rotationQua,
                    Vector3.LerpUnclamped(Vector3.one, scale.EvaluateEffect(uniformEffectTime, charIndex), weight));

                for (byte i = 0; i < data.vertices.Length; i++)
                {
                    data.vertices[i] -= offset;
                    data.vertices[i] = matrix.MultiplyPoint3x4(data.vertices[i]);
                    data.vertices[i] += offset;
                }
            }

            if (setColor)
            {
                color = colorCurve.GetColor(uniformEffectTime, charIndex);
                data.colors.LerpUnclamped(color, Mathf.Clamp(weight, -1, 1));
            }

        }
    }
}