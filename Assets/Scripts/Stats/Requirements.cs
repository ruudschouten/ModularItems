using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Requirements
    {
        [SerializeField] private int level;
        [SerializeField] private Attributes attributes;
        
        public int Level => level;
        public int Strength => attributes.Strength;
        public int Dexterity => attributes.Dexterity;
        public int Intelligence => attributes.Intelligence;

        public Requirements(int level)
        {
            this.level = level;
        }

        public Requirements(int level, Attributes attributes) : this(level)
        {
            this.attributes = attributes;
        }

        public bool AreMet(Statistics stats)
        {
            if (stats.Level < Level) return false;
            if (stats.Attributes.Strength < Strength) return false;
            if (stats.Attributes.Dexterity < Dexterity) return false;
            if (stats.Attributes.Intelligence < Intelligence) return false;
            return true;
        }
    }
}
