﻿using System.Collections.Generic;
using System.Linq;
using Items.Components;
using NaughtyAttributes;
using Stats;
using UnityEngine;

namespace Items
{
    public class Weapon : BaseItem
    {
        [SerializeField] private int handsNeeded = 1;
        [SerializeField] private float criticalChance = 0.05f;
        [SerializeField] private float attackSpeed = 1f;
        [SerializeField] private ItemComponent handle;
        
        [ReadOnly] [SerializeField] private DamageDictionary damage;

        public int HandsNeeded => handsNeeded;
        public float CriticalChance => criticalChance;
        public float AttackSpeed => attackSpeed;
        public ItemComponent Handle => handle;

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

        public DamageDictionary Damage
        {
            get
            {
                if (damage != null && !handle.Changed) return damage;

                damage = new DamageDictionary();

                foreach (var comp in Components)
                {
                    foreach (var damageStat in comp.Damage)
                    {
                        if (!damage.ContainsKey(damageStat.Type))
                        {
                            damage.Add(damageStat.Type, new MinMaxInt());
                        }

                        damage[damageStat.Type] += new MinMaxInt(damageStat.Min, damageStat.Max);
                    }
                }

                return damage;
            }
        }

        public List<ItemComponent> Components
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
                    if (connector.Component == null) continue;
                    
                    _components.Add(connector.Component);
                }

                handle.Changed = false;

                return _components;
            }
        }

        public List<Connector> Connectors => handle.Connectors;

        // This is a combination of the Components' stats
        private Statistics _statistics;
        
        private List<ItemComponent> _components;

        public void CalculateStats()
        {
            var damage = Damage;
            var stats = Statistics;
        }
    }
}