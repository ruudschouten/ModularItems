using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Statistics
    {
        [SerializeField] private int level;
        [SerializeField] private int strength;
        [SerializeField] private int dexterity;
        [SerializeField] private int intelligence;
        
        public int Level
        {
            get => level;
            set => level = value;
        }

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
        
        public static Statistics operator +(Statistics a, Statistics b)
        {
            var stats = new Statistics
            {
                Level = a.level + b.level,
                Strength = a.Strength + b.Strength,
                Dexterity = a.Dexterity + b.Dexterity,
                Intelligence = a.Intelligence + b.Intelligence
            };

            return stats;
        }
    }
}
