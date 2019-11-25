using System;
using System.Linq;
using Items;
using Modifiers;
using ScriptableObjects.Collections;
using UnityEngine;

namespace Factories
{
    public class ModifierFactory : AbstractFactory<Modifier>
    {
        [SerializeField] private ModifierCollection modifierCollection;
        
        public void ApplyModifiers(ModifiableItem item)
        {
            var mods = new ModifierByType();

            if (item.GetRarity().MaxModifiers < 1)
            {
                return;
            }

            if (item.HasImplicit)
            {
                var modifier = GetModifier(ModifierType.Implicit, item);
                
                if (mods.CanAdd(ModifierType.Implicit, item.GetRarity()))
                {
                    mods.SetImplicit(modifier);
                }
            }
            
            for (var i = 0; i < item.GetRarity().MaxModifiers; i++)
            {
                var rand = Random.NextInt(0, 2);
                if (rand == 0)
                {
                    if (mods.CanAdd(ModifierType.Prefix, item.GetRarity()))
                    {
                        var modifier = GetModifier(ModifierType.Prefix, item);
                        item.AddModifier(modifier, ModifierType.Prefix);
                    }
                }
                else
                {
                    if (mods.CanAdd(ModifierType.Suffix, item.GetRarity()))
                    {
                        var modifier = GetModifier(ModifierType.Suffix, item);
                        item.AddModifier(modifier, ModifierType.Suffix);
                    }
                }
            }
        }

        public Modifier GetModifier(ModifierType type, ModifiableItem item)
        {
            // Get all groups based on the modifier type and item type
            var groups = modifierCollection.ModifierGroups.FindAll(x => x.Type == type && x.Domain.HasFlag(item.Type));
            
            if (groups == null)
            {
                throw new NullReferenceException("Unable to find any ModifierGroups for type " + type);
            }
            
            // Select a group from the ModifierGroups to choose a modifier from
            var group = groups[GetRandomInRangeOfCollection(groups)];

            // Check if the item already has a modifier from this group
            if (group.Contains(item))
            {
                Debug.Log($"Modifier from {group.name} already existed on {item.Name}, skipping");
                return null;
            }

            var modifiers = group.GetWithinItemLevel(item.ItemLevel);

            if (modifiers.Count == 0)
            {
                Debug.Log("No modifiers found");
                // No modifier could be found, so none will be added
                return null;
            }

            return modifiers[GetRandomInRangeOfCollection(modifiers)];
        }
    }
}