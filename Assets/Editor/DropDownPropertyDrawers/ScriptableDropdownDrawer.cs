using ScriptableObjects.Collections;
using ScriptableObjects.DropDown;
using ScriptableObjects.Helpers;
using UnityEditor;
using UnityEngine;

namespace Editor.DropDownPropertyDrawers
{
    [CustomPropertyDrawer(typeof(ScriptableDropdown<>), false)]
    public abstract class ScriptableDropdownDrawer<T, TCollection, THelper> : PropertyDrawer 
        where T : ScriptableObject, new() 
        where TCollection : ScriptableCollection<T>, new() 
        where THelper : ScriptableObjectHelper<T, TCollection>
    {
        protected abstract THelper GetHelper();

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var helper = GetHelper();
            helper.LoadTypes();
            
            var type = property.FindPropertyRelative("type");
            var index = property.FindPropertyRelative("index");

            EditorGUI.BeginProperty(position, label, property);
            
            var typeLabelRect = new Rect(position.x, position.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight);
            position.xMin = typeLabelRect.xMax;
            var typeRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

            EditorGUI.LabelField(typeLabelRect, helper.GetTypeName(), GUIStyle.none);
            
            EditorGUI.BeginChangeCheck();
            
            index.intValue = EditorGUI.Popup(typeRect, index.intValue, helper.GetStringTypes(),
                EditorStyles.toolbarDropDown);
            
            if (EditorGUI.EndChangeCheck())
            {
                type.objectReferenceValue = helper.GetFromIndex(index.intValue);
            }
            else
            {
                index.intValue = helper.GetIndex(type.objectReferenceValue as T);
            }
        }
    }
}