using System.Collections.Generic;
using ScriptableObjects.Types;
using UnityEngine;

namespace ScriptableObjects.Collections
{
    [CreateAssetMenu(fileName = "_Collection", menuName = "Modular Stats/Damage Collection")]
    public class DamageTypeCollection : ScriptableObject 
    {
        [SerializeField] internal List<DamageType> entries;

        public List<DamageType> Entries => entries;
    }
}