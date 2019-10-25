using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Slot", menuName = "Modular Items/Armour Slot", order = 1)]
    public class ArmourSlot : ScriptableObject
    {
        [SerializeField] private string category;
        
        public string Category => category;
    }
}
