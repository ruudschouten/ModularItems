using System.Collections.Generic;
using System.Linq;
using Items.Components;
using UnityEngine;

namespace ScriptableObjects.Collections
{
    [CreateAssetMenu(fileName = "_Collection", menuName = "Modular Items/Collections/Components")]
    public class ComponentCollection : ScriptableObject
    {
        [SerializeField] private List<ItemComponent> components;

        public List<ItemComponent> Components => components;

        public List<ItemComponent> GetWithinItemLevel(int level)
        {
            if (Components == null || Components.Count == 0)
            {
                return new List<ItemComponent>();
            }
            
            var modifiers = Components.ToList().FindAll(x => x.ItemLevel <= level);
            return modifiers;
        }
    }
}