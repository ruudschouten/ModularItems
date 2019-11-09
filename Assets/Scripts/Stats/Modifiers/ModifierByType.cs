using System;
using System.Collections.Generic;
using ScriptableObjects.Types;
using UnityEngine;

namespace Stats.Modifiers
{
    [Serializable]
    public class ModifierByType
    {
        [SerializeField] private Modifier @implicit;
        [SerializeField] private List<Modifier> prefixes = new List<Modifier>();
        [SerializeField] private List<Modifier> suffixes = new List<Modifier>();

        public Modifier Implicit
        {
            get => @implicit;
            set => @implicit = value;
        }
        
        public List<Modifier> Prefixes => prefixes;
        public List<Modifier> Suffixes => suffixes;

        public List<Modifier> All
        {
            get
            {
                if (_all == null || _all.Count == 0)
                {
                    _all = new List<Modifier>();
                    
                    _all.Add(Implicit);
                    _all.AddRange(Prefixes);
                    _all.AddRange(Suffixes);
                }

                return _all;
            }
        }

        private List<Modifier> _all;

        public bool CanAdd(ModifierType type, ItemRarity rarity)
        {
            switch (type)
            {
                case ModifierType.Implicit:
                    return Implicit == null;
                case ModifierType.Suffix:
                    return rarity.MaxSuffixes < Suffixes.Count;
                case ModifierType.Prefix:
                    return rarity.MaxPrefixes < Prefixes.Count;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        public void SetImplicit(Modifier modifier)
        {
            Implicit = modifier;
        }

        public void AddPrefix(Modifier modifier)
        {
            if (modifier == null) return;
            
            Prefixes.Add(modifier);
        }

        public void AddSuffix(Modifier modifier)
        {
            if (modifier == null) return;
            
            Suffixes.Add(modifier);
        }
    }
}