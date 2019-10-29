using UnityEngine;

namespace ScriptableObjects.Collections
{
    [CreateAssetMenu(fileName = "_Collection", menuName = "Modular Items/Collections/Item Rarity")]
    public class ItemRarityCollection : ScriptableCollection<ItemRarity>
    {
    }
}