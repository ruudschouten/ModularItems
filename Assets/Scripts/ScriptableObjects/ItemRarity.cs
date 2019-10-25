using UnityEngine;

namespace ScriptableObjects
{    [CreateAssetMenu(fileName = "Item Rarity", menuName = "Modular Items/Rarity", order = 1)]

    public class ItemRarity : ScriptableObject
    {
        [SerializeField] private new string name;
        [SerializeField] private Color colour;
        [SerializeField] private int maxModifiers;

        public string Name => name;
        public Color Colour => colour;
        public int MaxModifiers => maxModifiers;
    }
}
