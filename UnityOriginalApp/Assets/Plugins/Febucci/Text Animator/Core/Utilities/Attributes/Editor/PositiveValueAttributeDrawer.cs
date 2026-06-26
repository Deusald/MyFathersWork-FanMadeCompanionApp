using UnityEngine;
using UnityEditor;

namespace Febucci.Attributes
{
    [CustomPropertyDrawer(typeof(PositiveValueAttribute))]
    public class PositiveValueAttributeDrawer : PropertyDrawer
    {
        const float minValue = .01f;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

            switch (property.propertyType)
            {
                case SerializedPropertyType.Integer:
                    int intValue = property.intValue;
                    intValue = EditorGUI.IntField(position, label, intValue);
                    if (intValue >= minValue)
                        property.intValue = intValue;
                    break;

                case SerializedPropertyType.Float:
                    float floatValue = property.floatValue;
                    floatValue = EditorGUI.FloatField(position, label, floatValue);

                    property.floatValue = Mathf.Clamp(floatValue, minValue, floatValue);
                    break;

                case SerializedPropertyType.Vector2:
                    Vector2 vecValue = property.vector2Value;
                    vecValue = EditorGUI.Vector2Field(position, label, vecValue);

                    vecValue.x = Mathf.Clamp(vecValue.x, minValue, vecValue.x);
                    vecValue.y = Mathf.Clamp(vecValue.y, minValue, vecValue.y);

                    property.vector2Value = vecValue;
                    break;

                default:
                    base.OnGUI(position, property, label);
                    break;
            }

        }
    }

}