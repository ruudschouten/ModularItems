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
            var weapon = GetFromCollection();
            // Add component slots
            AddComponents(weapon.Handle);

            weapon.CalculateStats();

            return weapon;
        }

        public Weapon CreateWithMonsterLevel(int monsterLevel)
        {
            var weapon = GetFromCollection();

            AddComponents(weapon.Handle, monsterLevel);
            
            weapon.CalculateStats();

            return weapon;
        }

        private Weapon GetFromCollection()
        {
            Cleanup(weaponContainer);

            // Select random weapon from collection
            var index = GetRandomInRangeOfCollection(weaponCollection.Weapons);
            var weapon = Instantiate(weaponCollection.Weapons[index], weaponContainer);

            weapon.Handle.SetRarity(rarityFactory.Create());

            modifierFactory.ApplyModifiers(weapon.Handle);

            return weapon;
        }

        private void AddComponents(ItemComponent handle, int level = -1)
        {
            var componentsToAdd = Random.NextInt(1, handle.Connectors.Count);

            for (var i = 0; i < componentsToAdd; i++)
            {
                if (!handle.CanAddComponent()) break;

                var component = level < 0 ? componentFactory.Create() : componentFactory.CreateWithItemLevel(level);

                handle.AddComponent(component);
            }
        }
    }
}