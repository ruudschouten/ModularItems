using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ModifiableItem : BaseItem
    {
        [SerializeField] private List<Modifier> modifiers;

        public List<Modifier> Modifiers => modifiers;
    }
}