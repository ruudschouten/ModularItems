using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Statistics
    {
        [SerializeField] private int level;
        [SerializeField] private Attributes attributes = new Attributes();
        [SerializeField] private List<DamageStat> flatDamage = new List<DamageStat>();
        [SerializeField] private Offensive offensive = new Offensive();
        [SerializeField] private Defensive defensive = new Defensive();
        [SerializeField] private Utility utility = new Utility();

        public int Level
        {
            get => level;
            set => level = value;
        }

        public Attributes Attributes => attributes;

        public static Statistics operator +(Statistics a, Statistics b)
        {
            var stats = new Statistics
            {
                Level = a.level + b.level
            };
            
            stats.attributes.Apply(b.attributes);

            return stats;
        }
    }
}
