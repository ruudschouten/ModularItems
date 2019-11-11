using System.Collections.Generic;
using Items;
using Items.Components;
using ScriptableObjects.Collections;
using UnityEngine;

namespace Factories
{
    public class ComponentFactory : AbstractFactory<ItemComponent>
    {
        [SerializeField] private ComponentCollection componentCollection;
        [SerializeField] private RarityFactory rarityFactory;
        [SerializeField] private ModifierFactory modifierFactory;
        
        public override ItemComponent Create()
        {
            return GetFromCollection(componentCollection.Components);
        }

        public ItemComponent CreateWithItemLevel(int itemLevel)
        {
            var components = componentCollection.GetWithinItemLevel(itemLevel);
            return GetFromCollection(components);
        }

        private ItemComponent GetFromCollection(List<ItemComponent> components)
        {
            var index = GetRandomInRangeOfCollection(components);
            var component = Instantiate(components[index]);
            
            component.SetRarity(rarityFactory.Create());
            
            modifierFactory.ApplyModifiers(component);

            return component;
        }
    }
}