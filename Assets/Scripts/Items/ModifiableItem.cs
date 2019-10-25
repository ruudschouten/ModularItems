using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class ModifiableItem : BaseItem
    {
        [SerializeField] private List<BaseItemModifier> modifiers;

        public List<BaseItemModifier> Modifiers => modifiers;
    }
}