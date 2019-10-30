using System;
using ScriptableObjects.Collections;
using ScriptableObjects.DropDown;
using ScriptableObjects.Helpers;
using UnityEngine;

namespace ScriptableObjects.Types
{
    [CreateAssetMenu(fileName = "Slot", menuName = "Modular Items/Armour Slot", order = 1)]
    public class ArmourSlot : ScriptableObject
    {
        [SerializeField] private string category;
        
        public string Category => category;
    }
    
    [Serializable]
    public class ArmourSlotDropdown : ScriptableDropdown<ArmourSlot>
    {
    }
    
    public class ArmourSlotHelper : ScriptableObjectHelper<ArmourSlot, ArmourSlotCollection>
    {
    }
}
