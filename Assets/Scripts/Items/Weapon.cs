using System.Collections.Generic;
using System.Linq;
using Items.Components;
using Stats;
using UnityEngine;

namespace Items
{
    public class Weapon : BaseItem
    {
        [SerializeField] private int handsNeeded = 1;
        [SerializeField] private List<DamageStat> damage;
        [SerializeField] private float criticalChance = 0.05f;
        [SerializeField] private float attackSpeed = 1f;

        [SerializeField] private List<WeaponComponent> components;

        public int HandsNeeded => handsNeeded;
        public List<DamageStat> Damage => damage;
        public float CriticalChance => criticalChance;
        public float AttackSpeed => attackSpeed;
        public List<WeaponComponent> Components => components;

        public Statistics Statistics
        {
            get
            {
                if (_statistics != null) return _statistics;
                
                _statistics = new Statistics();
                
                if (components.Count == 0) return _statistics;
                
                foreach (var modifier in components.SelectMany(comp => comp.Modifiers))
                {
                    _statistics += modifier.Statistics;
                }

                return _statistics;
            }
        }

        // This is a combination of the Components' stats
        private Statistics _statistics;
    }
}
