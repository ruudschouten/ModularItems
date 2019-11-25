using System.Collections.Generic;
using System.Linq;
using Items;
using Modifiers;
using UnityEngine;

namespace ScriptableObjects.Types
{
    [CreateAssetMenu(fileName = "Modifier Group", menuName = "Modular Items/Modifier Group")]
    public class ModifierGroup : ScriptableObject
    {
        [SerializeField] private ModifierType type;
        [SerializeField] private ItemType domain;
        [SerializeField] private ModifierTier tieredModifiers;

        public ModifierType Type => type;
        public ItemType Domain => domain;
        public ModifierTier TieredModifiers => tieredModifiers;

        public ICollection<Modifier> Modifiers
        {
            get
            {
                if (TieredModifiers == null || TieredModifiers.Values.Count == 0)
                {
                    return new List<Modifier>();
                } 
                
                return TieredModifiers.Values;
            }
        }

        public List<Modifier> GetWithinItemLevel(int level)
        {
            if (Modifiers == null || Modifiers.Count == 0)
            {
                return new List<Modifier>();
            }
            
            var modifiers = Modifiers.ToList().FindAll(x => x.RequiredItemLevel <= level);
            return modifiers;
        }

        public bool Contains(ModifiableItem item)
        {
            foreach (var modifier in item.Modifiers.GetByType(type))
            {
                foreach (var value in tieredModifiers.Values)
                {
                    if (modifier == value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}