using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Attributes
    {
        [SerializeField] private int strength;
        [SerializeField] private int dexterity;
        [SerializeField] private int intelligence;

        public int Strength
        {
            get => strength;
            set => strength = value;
        }

        public int Dexterity
        {
            get => dexterity;
            set => dexterity = value;
        }

        public int Intelligence
        {
            get => intelligence;
            set => intelligence = value;
        }
        
        public void Apply(Attributes other)
        {
            if (other.Strength != 0)
            {
                Strength += other.Strength;
            }
            if (other.Dexterity != 0)
            {
                Dexterity += other.Dexterity;
            }
            if (other.Intelligence > 0)
            {
                Intelligence += other.Intelligence;
            }
        }
    }
}