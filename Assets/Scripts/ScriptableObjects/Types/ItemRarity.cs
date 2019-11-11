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
        [SerializeField] private int tier;
        [SerializeField] private int maxModifiers;
        [SerializeField] private int maxPrefixes;
        [SerializeField] private int maxSuffixes;

        public string Name => name;
        public Color Colour => colour;
        public int Tier
        {
            get => tier;
            set => tier = value;
        }

        public int MaxModifiers => maxModifiers;
        public int MaxPrefixes => maxPrefixes;
        public int MaxSuffixes => maxSuffixes;
    }
    
    [Serializable]
    public class ItemRarityDropdown : ScriptableDropdown<ItemRarity>
    {
        public override int Index
        {
            get => Type.Tier;
            set => Type.Tier = value;
        }
    }
    
    public class ItemRarityHelper : ScriptableObjectHelper<ItemRarity, ItemRarityCollection>
    {
    }
}
