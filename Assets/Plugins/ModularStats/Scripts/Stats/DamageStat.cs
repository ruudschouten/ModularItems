using System;
using ScriptableObjects;
using ScriptableObjects.Types;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class DamageStat
    {
        [SerializeField] private int _index;
        
        [SerializeField] private DamageType type;
        [SerializeField] private MinMaxInt damage;
        [SerializeField] private MinMaxFloat modifier;

        public DamageType Type => type;
        public MinMaxInt Damage => damage;
        public MinMaxFloat Modifier => modifier;

        public DamageStat(DamageType type, MinMaxInt damage)
        {
            this.type = type;
            this.damage = damage;
        }

        public DamageStat(DamageType type, MinMaxInt damage, MinMaxFloat modifier) : this(type, damage)
        {
            this.modifier = modifier;
        }

        public static DamageStat operator +(DamageStat a, DamageStat b)
        {
            a.damage += b.Damage;
            a.modifier += b.Modifier;
            
            return a;
        } 
    }
}