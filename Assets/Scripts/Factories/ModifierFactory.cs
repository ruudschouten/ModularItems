using System;
using System.Linq;
using Items;
using ScriptableObjects.Collections;
using Stats.Modifiers;
using UnityEngine;

namespace Factories
{
    public class ModifierFactory : AbstractFactory<Modifier>
    {
        [SerializeField] private ModifierCollection modifierCollection;
        
        public ModifierCollection ModifierCollection => modifierCollection;

        public ModifierByType Create(ModifiableItem item)
        {
            var mods = new ModifierByType();

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
                var rand = Random.NextInt(0, 1);
                if (rand == 0)
                {
                    if (mods.CanAdd(ModifierType.Prefix, item.GetRarity()))
                    {
                        mods.AddPrefix(GetModifier(ModifierType.Prefix, item));
                    }
                }
                else
                {
                    if (mods.CanAdd(ModifierType.Suffix, item.GetRarity()))
                    {
                        mods.AddSuffix(GetModifier(ModifierType.Suffix, item));
                    }
                }
            }

            return mods;
        }

        public Modifier GetModifier(ModifierType type, ModifiableItem item)
        {
            var groups = modifierCollection.ModifierGroups.FindAll(x => x.Type == type);

            var groupIndex = GetRandomInRangeOfCollection(groups);

            if (groups == null)
            {
                throw new NullReferenceException("Unable to find any ModifierGroups for type " + type);
            }
            
            var group = groups[groupIndex];
            
            Debug.Log($"{group}");

            var modifier = group.GetWithinItemLevel(item.ItemLevel);

            if (modifier == null || modifier.Count == 0)
            {
                // Try again in a different group until a modifier is found.
                return null;
            }
            
            var index = GetRandomInRangeOfCollection(group.Modifiers.ToList());

            return group.Modifiers.ToList()[index];
        }
    }
}