using System;
using Stats.Modifiers;
using UnityEngine;

namespace Items
{
    public class ModifiableItem : BaseItem
    {
        [SerializeField] private bool hasImplicit;

        [SerializeField] private ModifierByType modifiers = new ModifierByType();

        public ModifierByType Modifiers
        {
            get => modifiers;
            set => modifiers = value;
        }

        public bool HasImplicit => hasImplicit;

        public void AddModifier(Modifier modifier, ModifierType type)
        {
            switch (type)
            {
                case ModifierType.Implicit:
                    modifiers.SetImplicit(modifier);
                    break;
                case ModifierType.Suffix:
                    Modifiers.AddSuffix(modifier);
                    break;
                case ModifierType.Prefix:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}