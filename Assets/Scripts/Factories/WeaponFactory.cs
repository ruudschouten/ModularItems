using Items;
using Items.Components;
using NaughtyAttributes;
using ScriptableObjects.Collections;
using UnityEngine;

namespace Factories
{
    public class WeaponFactory : AbstractFactory<Weapon>
    {
        [SerializeField] protected Transform weaponContainer;
        [SerializeField] private WeaponCollection weaponCollection;
        [SerializeField] private RarityFactory rarityFactory;
        [SerializeField] private ComponentFactory componentFactory;

        public WeaponCollection WeaponCollection => weaponCollection;
        public ComponentFactory ComponentFactory => componentFactory;

        [Button("Generate")]
        public override Weapon Create()
        {
            Cleanup(weaponContainer);
            
            // Select random weapon from collection
            var index = GetRandomInRangeOfCollection(weaponCollection.Weapons);
            var weapon = Instantiate(WeaponCollection.Weapons[index], weaponContainer);

            weapon.Handle.SetRarity(rarityFactory.GetIndex());
            
            // Add component slots
            AddComponents(weapon.Handle);
            
            weapon.CalculateStats();

            return weapon;
        }

        private void AddComponents(ItemComponent handle)
        {
            var componentsToAdd = Random.NextInt(1, handle.Connectors.Count);

            for (var i = 0; i < componentsToAdd; i++)
            {
                if (!handle.CanAddComponent()) break;
                
                var component = ComponentFactory.Create();

                handle.AddComponent(component);
            }
        }
    }
}