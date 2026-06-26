using UnityEngine;
using Febucci.Attributes;

namespace Febucci.UI.Core
{

    [System.Serializable]
    //Do not touch this script
    public class AppearanceDefaultValues
    {
        #region Default Effects' values
        private const float defDuration = .3f;
        [System.Serializable]
        public class Defaults
        {

            [PositiveValue] public float sizeDuration = defDuration;
            [Attributes.MinValue(0)] public float sizeAmplitude = 2;

            [PositiveValue] public float fadeDuration = defDuration;

            [PositiveValue] public float verticalExpandDuration = defDuration;
            public bool verticalFromBottom = false;

            [PositiveValue] public float horizontalExpandDuration = defDuration;
            [SerializeField] internal HorizontalExpandAppearance.ExpType horizontalExpandStart = HorizontalExpandAppearance.ExpType.Left;

            [PositiveValue] public float diagonalExpandDuration = defDuration;
            public bool diagonalFromBttmLeft = false;

            [NotZero] public Vector2 offsetDir = Vector2.one;
            [PositiveValue] public float offsetDuration = defDuration;
            [NotZero] public float offsetAmplitude = 1f;

            [PositiveValue] public float rotationDuration = defDuration;
            public float rotationStartAngle = 180;
        }


        [SerializeField, Header("Default Appearances")]
        public Defaults defaults = new Defaults();

        #endregion

        [SerializeField, Header("Preset Effects")]
        internal PresetAppearanceValues[] presets = new PresetAppearanceValues[0];
    }

    [System.Serializable]
    //Do not touch this script
    public class BehaviorDefaultValues
    {
        #region Default Effects' values

        [System.Serializable]
        public class Defaults
        {
            //wiggle
            [NotZero] public float wiggleAmplitude = 0.15f;
            [NotZero] public float wiggleFrequency = 7.67f;

            //wave
            [NotZero] public float waveFrequency = 4.78f;
            [NotZero] public float waveAmplitude = .2f;
            public float waveWaveSize = .18f;

            //rot
            [NotZero] public float angleSpeed = 180;
            public float angleDiffBetweenChars = 10;

            //swing
            [NotZero] public float swingAmplitude = 27.5f;
            [NotZero] public float swingFrequency = 5f;
            public float swingWaveSize = 0;

            //shake
            [NotZero] public float shakeStrength = 0.085f;
            [PositiveValue] public float shakeDelay = .04f;

            //size
            public float sizeAmplitude = 1.4f;
            [NotZero] public float sizeFrequency = 4.84f;
            public float sizeWaveSize = .18f;

            //slide
            [NotZero] public float slideAmplitude = 0.12f;
            [NotZero] public float slideFrequency = 5;
            public float slideWaveSize = 0;

            //bounce
            [NotZero] public float bounceAmplitude = .08f;
            [NotZero] public float bounceFrequency = 1f;
            public float bounceWaveSize = 0.08f;

            //rainb
            [NotZero] public float hueShiftSpeed = 0.8f;
            public float hueShiftWaveSize = 0.08f;

            //fade
            [PositiveValue] public float fadeDelay = 1.2f;

            //dangle
            [NotZero] public float dangleAmplitude = .13f;
            [NotZero] public float dangleFrequency = 2.41f;
            public float dangleWaveSize = 0.18f;
            public bool dangleAnchorBottom = false;

            //pendulum
            [NotZero] public float pendAmplitude = 25;
            [NotZero] public float pendFrequency = 3;
            public float pendWaveSize = .2f;
            public bool pendInverted = false;
        }

        [SerializeField, Header("Default Behaviors")]
        public Defaults defaults = new Defaults();

        #endregion

        [SerializeField, Header("Preset Effects")]
        internal PresetBehaviorValues[] presets = new PresetBehaviorValues[0];
    }

}