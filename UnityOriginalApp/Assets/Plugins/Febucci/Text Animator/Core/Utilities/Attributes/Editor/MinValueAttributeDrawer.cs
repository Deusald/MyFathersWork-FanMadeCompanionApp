using UnityEngine;
using UnityEditor;

namespace Febucci.Attributes
{
    [CustomPropertyDrawer(typeof(MinValueAttribute))]
    public class MinValueAttributeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label);
            switch (property.propertyType)
            {
                case SerializedPropertyType.Integer:
                    property.intValue = Mathf.Clamp(property.intValue, (int)(attribute as MinValueAttribute).min, int.MaxValue);
                    break;

                case SerializedPropertyType.Float:
                    property.floatValue = Mathf.Clamp(property.floatValue, (attribute as MinValueAttribute).min, float.MaxValue);
                    break;

                default:
                    base.OnGUI(position, property, label);
                    break;
            }

        }
    }

}