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
        [SerializeField] private Resources resources = new Resources();
        [SerializeField] private Offensive offensive = new Offensive();
        [SerializeField] private Defensive defensive = new Defensive();
        [SerializeField] private Utility utility = new Utility();

        #region Properties

        public int Level
        {
            get => level;
            set => level = value;
        }

        public Attributes Attributes
        {
            get => attributes;
            set => attributes = value;
        }

        public List<DamageStat> FlatDamage
        {
            get => flatDamage;
            set => flatDamage = value;
        }

        public Resources Resources
        {
            get => resources;
            set => resources = value;
        }

        public Offensive Offensive
        {
            get => offensive;
            set => offensive = value;
        }

        public Defensive Defensive
        {
            get => defensive;
            set => defensive = value;
        }

        public Utility Utility
        {
            get => utility;
            set => utility = value;
        }

        #endregion

        public static Statistics operator +(Statistics a, Statistics b)
        {
            var stats = new Statistics
            {
                Level = a.level + b.level,
                Attributes = a.Attributes + b.Attributes,
                FlatDamage = new List<DamageStat>(),
                Resources = a.Resources + b.Resources,
                Offensive = a.Offensive + b.Offensive,
                Defensive = a.Defensive + b.Defensive,
                Utility =  a.Utility + b.Utility
            };

            stats.FlatDamage.AddRange(a.FlatDamage);
            stats.FlatDamage.AddRange(b.FlatDamage);

            return stats;
        }
    }
}
