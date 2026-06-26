using UnityEngine;
using UnityEditor;

namespace Febucci.Attributes
{
    [CustomPropertyDrawer(typeof(CharsDisplayTimeAttribute))]
    public class CharsDisplayTimeAttributeDrawer : PropertyDrawer
    {
        const float minWaitTime = 0.0001f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            //delay in seconds
            Rect delayValueRect = new Rect(position.x, position.y, 70 + 230 - position.x, position.height);
            delayValueRect.width = Mathf.Clamp(position.width * 0.6f, 170, position.width);

            Rect delayLabel = new Rect(delayValueRect);
            delayLabel.x += delayLabel.width - 15;
            delayLabel.width = 77;

            Rect charPerSecValueRect = new Rect(delayLabel);
            charPerSecValueRect.x += charPerSecValueRect.width - 15;
            charPerSecValueRect.width = 65;


            Rect charPerSecLabelRect = new Rect(charPerSecValueRect);
            charPerSecLabelRect.x += charPerSecLabelRect.width - 15;
            charPerSecLabelRect.width = 120;

            switch (property.propertyType)
            {
                case SerializedPropertyType.Float:

                    property.floatValue = EditorGUI.FloatField(delayValueRect, label, property.floatValue);

                    EditorGUI.LabelField(delayLabel, $"s delay, ≈");



                    int charPerSecond = Mathf.RoundToInt(1 / property.floatValue);

                    EditorGUI.LabelField(charPerSecLabelRect, "chars per sec");
                    EditorGUI.BeginChangeCheck();
                    charPerSecond = EditorGUI.IntField(charPerSecValueRect, charPerSecond);

                    if (EditorGUI.EndChangeCheck())
                    {
                        property.floatValue = 1f/charPerSecond;
                    }

                    if (property.floatValue < minWaitTime)
                        property.floatValue = minWaitTime;

                    break;


                default: //unsupported, fallback to the default OnGUI
                    EditorGUI.PropertyField(position, property, label);
                    return;
            }

        }

    }

}