using ScriptableObjects;
using UnityEngine;

namespace Items
{
    public class Armour : ModifiableItem
    {
        [SerializeField] private int armourRating;
        [SerializeField] private int evasionRating;
        [SerializeField] private ArmourSlot armourSlot;

        public int ArmourRating
        {
            get => armourRating;
            set => armourRating = value;
        }

        public int EvasionRating
        {
            get => evasionRating;
            set => evasionRating = value;
        }
    
        public ArmourSlot ArmourSlot => armourSlot;
    }
}