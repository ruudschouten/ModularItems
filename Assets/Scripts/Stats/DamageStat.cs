using System;
using ScriptableObjects;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class DamageStat
    {
        [SerializeField] private DamageType type;
        [SerializeField] private int min;
        [SerializeField] private int max;

        public DamageType Type => type;
        public int Min => min;
        public int Max => max;

        public DamageStat(DamageType type, int min, int max)
        {
            this.type = type;
            this.min = min;
            this.max = max;
        }

        public bool IsNotNull()
        {
            return (min != 0 && max != 0);
        }
        
        public float GetDamageAverage() {
            return (Min + Max / 2);
        }
    }
}