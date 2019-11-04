using ScriptableObjects.Collections;
using UnityEngine;

namespace Factories
{
    public class ModifierFactory : MonoBehaviour
    {
        [SerializeField] private ModifierCollection modifierCollection;
        
        public ModifierCollection ModifierCollection => modifierCollection;
    }
}