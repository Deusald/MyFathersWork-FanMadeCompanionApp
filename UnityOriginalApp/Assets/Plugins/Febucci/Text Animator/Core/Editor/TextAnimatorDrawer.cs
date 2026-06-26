using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Assertions;

namespace Febucci.UI.Core.Editors
{
    [CustomEditor(typeof(TextAnimator))]
    class TextAnimatorDrawer : Editor
    {
        #region Utilties

        const string menuParent = "Tools/Febucci/TextAnimator/";
        const string linksCategory = "Links/";
        const string utilsCategory = "Utils/";

        [MenuItem(menuParent + utilsCategory + "Locate Global Data", false, 0)]
        static void LocateGlobalData()
        {
            var foundData = Resources.Load(TAnimGlobalDataScriptable.resourcesPath);
            if (foundData != null)
            {
                Selection.activeObject = foundData;
            }
            else
            {
                Debug.LogWarning($"Text Animator: No Scriptable data found, please create one in path {TAnimGlobalDataScriptable.resourcesPath}");
            }
        }

        [MenuItem(menuParent + linksCategory + "📄 Documentation", false, 0)]
        static void Documentation()
        {
            Application.OpenURL("https://www.textanimator.febucci.com/docs/");
        }

        [MenuItem(menuParent + linksCategory + "📅 Roadmap", false, 50)]
        static void Roadmap()
        {
            Application.OpenURL("https://www.textanimator.febucci.com/roadmap/");
        }

        [MenuItem(menuParent + linksCategory + "📝 Changelog", false, 51)]
        static void Changelog()
        {
            Application.OpenURL("https://www.textanimator.febucci.com/changelog/");
        }

        [MenuItem(menuParent + linksCategory + "🆘 Support", false, 52)]
        static void Support()
        {
            Application.OpenURL("https://www.textanimator.febucci.com/support/");
        }


        #endregion

        const string alertTextSizeDep = "This effect's strength changes with different sizes and fonts.";

#if UNITY_2018
        static readonly Color expandedColor = Color.white * .85f;
        static readonly Color notExpandedColor = Color.white * .7f;
#else
        static readonly Color expandedColor = Color.white * 1.3f;
        static readonly Color notExpandedColor = Color.white;
#endif

        static readonly Color errorColor = new Color(1, .6f, .6f);
        static readonly Color selectedShowColor = new Color(.7f, 1, .7f);
        static readonly Color sectionsColor = new Color(.95f, .95f, .95f);

        static GUIStyle boldFoldout = new GUIStyle();

        static string availableAppBuiltinTagsLongText;

        struct EffectValuePair
        {
            public string label;
            public string valueName;
        }

        #region Structs
        struct Effect
        {
            bool show;
            bool dependant; //if effect changes based on size
            string effectName;
            public string effectTag { get; private set; }

            List<SerializedProperty> properties;
            List<GUIContent> propLabels;

            public Effect(string effectName, string effectTag, bool dependant, SerializedProperty parentProperty, bool isAppearance, params EffectValuePair[] values)
            {
                this.dependant = dependant;
                //this.effectName = (dependant ? "[!] " : "") + effectName + ", <" + effectTag + '>';
                this.effectName = $"{effectName}, {(isAppearance ? '{' : '<')}{effectTag}{(isAppearance ? '}' : '>')}";
                this.effectTag = effectTag;
                show = false;

                properties = new List<SerializedProperty>();
                propLabels = new List<GUIContent>();

                for (int i = 0; i < values.Length; i++)
                {
                    properties.Add(parentProperty.FindPropertyRelative(values[i].valueName));
                    propLabels.Add(new GUIContent(values[i].label));
                }
            }

            public void Show()
            {
                //EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                StartToggleGroup(ref show, effectName);

                //if (GUILayout.Button(effectName, show ? EditorStyles.boldLabel : EditorStyles.label))
                //show = !show;

                GUI.backgroundColor = Color.white;

                if (show)
                {
                    if (dependant)
                    {
                        EditorGUILayout.LabelField(alertTextSizeDep, EditorStyles.centeredGreyMiniLabel);
                    }

                    for (int i = 0; i < properties.Count; i++)
                    {
                        EditorGUILayout.PropertyField(properties[i], propLabels[i]);
                    }
                }

                EndToggleGroup(show);

                //EditorGUILayout.EndVertical();
            }
        }

        const string docs_builtinEffects = "https://www.textanimator.febucci.com/docs/built-in-effects-list/";
        const string docs_customInspectorPage = "https://www.textanimator.febucci.com/docs/creating-effects-in-the-inspector/";

        internal abstract class BuiltinVariablesDrawer
        {
            string docsLink;
            string toggleLabel;

            bool draw;
            public bool isDrawing => draw;

            public BuiltinVariablesDrawer(string toggleLabel, string docsLink)
            {
                this.docsLink = docsLink;
                this.toggleLabel = toggleLabel;
                draw = false;
            }

            internal abstract void DrawBody();

            public void StartShowing()
            {
                StartVerticalToggleGroup(ref draw, toggleLabel, docsLink);
            }

            public void StopShowing()
            {

                //show default toggle
                //GUI.backgroundColor = sectionsColor;
                //EditorGUILayout.BeginVertical(EditorStyles.helpBox);
                //GUI.backgroundColor = Color.white;

                EndVerticalToggleGroup(draw);
            }

            public void ShowFull()
            {
                StartShowing();

                if (draw)
                {
                    DrawBody();
                }

                StopShowing();
            }
        }

        /// <summary>
        /// Class that draws the component's default appearance effects
        /// </summary>
        internal class AppearanceDefaultEffects : BuiltinVariablesDrawer
        {
            Effect appSize;
            Effect appFade;
            Effect appVertExp;
            Effect appHoriExp;
            Effect appDiagExp;
            Effect appOffset;
            Effect appRot;

