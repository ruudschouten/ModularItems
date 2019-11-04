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
        [SerializeField] private ItemComponent handle;

        public int HandsNeeded => handsNeeded;
        public List<DamageStat> Damage => damage;
        public float CriticalChance => criticalChance;
        public float AttackSpeed => attackSpeed;

        public Statistics Statistics
        {
            get
            {
                if (_statistics != null) return _statistics;

                _statistics = new Statistics();

                foreach (var modifier in Components.SelectMany(comp => comp.Modifiers))
                {
                    _statistics += modifier.Statistics;
                }

                return _statistics;
            }
        }

        public IEnumerable<ItemComponent> Components
        {
            get
            {
                if (_components != null && !handle.Changed) return _components;

                _components = new List<ItemComponent>
                {
                    handle
                };

                foreach (var connector in handle.Connectors)
                {
                    _components.Add(connector.Component);
                }

                handle.Changed = false;

                return _components;
            }
        }

        // This is a combination of the Components' stats
        private Statistics _statistics;

        private List<ItemComponent> _components;
    }
}