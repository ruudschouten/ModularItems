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
        
        public ModifierByType Create(ModifiableItem item)
        {
            var mods = new ModifierByType();

            if (item.GetRarity().MaxModifiers < 1)
            {
                return mods;
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
            
            if (groups == null)
            {
                throw new NullReferenceException("Unable to find any ModifierGroups for type " + type);
            }
            
            var groupIndex = GetRandomInRangeOfCollection(groups);
            
            var group = groups[groupIndex];

            var modifiers = group.Modifiers.ToList();

            if (modifiers.Count == 0)
            {
                // No modifier could be found, so none will be added
                return null;
            }
            
            var index = GetRandomInRangeOfCollection(modifiers);

            return modifiers[index];
        }
    }
}