            public AppearanceDefaultEffects(SerializedProperty defaults) : base("Built-in appearances", docs_builtinEffects + "#appearance-effects")
            {
                appSize = new Effect(
                    "Size",
                    TAnimTags.ap_Size,
                    false,
                    defaults,
                    true,
                    new EffectValuePair { valueName = "sizeDuration", label = "Duration" },
                    new EffectValuePair { valueName = "sizeAmplitude", label = "Amplitude" }
                    );

                appFade = new Effect(
                    "Fade",
                    TAnimTags.ap_Fade,
                    false,
                    defaults,
                    true,
                    new EffectValuePair { valueName = "fadeDuration", label = "Duration" }
                    );

                appVertExp = new Effect(
                    "Vertical Expand",
                    TAnimTags.ap_VertExp,
                    false,
                    defaults,
                    true,
                    new EffectValuePair { valueName = "verticalExpandDuration", label = "Duration" },
                    new EffectValuePair { valueName = "verticalFromBottom", label = "FromBottom" }
                    );

                appHoriExp = new Effect(
                    "Horizontal Expand",
                    TAnimTags.ap_HoriExp,
                    false,
                    defaults,
                    true,
                    new EffectValuePair { valueName = "horizontalExpandDuration", label = "Duration" },
                    new EffectValuePair { valueName = "horizontalExpandStart", label = "Start" }
                    );

                appDiagExp = new Effect(
                    "Diagonal Expand",
                    TAnimTags.ap_DiagExp,
                    false,
                    defaults,
                    true,
                    new EffectValuePair { valueName = "diagonalExpandDuration", label = "Duration" },
                    new EffectValuePair { valueName = "diagonalFromBttmLeft", label = "FromBottomLeft" }
                    );

                appOffset = new Effect(
                    "Offset",
                    TAnimTags.ap_Offset,
                    true,
                    defaults,
                    true,
                    new EffectValuePair { valueName = "offsetDuration", label = "Duration" },
                    new EffectValuePair { valueName = "offsetDir", label = "Direction" },
                    new EffectValuePair { valueName = "offsetAmplitude", label = "Amplitude" }
                    );

                appRot = new Effect(
                    "Rotation",
                    TAnimTags.ap_Rot,
                    false,
                    defaults,
                    true,
                    new EffectValuePair { valueName = "rotationDuration", label = "Duration" },
                    new EffectValuePair { valueName = "rotationStartAngle", label = "StartAngle" }
                    );
            }

            internal override void DrawBody()
            {
                appOffset.Show();
                appSize.Show();
                appFade.Show();
                appVertExp.Show();
                appHoriExp.Show();
                appDiagExp.Show();
                appRot.Show();
            }
        }

        /// <summary>
        /// Draws default behavior effects
        /// </summary>
        internal class BehaviorDefaultEffects : BuiltinVariablesDrawer
        {
            Effect behWiggle;
            Effect behWave;
            Effect behRotation;
            Effect behSwing;
            Effect behShake;
            Effect behSize;
            Effect behSlide;
            Effect behBounce;
            Effect behRainbow;
            Effect behFade;
            Effect behDangle;
            Effect behPendulum;

            public BehaviorDefaultEffects(SerializedProperty defaultValues) : base("Built-in behaviors", docs_builtinEffects + "#behavior-effects")
            {

                behWiggle = new Effect(
                    "Wiggle",
                    TAnimTags.bh_Wiggle,
                    true,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "wiggleAmplitude", label = "Amplitude" },
                    new EffectValuePair { valueName = "wiggleFrequency", label = "Frequency" }
                    ); ;

                behWave = new Effect(
                    "Wave",
                    TAnimTags.bh_Wave,
                    true,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "waveAmplitude", label = "Amplitude" },
                    new EffectValuePair { valueName = "waveFrequency", label = "Frequency" },
                    new EffectValuePair { valueName = "waveWaveSize", label = "WaveSize" }
                    ); ;

                behRotation = new Effect(
                    "Rotation",
                    TAnimTags.bh_Rot,
                    false,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "angleSpeed", label = "Speed" },
                    new EffectValuePair { valueName = "angleDiffBetweenChars", label = "AngleDiff" }
                    ); ;

