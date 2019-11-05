using ScriptableObjects.Collections;
using UnityEngine;

namespace Factories
{
    public class ModifierFactory : AbstractFactory<Modifier>
    {
        [SerializeField] private ModifierCollection modifierCollection;
        
        public ModifierCollection ModifierCollection => modifierCollection;
        
        public override Modifier Create()
        {
            throw new System.NotImplementedException();
        }
    }
}