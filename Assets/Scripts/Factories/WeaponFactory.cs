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
        [SerializeField] private ModifierFactory modifierFactory;

        [Button("Generate")]
        public override Weapon Create()
        {
            Cleanup(weaponContainer);

            // Select random weapon from collection
            var index = GetRandomInRangeOfCollection(weaponCollection.Weapons);
            var weapon = Instantiate(weaponCollection.Weapons[index], weaponContainer);

            weapon.Handle.SetRarity(rarityFactory.GetRarity());

            modifierFactory.ApplyModifiers(weapon.Handle);

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

                var component = componentFactory.Create();

                handle.AddComponent(component);
            }
        }
    }
}