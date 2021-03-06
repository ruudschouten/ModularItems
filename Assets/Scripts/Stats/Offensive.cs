using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Offensive
    {
        [SerializeField] private float attackSpeed;
        [SerializeField] private float chanceToCrit;
        [SerializeField] private float critMultiplier;
        [SerializeField] private float globalDamageModifier;

        public float AttackSpeed
        {
            get => attackSpeed;
            set => attackSpeed = value;
        }

        public float ChanceToCrit
        {
            get => chanceToCrit;
            set => chanceToCrit = value;
        }

        public float CritMultiplier
        {
            get => critMultiplier;
            set => critMultiplier = value;
        }

        public float GlobalDamageModifier
        {
            get => globalDamageModifier;
            set => globalDamageModifier = value;
        }
    }
}