                behSwing = new Effect(
                    "Swing",
                    TAnimTags.bh_Swing,
                    false,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "swingAmplitude", label = "Amplitude" },
                    new EffectValuePair { valueName = "swingFrequency", label = "Frequency" },
                    new EffectValuePair { valueName = "swingWaveSize", label = "WaveSize" }
                    ); ;

                behShake = new Effect(
                    "Shake",
                    TAnimTags.bh_Shake,
                    true,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "shakeStrength", label = "Amplitude" },
                    new EffectValuePair { valueName = "shakeDelay", label = "Delay" }
                    ); ;

                behSize = new Effect(
                    "Increase",
                    TAnimTags.bh_Incr,
                    false,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "sizeAmplitude", label = "Amplitude" },
                    new EffectValuePair { valueName = "sizeFrequency", label = "Frequency" },
                    new EffectValuePair { valueName = "sizeWaveSize", label = "WaveSize" }
                    ); ;

                behSlide = new Effect(
                    "Slide",
                    TAnimTags.bh_Slide,
                    true,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "slideAmplitude", label = "Amplitude" },
                    new EffectValuePair { valueName = "slideFrequency", label = "Frequency" },
                    new EffectValuePair { valueName = "slideWaveSize", label = "WaveSize" }
                    ); ;

                behBounce = new Effect(
                    "Bounce",
                    TAnimTags.bh_Bounce,
                    true,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "bounceAmplitude", label = "Amplitude" },
                    new EffectValuePair { valueName = "bounceFrequency", label = "Frequency" },
                    new EffectValuePair { valueName = "bounceWaveSize", label = "WaveSize" }
                    ); ;

                behRainbow = new Effect(
                    "Rainbow",
                    TAnimTags.bh_Rainb,
                    false,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "hueShiftSpeed", label = "HueShiftSpeed" },
                    new EffectValuePair { valueName = "hueShiftWaveSize", label = "WaveSize" }
                    ); ;

                behFade = new Effect(
                    "Fade",
                    TAnimTags.bh_Fade,
                    false,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "fadeDelay", label = "Delay" }
                    );

                behDangle = new Effect(
                    "Dangle",
                    TAnimTags.bh_Dangle,
                    true,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "dangleAmplitude", label = "Amplitude" },
                    new EffectValuePair { valueName = "dangleFrequency", label = "Frequency" },
                    new EffectValuePair { valueName = "dangleWaveSize", label = "Wave Size" },
                    new EffectValuePair { valueName = "dangleAnchorBottom", label = "Anchor Bottom" }
                    );

                behPendulum = new Effect(
                    "Pendulum",
                    TAnimTags.bh_Pendulum,
                    false,
                    defaultValues,
                    false,
                    new EffectValuePair { valueName = "pendAmplitude", label = "Amplitude" },
                    new EffectValuePair { valueName = "pendFrequency", label = "Frequency" },
                    new EffectValuePair { valueName = "pendWaveSize", label = "Wave Size" },
                    new EffectValuePair { valueName = "pendInverted", label = "Inverted" }
                    );
            }

            internal override void DrawBody()
            {
                behWiggle.Show();
                behShake.Show();
                behWave.Show();
                behSlide.Show();
                behBounce.Show();

                behRotation.Show();
                behSwing.Show();
                behSize.Show();
                behRainbow.Show();
                behFade.Show();
                behDangle.Show();
                behPendulum.Show();

            }
        }

        /// <summary>
        /// Manages a single preset (behavior or appearance) 
        /// </summary>

        internal class UserPresetDrawer
        {
            public bool show;
            public bool wantsToRemove;
            bool isAppearance;
            public string getName => isAppearance ? ('{' + effectTag.stringValue + '}') : ('<' + effectTag.stringValue + '>');

            SerializedProperty effectTag;

            EmissionCurveDrawer emission;

            FloatCurveDrawer movementX;
            FloatCurveDrawer movementY;
            FloatCurveDrawer movementZ;

            FloatCurveDrawer scaleX;
            FloatCurveDrawer scaleY;

            FloatCurveDrawer rotX;
            FloatCurveDrawer rotY;
            FloatCurveDrawer rotZ;

            ColorCurveDrawer color;

            public UserPresetDrawer(SerializedProperty parent, bool isAppearance)
            {
                effectTag = parent.FindPropertyRelative("effectTag");

                this.isAppearance = isAppearance;
                this.show = false;
                this.wantsToRemove = false;

                if (!isAppearance)
                {
                    emission = new EmissionCurveDrawer(parent.FindPropertyRelative("emission"));
                }

                movementX = new FloatCurveDrawer(parent.FindPropertyRelative("movementX"), "Movement X", true, isAppearance, Color.red);
                movementY = new FloatCurveDrawer(parent.FindPropertyRelative("movementY"), "Movement Y", true, isAppearance, Color.green);
                movementZ = new FloatCurveDrawer(parent.FindPropertyRelative("movementZ"), "Movement Z", true, isAppearance, Color.cyan);

                scaleX = new FloatCurveDrawer(parent.FindPropertyRelative("scaleX"), "Scale X", false, isAppearance, Color.red);
                scaleY = new FloatCurveDrawer(parent.FindPropertyRelative("scaleY"), "Scale Y", false, isAppearance, Color.green);

                rotX = new FloatCurveDrawer(parent.FindPropertyRelative("rotX"), "Rotation X", false, isAppearance, Color.red);
                rotY = new FloatCurveDrawer(parent.FindPropertyRelative("rotY"), "Rotation Y", false, isAppearance, Color.green);
                rotZ = new FloatCurveDrawer(parent.FindPropertyRelative("rotZ"), "Rotation Z", false, isAppearance, Color.cyan);

                color = new ColorCurveDrawer(parent.FindPropertyRelative("color"), "Color");
            }

            public void ResetValues()
            {
                effectTag.stringValue = string.Empty;

                int appearanceOffset = isAppearance ? 3 : 0;

                if (!isAppearance)
                {
                    emission.ResetValues();
                }

                movementY.ResetValues(0 + appearanceOffset);
                movementZ.ResetValues(0 + appearanceOffset);
                movementX.ResetValues(0 + appearanceOffset);

                scaleX.ResetValues(1 + appearanceOffset);
                scaleY.ResetValues(1 + appearanceOffset);

                rotX.ResetValues(2 + appearanceOffset);
                rotY.ResetValues(2 + appearanceOffset);
                rotZ.ResetValues(2 + appearanceOffset);

                color.ResetValues(isAppearance);
            }

            public void Show()
            {
                //EditorGUILayout.BeginVertical("box");
                bool notLongEnough = !TextUtilities.IsTagLongEnough(effectTag.stringValue);
                //tag is short
                if (notLongEnough)
                {
                    GUI.backgroundColor = errorColor;
                }

                EditorGUI.BeginChangeCheck();
                if (Application.isPlaying)
                {
                    GUI.enabled = false;
                }
                EditorGUILayout.PropertyField(effectTag);
                if (notLongEnough)
                {
                    EditorGUILayout.LabelField("[!] This tag is too short.", EditorStyles.miniLabel);
                }

                if (Application.isPlaying)
                {
                    EditorGUILayout.LabelField("(You can't edit the tag IDs while in playmode.)", EditorStyles.centeredGreyMiniLabel);
                    GUI.enabled = true;
                }

                GUI.backgroundColor = Color.white;

                if (EditorGUI.EndChangeCheck())
                {
                    effectTag.stringValue = effectTag.stringValue.Replace(" ", "");
                }

                if (!isAppearance)
                {
                    //EditorGUILayout.BeginVertical("box");
                    EditorGUILayout.LabelField("--Emission--", EditorStyles.centeredGreyMiniLabel);
                    emission.Show();
                    //EditorGUILayout.EndVertical();
                }

                EditorGUILayout.Space();
                GUI.enabled = false;
                EditorGUILayout.LabelField("Enable or disable effect modules in order to modify letters", EditorStyles.wordWrappedMiniLabel);
                GUI.enabled = true;

                //EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("--Movement Modules--", EditorStyles.centeredGreyMiniLabel);
                movementX.Show();
                movementY.Show();
                movementZ.Show();
                // EditorGUILayout.EndVertical();

                //EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("--Scale Modules--", EditorStyles.centeredGreyMiniLabel);
                scaleX.Show();
                scaleY.Show();
                //EditorGUILayout.EndVertical();

                //EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("--Rotation Modules--", EditorStyles.centeredGreyMiniLabel);
                rotX.Show();
                rotY.Show();
                rotZ.Show();
                //EditorGUILayout.EndVertical();

                //EditorGUILayout.BeginVertical("box");
                EditorGUILayout.LabelField("--Color Module--", EditorStyles.centeredGreyMiniLabel);
                color.Show();
                //EditorGUILayout.EndVertical();


                // EditorGUILayout.EndVertical();
            }
        }

        class FloatCurveDrawer
        {
            string name;
            bool sizeDependant;
            SerializedProperty enabled;
            SerializedProperty amplitude;
            SerializedProperty curve;
            SerializedProperty charsTimeOffset;
            GUIContent curveLabel;
            Color curveColor;

            string curveDescription;

            public FloatCurveDrawer(SerializedProperty parent, string name, bool sizeDependant, bool isAppearance, Color curveColor)
            {
                curveLabel = new GUIContent(isAppearance ? "Decay over time" : "Intensity over time");
                this.sizeDependant = sizeDependant;
                this.name = (sizeDependant ? "[!] " : "") + name;
                this.curveColor = curveColor;

                amplitude = parent.FindPropertyRelative("amplitude");
                curve = parent.FindPropertyRelative("curve");
                enabled = parent.FindPropertyRelative("enabled");
                charsTimeOffset = parent.FindPropertyRelative("charsTimeOffset");
                CalculateCurveStats();
            }

            public void ResetValues(int type)
            {
                bool isAppearance = type >= 3;

                switch (type)
                {
                    //mov
                    default:
                    case 0:

                        amplitude.floatValue = 1;

                        curve.animationCurveValue = new AnimationCurve(
                                new Keyframe(0, 0, -5.4f, -5.4f),
                                new Keyframe(.25f, -1, -1, -1),
                                new Keyframe(.75f, 1, -1, -1),
                                new Keyframe(1, 0, -5.4f, -5.4f)
                            )
                        {
                            postWrapMode = WrapMode.Loop,
                        };
                        break;

                    //scale
                    case 1:
                        amplitude.floatValue = 2;

                        curve.animationCurveValue = new AnimationCurve(
                            new Keyframe(0, .5f),
                            new Keyframe(.5f, 1f),
                            new Keyframe(1, .5f)
                        )
                        {
                            postWrapMode = WrapMode.Loop,
                        };

                        break;

                    //rot
                    case 2:
                        amplitude.floatValue = 35; //angle of 35

                        curve.animationCurveValue = new AnimationCurve(
                            new Keyframe(0, 0, -5.4f, -5.4f),
                            new Keyframe(.25f, -1, -1, -1),
                            new Keyframe(.75f, 1, -1, -1),
                            new Keyframe(1, 0, -5.4f, -5.4f)
                        )
                        {
                            postWrapMode = WrapMode.Loop
                        };
                        break;

                    //app mov
                    case 3:

                        amplitude.floatValue = 1;

                        curve.animationCurveValue = new AnimationCurve(
                            new Keyframe(0, 0),
                            new Keyframe(1, 1)
                        )
                        {
                            postWrapMode = WrapMode.Once
                        };

                        break;

                    //app scale
                    case 4:
                        amplitude.floatValue = 2;

                        curve.animationCurveValue = new AnimationCurve(
                            new Keyframe(0, 0),
                            new Keyframe(1, 1)
                        )
                        {
                            postWrapMode = WrapMode.Once
                        };

                        break;

                    //app rot
                    case 5:
                        amplitude.floatValue = 35; //angle of 35

                        curve.animationCurveValue = new AnimationCurve(
                            new Keyframe(0, 0),
                            new Keyframe(1, 1)
                        )
                        {
                            postWrapMode = WrapMode.Once
                        };
                        break;

                }

                charsTimeOffset.floatValue = 0;
            }

            void CalculateCurveStats()
            {
                curveDescription = $"Duration: {curve.animationCurveValue.CalculateCurveDuration()}\n{curve.animationCurveValue.preWrapMode} - {curve.animationCurveValue.postWrapMode}";

            }

            public void Show()
            {
                enabled.boolValue = EditorGUILayout.ToggleLeft(name, enabled.boolValue);

                if (enabled.boolValue)
                {
                    //EditorGUI.indentLevel++;
                    if (sizeDependant)
                    {
                        EditorGUILayout.LabelField(alertTextSizeDep, EditorStyles.centeredGreyMiniLabel);
                    }

                    EditorStyles.wordWrappedMiniLabel.alignment = TextAnchor.MiddleCenter;
                    EditorGUILayout.LabelField(curveDescription, EditorStyles.wordWrappedMiniLabel);
                    EditorStyles.wordWrappedMiniLabel.alignment = TextAnchor.UpperLeft;

                    CalculateCurveStats(); //alyways calculating, because user may Undo and the duration could change


                    curve.animationCurveValue = EditorGUILayout.CurveField(curveLabel, curve.animationCurveValue, curveColor, Rect.zero);
                    //EditorGUILayout.PropertyField(curve, curveLabel);

                    EditorGUILayout.PropertyField(amplitude);
                    EditorGUILayout.PropertyField(charsTimeOffset);
                    GUILayout.Space(4);
                    //EditorGUILayout.Space();

                    //EditorGUI.indentLevel--;
                }
            }
        }
        [System.Serializable]
        class ColorCurveDrawer
        {

            string name;
            SerializedProperty enabled;
            SerializedProperty gradient;
            SerializedProperty duration;
            SerializedProperty charsTimeOffset;

            public ColorCurveDrawer(SerializedProperty parent, string name)
            {
                this.name = name;
                gradient = parent.FindPropertyRelative("gradient");
                enabled = parent.FindPropertyRelative("enabled");
                duration = parent.FindPropertyRelative("duration");
                charsTimeOffset = parent.FindPropertyRelative("charsTimeOffset");
            }
            public void ResetValues(bool isAppearance)
            {
                //TODO Find a way to show serialized property gradients

                if (isAppearance)
                {
                    /*
                    gradient = new GradientColorKey[] {
                        new GradientColorKey(Color.cyan, 0),
                        new GradientColorKey(Color.black, 1)
                    };

                    gradient.alphaKeys = new GradientAlphaKey[] {
                        new GradientAlphaKey(0, 0),
                        new GradientAlphaKey(1, 1)
                    };
                    */

                    duration.floatValue = 1;
                }
                else
                {/*
                    gradient.colorKeys = new GradientColorKey[] {
                    new GradientColorKey(Color.black, 0),
                    new GradientColorKey(Color.red, .5f),
                    new GradientColorKey(Color.black, 1)
                };

                    gradient.alphaKeys = new GradientAlphaKey[] {
                    new GradientAlphaKey(1, 0),
                    new GradientAlphaKey(1, 1)
                };
                */
                    duration.floatValue = 1;
                }

                charsTimeOffset.floatValue = 0;
            }

            public void Show()
            {
                enabled.boolValue = EditorGUILayout.ToggleLeft(name, enabled.boolValue);

                if (enabled.boolValue)
                {
                    EditorGUILayout.PropertyField(gradient);
                    EditorGUILayout.PropertyField(duration);
                    EditorGUILayout.PropertyField(charsTimeOffset);
                    EditorGUILayout.Space();
                }
            }

        }

        class EmissionCurveDrawer
        {
            string infoText;

            SerializedProperty cycles;
            SerializedProperty overrideDuration;
            SerializedProperty attackCurve;
            SerializedProperty decayCurve;
            SerializedProperty continueForever;

            public EmissionCurveDrawer(SerializedProperty parent)
            {
                this.infoText = string.Empty;
                attackCurve = parent.FindPropertyRelative("attackCurve");
                decayCurve = parent.FindPropertyRelative("decayCurve");
                cycles = parent.FindPropertyRelative("cycles");
                overrideDuration = parent.FindPropertyRelative("overrideDuration");
                continueForever = parent.FindPropertyRelative("continueForever");
            }

            public void ResetValues()
            {
                attackCurve.animationCurveValue = new AnimationCurve(
                    new Keyframe(0, 0),
                    new Keyframe(1, 1));

                continueForever.boolValue = true;

                decayCurve.animationCurveValue = new AnimationCurve(
                    new Keyframe(0, 1),
                    new Keyframe(1, 0));
            }

            public void Show()
            {
                infoText = $"Repeats { ((continueForever.boolValue || cycles.intValue <= 0) ? "forever" : (cycles.intValue + " time(s)"))}";

                GUI.enabled = false;
                EditorGUILayout.LabelField(infoText, EditorStyles.wordWrappedMiniLabel);
                EditorGUILayout.LabelField("Pro tip: Set the 'attack curve' keys to 1 to start the effect immediately", EditorStyles.wordWrappedMiniLabel);
                GUI.enabled = true;

                EditorGUILayout.CurveField(attackCurve, Color.yellow, Rect.zero);

                EditorGUILayout.PropertyField(continueForever);
                if (!continueForever.boolValue)
                {
                    EditorGUILayout.PropertyField(overrideDuration);
                    EditorGUILayout.CurveField(decayCurve, Color.yellow, Rect.zero);
                    EditorGUILayout.PropertyField(cycles);
                }

            }
        }

        #endregion

        #region Variables

        GUIContent easyIntegrationLabel = new GUIContent("Use Easy Integration");
        SerializedProperty triggerTypeWriter;
        SerializedProperty timeScale;
        SerializedProperty tags_fallbackBehaviors;
        SerializedProperty tags_fallbackAppearances;

        SerializedProperty behaviorValues;
        SerializedProperty behavDef;
        SerializedProperty behLocalPresetsArray;

        SerializedProperty appLocalPresetsArray;


        SerializedProperty scriptable_globalBehaviorsValues;
        SerializedProperty scriptable_globalAppearancesValues;
        GUIContent scriptableBuiltin_GUI = new GUIContent("Shared Values");


        SerializedProperty effectIntensity;
        SerializedProperty useDynamicScaling;
        SerializedProperty referenceFontSize;

        SerializedProperty appearanceValues;

        UserPresetDrawer[] behPresets = new UserPresetDrawer[0];
        UserPresetDrawer[] appPresets = new UserPresetDrawer[0];

        AppearanceDefaultEffects appDefaultPreset;
        BehaviorDefaultEffects behDefaultDrawer;

        bool behShowPresets;
        bool appShowPresets;

        bool panel_editEffects;
        bool panel_editSettings;

        bool panel_editBehaviors;
        bool panel_editDefaultAppearances;
        bool panel_editDefaultBehaviors;
        bool panel_editAppearances;
        #endregion

        public enum Show
        {
            Behaviors,
            Appearances
        }

        void MatchPresetsDrawersWithComponent()
        {
            MatchPresetsDrawersWithComponent(ref behPresets, behLocalPresetsArray, false);
            MatchPresetsDrawersWithComponent(ref appPresets, appLocalPresetsArray, true);
        }

        static void MatchPresetsDrawersWithComponent(ref UserPresetDrawer[] drawers, SerializedProperty arrayProperty, bool isAppearance)
        {
            if (drawers.Length != arrayProperty.arraySize)
            {
                drawers = new UserPresetDrawer[arrayProperty.arraySize];

                for (int i = 0; i < arrayProperty.arraySize; i++)
                {
                    drawers[i] = new UserPresetDrawer(arrayProperty.GetArrayElementAtIndex(i), isAppearance);
                }
            }
        }

        static void EditFallbackEffects(ref SerializedProperty tagsContainer, bool isAppearance)
        {
            //avaiable tags

            GUI.enabled = false;

            if (isAppearance)
                EditorGUILayout.LabelField("How many Appearance effects will be applied to a letter if there are no other Appearance effects already?", EditorStyles.wordWrappedMiniLabel);
            else
                EditorGUILayout.LabelField("How many Behavior effects will be applied to a letter, if there are no other Behavior effects already?", EditorStyles.wordWrappedMiniLabel);

            GUI.enabled = true;

            //EditorGUILayout.LabelField($"Available Built-in tags: {availableAppBuiltinTagsLongText}", EditorStyles.wordWrappedMiniLabel);

            if (Application.isPlaying)
                GUI.enabled = false;

            tagsContainer.arraySize = Mathf.Max(EditorGUILayout.IntField("Effects Count:", tagsContainer.arraySize), 0);

            if (tagsContainer.arraySize > 0)
            {
                GUI.enabled = false;
                EditorGUILayout.LabelField($"Write one {(isAppearance ? "Appearance" : "Behavior")} tag per array element. (built-in or custom effects tags are both accepted, eg. 'fade')", EditorStyles.wordWrappedMiniLabel);
                GUI.enabled = true;
                EditorGUI.indentLevel++;

                SerializedProperty temp;
                for (int i = 0; i < tagsContainer.arraySize; i++)
                {
                    temp = tagsContainer.GetArrayElementAtIndex(i);

                    EditorGUI.BeginChangeCheck();
                    EditorGUILayout.PropertyField(temp, new GUIContent($"Effect #{i}"));

                    if (EditorGUI.EndChangeCheck() && temp.stringValue.Length > 0)
                    {
                        temp.stringValue = temp.stringValue.Replace("{", "").Replace("}", "").Replace(" ", "");
                    }
                }

                EditorGUI.indentLevel--;
            }

            //EditorGUILayout.PropertyField(tagsContainer, tagsContainerLabel, true);

            GUI.backgroundColor = Color.white;

            GUI.enabled = true;
        }

        private void OnEnable()
        {
            effectIntensity = serializedObject.FindProperty("effectIntensityMultiplier");
            referenceFontSize = serializedObject.FindProperty("referenceFontSize");
            useDynamicScaling = serializedObject.FindProperty("useDynamicScaling");

            triggerTypeWriter = serializedObject.FindProperty("triggerAnimPlayerOnChange");
            timeScale = serializedObject.FindProperty("timeScale");
            tags_fallbackBehaviors = serializedObject.FindProperty("tags_fallbackBehaviors");

            scriptable_globalAppearancesValues = serializedObject.FindProperty("scriptable_globalAppearancesValues");
            scriptable_globalBehaviorsValues = serializedObject.FindProperty("scriptable_globalBehaviorsValues");

            availableAppBuiltinTagsLongText = string.Empty;
            for (int i = 0; i < TAnimTags.defaultAppearances.Length; i++)
            {
                availableAppBuiltinTagsLongText += TAnimTags.defaultAppearances[i] + ", ";
            }

            behaviorValues = serializedObject.FindProperty("behaviorValues");

            #region Default Behaviors
            behavDef = behaviorValues.FindPropertyRelative("defaults");
            behDefaultDrawer = new BehaviorDefaultEffects(behavDef);


            #endregion

            #region Default Appearances
            appearanceValues = serializedObject.FindProperty("appearancesContainer");
            tags_fallbackAppearances = appearanceValues.FindPropertyRelative("tags");
            appDefaultPreset = new AppearanceDefaultEffects(appearanceValues.FindPropertyRelative("values").FindPropertyRelative("defaults"));

            #endregion


            behLocalPresetsArray = behaviorValues.FindPropertyRelative("presets");

            appLocalPresetsArray = appearanceValues.FindPropertyRelative("values").FindPropertyRelative("presets");
            MatchPresetsDrawersWithComponent();

        }

        #region Styles Methods
        public static void WhatToShowButton(ref Show currentPanel)
        {
            void ShowButtonFor(ref Show panel, Show target)
            {
                string name = target == Show.Appearances ? "Edit Appearances" : "Edit Behaviors";
                if (panel == target)
                    GUI.backgroundColor = selectedShowColor;

                EditorGUILayout.BeginVertical(EditorStyles.helpBox, GUILayout.Height(30));

                if (GUILayout.Button(name, EditorStyles.boldLabel))
                {
                    panel = target;
                }

                EditorGUILayout.EndVertical();

                GUI.backgroundColor = Color.white;
            }

            EditorGUILayout.BeginHorizontal();
            ShowButtonFor(ref currentPanel, Show.Behaviors);
            ShowButtonFor(ref currentPanel, Show.Appearances);
            EditorGUILayout.EndHorizontal();
        }

        void WhatToShowTitle(string content)
        {
            EditorGUILayout.LabelField(content, EditorStyles.centeredGreyMiniLabel);
        }
        #endregion

        static void StartVerticalToggleGroup(ref bool value, string label, string documentationLink)
        {
            GUI.backgroundColor = value ? expandedColor : notExpandedColor;
            EditorGUILayout.BeginVertical("box");

            EditorGUILayout.BeginHorizontal();
            StartToggleGroup(ref value, label);

            if (documentationLink.Length > 0 && value)
            {
                if (GUILayout.Button(EditorGUIUtility.IconContent("_Help"), EditorStyles.label, GUILayout.Width(24)))
                {
                    Application.OpenURL(documentationLink);
                }
            }

            EditorGUILayout.EndHorizontal();

            GUI.backgroundColor = Color.white;


        }

        static void EndVerticalToggleGroup(bool value)
        {
            EndToggleGroup(value);
            EditorGUILayout.EndVertical();
        }

        static void StartToggleGroup(ref bool value, string label, GUIStyle style)
        {
            //GUI.backgroundColor = currentGroupLevel % 2 == 0 ? notExpandedColor : expandedColor;
            //GUI.backgroundColor = Color.white;

            value = EditorGUILayout.Foldout(value, label, true, style);

            EditorGUI.indentLevel++;
        }


        static void StartToggleGroup(ref bool value, string label)
        {
            StartToggleGroup(ref value, label, EditorStyles.foldout);
        }

        static void EndToggleGroup(bool value)
        {
            EditorGUI.indentLevel--;
        }

        internal static void ShowPresets(ref UserPresetDrawer[] userPresets, ref bool canShow, ref SerializedProperty arrayProperty, bool isAppearance, bool isGlobal)
        {
            Assert.IsNotNull(userPresets, "User presets array is null");
            Assert.IsNotNull(arrayProperty, "Array property is null");

            EditorGUI.BeginChangeCheck();


            StartVerticalToggleGroup(ref canShow, $"Create/edit {(isGlobal ? "global" : "local")} {(isAppearance ? "appearances" : "behaviors")} [{arrayProperty.arraySize} created]", docs_customInspectorPage);

            #region CanShow variable changed
            if (EditorGUI.EndChangeCheck())
            {
                //Resets "confirmation to delete effect" button
                for (int i = 0; i < userPresets.Length; i++)
                {
                    userPresets[i].wantsToRemove = false;
                }
            }
            #endregion

            #region Shows Preset
            if (canShow)
            {
                //Checks for error
                MatchPresetsDrawersWithComponent(ref userPresets, arrayProperty, isAppearance);

                for (int i = 0; i < userPresets.Length; i++)
                {

                    #region Header
                    if (userPresets[i].show)
                        GUI.backgroundColor = expandedColor;
                    else
                        GUI.backgroundColor = notExpandedColor;

                    //EditorGUILayout.BeginVertical(EditorStyles.helpBox);

                    GUI.backgroundColor = Color.white;

                    if (userPresets[i].show)
                    {
                        EditorGUILayout.BeginHorizontal();
                    }


                    #endregion

                    StartToggleGroup(ref userPresets[i].show, $"{userPresets[i].getName}", userPresets[i].show ? boldFoldout : EditorStyles.foldout);
                    #region Body

                    if (userPresets[i].show)
                    {
                        if (Application.isPlaying)
                            GUI.enabled = false;

                        if (GUILayout.Button(userPresets[i].wantsToRemove ? "Confirm?" : "Remove?", EditorStyles.miniButtonRight, GUILayout.Width(85)))
                        {
                            //Confirms remove
                            if (userPresets[i].wantsToRemove)
                            {
                                arrayProperty.DeleteArrayElementAtIndex(i);
                                MatchPresetsDrawersWithComponent(ref userPresets, arrayProperty, isAppearance);
                                break;
                            }
                            else //asks for remove
                            {
                                userPresets[i].wantsToRemove = true;
                            }
                        }

                        GUI.enabled = true;

                        EditorGUILayout.EndHorizontal();

                        GUI.backgroundColor = Color.white;

                        //can add modules only if it's a local effect or player is in edit mode
                        userPresets[i].Show();
                    }

                    #endregion

                    EndToggleGroup(userPresets[i].show);
                }

                #region Add New
                if (Application.isPlaying) //prevents adding new preset if in play mode
                    GUI.enabled = false;

                bool foldout = false;
                if (EditorGUILayout.Foldout(foldout, $"[+ Add new {(isAppearance ? "appearance" : "behavior")} effect]", true) && !Application.isPlaying)
                {
                    arrayProperty.InsertArrayElementAtIndex(Mathf.Clamp(arrayProperty.arraySize - 1, 0, arrayProperty.arraySize));
                    MatchPresetsDrawersWithComponent(ref userPresets, arrayProperty, isAppearance);
                    userPresets[userPresets.Length - 1].ResetValues();
                }

                GUI.enabled = true;
                #endregion
            }

            #endregion

            EndVerticalToggleGroup(canShow);
        }

        bool boldFoldoutInitialized = false;
        public override void OnInspectorGUI()
        {
            if (!boldFoldoutInitialized)
            {
                boldFoldoutInitialized = true; //workaround or unity throws null exception
                boldFoldout = new GUIStyle(EditorStyles.foldout) { fontStyle = FontStyle.Bold };
            }
            //EditorGUILayout.LabelField

            //>Settings
            //-Use easy integration
            //-Dynamic Scaling
            //-time scale

            //Edit effects
            //-Effect intensity multiplier
            //>default effects
            //>preset effects
            //>edit custom C# effects 

            //Extra


            //Main Settings
            {
                EditorGUILayout.LabelField("Main Settings", EditorStyles.boldLabel);
                EditorGUI.indentLevel++;

                {

                    //Easy Integration
                    {
                        EditorGUILayout.PropertyField(triggerTypeWriter, easyIntegrationLabel);

                        if (triggerTypeWriter.boolValue)
                        {
                            EditorGUILayout.HelpBox("Be sure to add a TextAnimatorPlayer component", MessageType.None);
                        }
                    }

                    //Dynamic Scaling
                    {
                        EditorGUI.BeginChangeCheck();
                        EditorGUILayout.PropertyField(useDynamicScaling);
                        if (EditorGUI.EndChangeCheck())
                        {
                            if (useDynamicScaling.boolValue)
                            {
                                if (referenceFontSize.floatValue <= 0)
                                {
                                    var tmproText = (target as TextAnimator)?.GetComponent<TMPro.TMP_Text>();
                                    if (tmproText.text != null)
                                    {
                                        referenceFontSize.floatValue = tmproText.fontSize;
                                    }
                                }
                            }
                        }

                        if (useDynamicScaling.boolValue)
                            EditorGUILayout.PropertyField(referenceFontSize);
                    }

                    EditorGUILayout.PropertyField(timeScale);

                    EditorGUILayout.PropertyField(effectIntensity);

                }

                EditorGUI.indentLevel--;
            }

            EditorGUILayout.Space();


            //EditorGUILayout.LabelField("Effects", EditorStyles.boldLabel);
            //EditorGUI.indentLevel++;

            {
                EditorGUILayout.LabelField("Fallback Effects", EditorStyles.boldLabel);
                EditorGUI.indentLevel++;
                //Fallback Appearances
                {
                    StartToggleGroup(ref panel_editDefaultAppearances, $"Default Appearances [{tags_fallbackAppearances.arraySize} enabled]", boldFoldout);
                    if (panel_editDefaultAppearances)
                    {
                        EditFallbackEffects(ref tags_fallbackAppearances, true);
                        EditorGUILayout.Space();
                    }

                    EndToggleGroup(panel_editDefaultAppearances);
                }

                //Fallback Behaviors
                {
                    StartToggleGroup(ref panel_editDefaultBehaviors, $"Default Behaviors [{tags_fallbackBehaviors.arraySize} enabled]", boldFoldout);
                    if (panel_editDefaultBehaviors)
                    {
                        EditFallbackEffects(ref tags_fallbackBehaviors, false);
                        EditorGUILayout.Space();
                    }

                    EndToggleGroup(panel_editDefaultBehaviors);
                }
                EditorGUI.indentLevel--;
            }

            //EditorGUI.indentLevel--;

            EditorGUILayout.Space();

            //Effects
            {

                void ShowBuiltinEffect(BuiltinVariablesDrawer builtinDrawer, SerializedProperty scriptableProperty)
                {
                    builtinDrawer.StartShowing();

                    if (builtinDrawer.isDrawing)
                    {
                        bool isScriptableBeingUsed = scriptableProperty.objectReferenceValue;

                        if (!isScriptableBeingUsed)
                        {
                            builtinDrawer.DrawBody();

                            EditorGUILayout.Space();
                        }
                        else
                        {
                            GUI.enabled = false;
                            EditorGUILayout.LabelField("Built-in effects will use and share the values set in the scriptable object.", EditorStyles.wordWrappedMiniLabel);
                            GUI.enabled = true;
                        }

                        //Scriptable Data
                        bool prevGui = GUI.enabled;
                        GUI.enabled = !EditorApplication.isPlaying;

                        if (Application.isPlaying)
                            EditorGUILayout.LabelField("[!] You can't change this scriptable object during Play Mode.", EditorStyles.wordWrappedMiniLabel);
                        EditorGUILayout.PropertyField(scriptableProperty, scriptableBuiltin_GUI);
                        GUI.enabled = prevGui;
                    }

                    builtinDrawer.StopShowing();

                }

                EditorGUILayout.LabelField("Edit Effects", EditorStyles.boldLabel);
                EditorGUI.indentLevel++;

                //Appearance effects
                {
                    StartToggleGroup(ref panel_editAppearances, "Edit Appearances Effects", boldFoldout);

                    if (panel_editAppearances)
                    {
                        ShowBuiltinEffect(appDefaultPreset, scriptable_globalAppearancesValues);

                        ShowPresets(ref appPresets, ref appShowPresets, ref appLocalPresetsArray, true, false);
                    }

                    EndToggleGroup(panel_editAppearances);
                }

                //Behavior effects
                {
                    StartToggleGroup(ref panel_editBehaviors, "Edit Behavior Effects", boldFoldout);

                    if (panel_editBehaviors)
                    {

                        ShowBuiltinEffect(behDefaultDrawer, scriptable_globalBehaviorsValues);

                        ShowPresets(ref behPresets, ref behShowPresets, ref behLocalPresetsArray, false, false);


                        EditorGUILayout.Space();

                    }

                    EndToggleGroup(panel_editAppearances);
                }


                EditorGUI.indentLevel--;
            }

            EditorGUILayout.Space();

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();

            void ResetEffects()
            {
                ((TextAnimator)target)?.SendMessage("EDITORONLY_ResetEffects", SendMessageOptions.RequireReceiver); //Resets effects on the target script
            }

            if (serializedObject.hasModifiedProperties)
            {
                serializedObject.ApplyModifiedProperties();

                if (Application.isPlaying)
                    ResetEffects();
            }

            /*
            //Editor Helpers
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Editor Helper Buttons ->", GUILayout.MaxWidth(150));

                if (GUILayout.Button("Locate Global Data", EditorStyles.miniButton))
                {
                    TAnimGlobalDataScriptableDrawer.LocateGlobalData();
                }
                GUI.enabled = Application.isPlaying;
                if (GUILayout.Button("Reset Behaviors", EditorStyles.miniButton))
                {
                    ResetEffects();
                }
                GUI.enabled = true;
                EditorGUILayout.EndHorizontal();
            }
            */
        }
    }

}