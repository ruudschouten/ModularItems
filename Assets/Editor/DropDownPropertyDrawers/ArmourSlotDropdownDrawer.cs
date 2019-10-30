using ScriptableObjects.Collections;
using ScriptableObjects.Types;
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