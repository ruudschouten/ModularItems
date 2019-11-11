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
            var index = GetRandomInRangeOfCollection(componentCollection.Components);
            var component = Instantiate(componentCollection.Components[index]);

            component.SetRarity(rarityFactory.GetRarity());

            modifierFactory.ApplyModifiers(component);

            return component;
        }
    }
}