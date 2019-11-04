using System;
using ScriptableObjects.Collections;
using ScriptableObjects.DropDown;
using ScriptableObjects.Helpers;
using UnityEngine;

namespace ScriptableObjects.Types
{    [CreateAssetMenu(fileName = "Item Rarity", menuName = "Modular Items/Rarity", order = 1)]
    public class ItemRarity : ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private Color colour;
        [SerializeField] private int maxModifiers;
        [SerializeField] private int maxConnectors;

        public string Name => name;
        public Color Colour => colour;
        public int MaxModifiers => maxModifiers;
        public int MaxConnectors => maxConnectors;
    }
    
    [Serializable]
    public class ItemRarityDropdown : ScriptableDropdown<ItemRarity>
    {
    }
    
    public class ItemRarityHelper : ScriptableObjectHelper<ItemRarity, ItemRarityCollection>
    {
    }
}
