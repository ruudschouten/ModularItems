using System.Collections.Generic;
using Items.Components;
using UnityEngine;

namespace ScriptableObjects.Collections
{
    [CreateAssetMenu(fileName = "_Collection", menuName = "Modular Items/Collections/Components")]
    public class ComponentCollection : ScriptableObject
    {
        [SerializeField] private List<ItemComponent> component;

        public List<ItemComponent> Component => component;

        public ItemComponent GetComponent()
        {
            return null;
        }
    }
}