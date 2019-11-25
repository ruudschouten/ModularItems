using ScriptableObjects.DropDown;
using ScriptableObjects.Types;
using Stats;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(DamageStat))]
    public class DamageStatDrawer : PropertyDrawer
    {
        private bool _backgroundDrawn;
        private float _rectSpacing = 5;
        private float _height = EditorGUIUtility.singleLineHeight;
        private GUIStyle _labelStyle = EditorStyles.miniLabel;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return (EditorGUIUtility.singleLineHeight + _rectSpacing) * 3;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var typeHelper = new DamageTypeHelper();
            typeHelper.LoadTypes();
            // Get properties
            var damageType = property.FindPropertyRelative("type");
            var index = property.FindPropertyRelative("_index");
            
            var damage = property.FindPropertyRelative("damage");
            var damageMin = damage.FindPropertyRelative("min");
            var damageMax = damage.FindPropertyRelative("max");
            
            var modifier = property.FindPropertyRelative("modifier");
            var modifierMin = modifier.FindPropertyRelative("min");
            var modifierMax = modifier.FindPropertyRelative("max");

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
            var secondLine = position.y + _height + _rectSpacing;
            var thirdLine = position.y + (_height + _rectSpacing) * 2;
            var minMaxLabelWidth = 35;

            DrawTypeDropdown(position, index, typeHelper, damageType);
            DrawMinMax(position, secondLine, minMaxLabelWidth, "Damage", 45, 
                damageMin, damageMax);
            DrawMinMax(position, thirdLine, minMaxLabelWidth, "Modifier", 45, 
                modifierMin, modifierMax);

            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }

        private void DrawTypeDropdown(Rect position, SerializedProperty index, DamageTypeHelper typeHelper, 
            SerializedProperty damageType)
        {
            var prevXmin = position.xMin;

            var typeLabelRect = new Rect(position.x, position.y, 70, _height);
            position.xMin = typeLabelRect.xMax + _rectSpacing;

            var typeRect = new Rect(position.x, position.y, position.width - _rectSpacing, _height);
            position.xMin = prevXmin;

            EditorGUI.BeginChangeCheck();

            EditorGUI.LabelField(typeLabelRect, "Damage Type", _labelStyle);

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
        }

        private void DrawMinMax(Rect position, float yPosition, int labelWidth, string fieldIdentifier,
            int identifierWidth, SerializedProperty min, SerializedProperty max)
        {
            // After setting the values for a rectangle, update the positions min values, so position.x can be easily 
            // used as the starting position for the next rect
            var prevXmin = position.xMin;
            var labelRect = new Rect(position.x, yPosition, identifierWidth, _height);
            position.xMin = labelRect.xMax + _rectSpacing;

            var minLabelRect = new Rect(position.x, yPosition, labelWidth, _height);
            position.xMin = minLabelRect.xMax;

            var minRect = new Rect(position.x, yPosition, 
                position.center.x - (position.xMin + minLabelRect.width / 2), _height);
            position.xMin = minRect.xMax + _rectSpacing;

            var maxLabelRect = new Rect(position.x, yPosition, labelWidth, _height);
            position.xMin = maxLabelRect.xMax + _rectSpacing;

            var maxRect = new Rect(maxLabelRect.xMax, yPosition, position.width, _height);
            // Reset the position min X to the stored value before creating these rects 
            position.xMin = prevXmin;

            EditorGUI.LabelField(labelRect, fieldIdentifier, _labelStyle);
            EditorGUI.LabelField(minLabelRect, "Min", _labelStyle);
            EditorGUI.PropertyField(minRect, min, GUIContent.none);
            EditorGUI.LabelField(maxLabelRect, "Max", _labelStyle);
            EditorGUI.PropertyField(maxRect, max, GUIContent.none);
        }
    }
}