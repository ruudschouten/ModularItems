using ScriptableObjects;
using ScriptableObjects.DropDown;
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
        
        public ItemRarity Rarity => rarity.Type;
        public Requirements Requirements => requirements;
    }
}
