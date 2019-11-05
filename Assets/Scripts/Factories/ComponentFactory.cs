using Items.Components;
using ScriptableObjects.Collections;
using UnityEngine;

namespace Factories
{
    public class ComponentFactory : AbstractFactory<ItemComponent>
    {
        [SerializeField] private ComponentCollection componentCollection;
        [SerializeField] private ModifierFactory modifierFactory;

        public ComponentCollection ComponentCollection => componentCollection;
        public ModifierFactory ModifierFactory => modifierFactory;
        
        public override ItemComponent Create()
        {
            var index = GetRandomInRangeOfCollection(ComponentCollection.Components);
            var component = Instantiate(ComponentCollection.Components[index]);

            // Add modifiers when factory is made
            
            return component;
        }
    }
}