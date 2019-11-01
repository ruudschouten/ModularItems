using ScriptableObjects.Collections;
using UnityEngine;

namespace Factories
{
    public class WeaponFactory : MonoBehaviour
    {
        [SerializeField] private WeaponCollection weaponCollection;
        [SerializeField] private ComponentFactory componentFactory;

        public WeaponCollection WeaponCollection => weaponCollection;
        public ComponentFactory ComponentFactory => componentFactory;
    }
}