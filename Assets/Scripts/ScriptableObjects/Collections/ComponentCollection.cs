using System.Collections.Generic;
using Items.Components;
using UnityEngine;

namespace ScriptableObjects.Collections
{
    [CreateAssetMenu(fileName = "_Collection", menuName = "Modular Items/Collections/Components")]
    public class ComponentCollection : ScriptableObject
    {
        [SerializeField] private List<ItemComponent> components;

        public List<ItemComponent> Components => components;
    }
}