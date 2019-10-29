using ScriptableObjects;
using ScriptableObjects.Helpers;
using Stats;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(DamageStat))]
    public class DamageStatDrawer : PropertyDrawer
    {
        private bool _backgroundDrawn;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return (EditorGUIUtility.singleLineHeight * 2) + 10;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var typeHelper = new DamageTypeHelper();
            typeHelper.LoadTypes();
            // Get properties
            var damageType = property.FindPropertyRelative("type");
            var minValue = property.FindPropertyRelative("min");
            var maxValue = property.FindPropertyRelative("max");
            var index = property.FindPropertyRelative("_index");

            // Using BeginProperty / EndProperty on the parent property means that
            // prefab override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            var extraWidth = EditorGUIUtility.labelWidth / 3;
            position.x += extraWidth;
            position.width -= extraWidth;

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Draw background
            var offset = 10;
            EditorGUI.LabelField(
                new Rect(position.x - offset, position.y - 1, position.width + offset, position.height),
                GUIContent.none, EditorStyles.helpBox);

            // Calculate rects
            var nextLine = position.y + EditorGUIUtility.singleLineHeight + 5;
            var labelWidth = 35;

            var prevXmin = position.xMin;
            
            var typeLabelRect = new Rect(position.x, position.y, 70, EditorGUIUtility.singleLineHeight);
            position.xMin = typeLabelRect.xMax + 5;
            var typeRect = new Rect(position.x, position.y, position.width - 5, EditorGUIUtility.singleLineHeight);
            position.xMin = prevXmin;
            
            var minLabelRect = new Rect(position.x, nextLine, labelWidth, EditorGUIUtility.singleLineHeight);
            position.xMin = minLabelRect.xMax + 5;
            var minRect = new Rect(position.x, nextLine, position.center.x - (minLabelRect.xMax + 5), EditorGUIUtility.singleLineHeight);
            position.xMin = minRect.xMax + 5;
            var maxLabelRect = new Rect(position.x, nextLine, labelWidth, EditorGUIUtility.singleLineHeight);
            position.xMin = maxLabelRect.xMax + 5;
            var maxRect = new Rect(maxLabelRect.xMax, nextLine, position.width, EditorGUIUtility.singleLineHeight);
            position.xMin = prevXmin;

            var labelStyle = EditorStyles.miniLabel;
            
            EditorGUI.BeginChangeCheck();

            EditorGUI.LabelField(typeLabelRect, "Damage Type", labelStyle);
            
            index.intValue = EditorGUI.Popup(typeRect, index.intValue, typeHelper.GetStringTypes(),
                EditorStyles.toolbarDropDown);
            if (EditorGUI.EndChangeCheck())
            {
                damageType.objectReferenceValue = typeHelper.GetFromIndex(index.intValue);
            }
            else
            {
                index.intValue = typeHelper.GetIndex(damageType.objectReferenceValue as DamageType);
            }
            
            EditorGUI.LabelField(minLabelRect, "Min", labelStyle);
            EditorGUI.PropertyField(minRect, minValue, GUIContent.none);
            EditorGUI.LabelField(maxLabelRect, "Max", labelStyle);
            EditorGUI.PropertyField(maxRect, maxValue, GUIContent.none);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}