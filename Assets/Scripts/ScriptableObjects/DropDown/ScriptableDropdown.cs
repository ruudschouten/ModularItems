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

        public T Type
        {
            get => type;
            set => type = value;
        }

        public int Index
        {
            get => index;
            set => index = value;
        }
    }
}