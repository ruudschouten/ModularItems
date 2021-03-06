﻿using ScriptableObjects.Types;
using Stats;
using UnityEngine;

namespace Items
{
    public abstract class BaseItem : MonoBehaviour
    {
        [SerializeField] private new string name;
        [SerializeField] private int quality;
        [SerializeField] private ItemRarityDropdown rarity;
        [SerializeField] private Requirements requirements;
        [SerializeField] private int itemLevel;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public int Quality
        {
            get => quality;
            set => quality = value;
        }
        
        public ItemRarity GetRarity()
        {
            return rarity.Type;
        }

        public void SetRarity(ItemRarity rarity)
        {
            this.rarity.Index = rarity.Tier;
            this.rarity.Type = rarity;
        }

        public virtual int ItemLevel
        {
            get => itemLevel;
            set => itemLevel = value;
        }

        public Requirements Requirements => requirements;
    }
}
