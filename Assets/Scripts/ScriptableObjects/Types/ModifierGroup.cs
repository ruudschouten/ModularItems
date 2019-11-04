using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Types
{
    [CreateAssetMenu(fileName = "Modifier Group", menuName = "Modular Items/Modifier Group")]
    public class ModifierGroup : ScriptableObject
    {
        [SerializeField] private List<Modifier> modifiers;
        
        public List<Modifier> Modifiers => modifiers;
    }
}