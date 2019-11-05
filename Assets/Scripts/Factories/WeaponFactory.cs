using Items;
using NaughtyAttributes;
using ScriptableObjects.Collections;
using UnityEngine;

namespace Factories
{
    public class WeaponFactory : AbstractFactory<Weapon>
    {
        [SerializeField] protected Transform weaponContainer;
        [SerializeField] private WeaponCollection weaponCollection;
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

            // Add component slots
            AddComponents(weapon);

            return weapon;
        }

        private void AddComponents(Weapon weapon)
        {
            var componentsToAdd = Random.NextInt(1, weapon.Connectors.Count);

            for (var i = 0; i < componentsToAdd; i++)
            {
                if (!weapon.Handle.CanAddComponent()) break;
                
                var component = ComponentFactory.Create();

                weapon.Handle.AddComponent(component);
            }
        }
    }
}