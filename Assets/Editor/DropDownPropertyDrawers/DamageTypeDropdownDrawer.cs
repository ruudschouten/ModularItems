using ScriptableObjects;
using ScriptableObjects.Collections;
using ScriptableObjects.DropDown;
using ScriptableObjects.Helpers;
using UnityEditor;

namespace Editor.DropDownPropertyDrawers
{
    [CustomPropertyDrawer(typeof(DamageTypeDropdown))]
    public class DamageTypeDropdownDrawer : ScriptableDropdownDrawer<DamageType, DamageTypeCollection, DamageTypeHelper>
    {
        protected override DamageTypeHelper GetHelper()
        {
            return new DamageTypeHelper();
        }
    }
}