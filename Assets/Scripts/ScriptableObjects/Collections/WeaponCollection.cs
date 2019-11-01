using System.Collections.Generic;
using Items;
using UnityEngine;

namespace ScriptableObjects.Collections
{   
    [CreateAssetMenu(fileName = "_Collection", menuName = "Modular Items/Collections/Weapons")]
    public class WeaponCollection : ScriptableObject
    {
        [SerializeField] private List<Weapon> weapon;

        public List<Weapon> Weapon => weapon;

        public Weapon GetBaseWeapon()
        {
            return null;
        }
    }
}