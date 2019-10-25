using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects.Collections
{
    public abstract class ScriptableCollection<T> : ScriptableObject 
    {
        [SerializeField] internal List<T> entries;

        public List<T> Entries => entries;
    }
}