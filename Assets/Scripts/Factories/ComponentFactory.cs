using ScriptableObjects.Collections;
using UnityEngine;

namespace Factories
{
    public class ComponentFactory : MonoBehaviour
    {
        [SerializeField] private ComponentCollection componentCollection;
        [SerializeField] private ModifierFactory modifierFactory;

        public ComponentCollection ComponentCollection => componentCollection;
        public ModifierFactory ModifierFactory => modifierFactory;
    }
}