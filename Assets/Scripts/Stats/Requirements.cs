using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Requirements
    {
        [SerializeField] private int level;
        [SerializeField] private int strength;
        [SerializeField] private int dexterity;
        [SerializeField] private int intelligence;
        
        public int Level => level;
        public int Strength => strength;
        public int Dexterity => dexterity;
        public int Intelligence => intelligence;

        public Requirements(int level)
        {
            this.level = level;
        }

        public Requirements(int level, int strength, int dexterity, int intelligence) : this(level)
        {
            this.strength = strength;
            this.dexterity = dexterity;
            this.intelligence = intelligence;
        }

        public bool AreMet(Statistics stats)
        {
            if (stats.Level < Level) return false;
            if (stats.Strength < Strength) return false;
            if (stats.Dexterity < Dexterity) return false;
            if (stats.Intelligence < Intelligence) return false;
            return true;
        }
    }
}
