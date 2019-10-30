using ScriptableObjects;
using ScriptableObjects.Collections;
using ScriptableObjects.DropDown;
using ScriptableObjects.Helpers;
using ScriptableObjects.Types;
using UnityEditor;

namespace Editor.DropDownPropertyDrawers
{
    [CustomPropertyDrawer(typeof(ItemRarityDropdown))]
    public class ItemRarityDropdownDrawer : ScriptableDropdownDrawer<ItemRarity, ItemRarityCollection, ItemRarityHelper>
    {
        protected override ItemRarityHelper GetHelper()
        {
            return new ItemRarityHelper();
        }
    }
}