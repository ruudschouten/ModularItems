using System.Collections.Generic;
using ScriptableObjects.Types;
using UnityEngine;

namespace ScriptableObjects.Collections
{
    [CreateAssetMenu(fileName = "_Collection", menuName = "Modular Items/Collections/Modifier Group")]
    public class ModifierCollection : ScriptableObject
    {
        [SerializeField] private List<ModifierGroup> modifierGroups;

        public List<ModifierGroup> ModifierGroups => modifierGroups;
    }
}