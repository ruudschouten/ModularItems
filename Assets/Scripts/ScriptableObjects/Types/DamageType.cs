using System;
using ScriptableObjects.Collections;
using ScriptableObjects.DropDown;
using ScriptableObjects.Helpers;
using UnityEngine;

namespace ScriptableObjects.Types
{
    [CreateAssetMenu(fileName = "Damage Type", menuName = "Modular Items/Damage Type", order = 1)]
    public class DamageType : ScriptableObject
    {
        [SerializeField] private string type;
        [SerializeField] private Color colour;

        public string Type => type;
        public Color Colour => colour;
    }

    [Serializable]
    public class DamageTypeDropdown : ScriptableDropdown<DamageType>
    {
    }
    
    public class DamageTypeHelper : ScriptableObjectHelper<DamageType, DamageTypeCollection>
    {
    }
}