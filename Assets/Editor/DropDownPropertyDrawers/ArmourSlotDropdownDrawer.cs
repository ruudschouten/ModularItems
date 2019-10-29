using ScriptableObjects;
using ScriptableObjects.Collections;
using ScriptableObjects.DropDown;
using ScriptableObjects.Helpers;
using UnityEditor;

namespace Editor.DropDownPropertyDrawers
{
    [CustomPropertyDrawer(typeof(ArmourSlotDropdown))]
    public class ArmourSlotDropdownDrawer : ScriptableDropdownDrawer<ArmourSlot, ArmourSlotCollection, ArmourSlotHelper>
    {
        protected override ArmourSlotHelper GetHelper()
        {
            return new ArmourSlotHelper();
        }
    }
}