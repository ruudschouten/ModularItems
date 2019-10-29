using System;
using UnityEngine;

namespace ScriptableObjects.DropDown
{
    [Serializable]
    public abstract class ScriptableDropdown<T> 
        where T : ScriptableObject, new()
    {
        [SerializeField] private T type;
        [SerializeField] private int index;

        public T Type => type;
        protected int Index => index;
    }
}