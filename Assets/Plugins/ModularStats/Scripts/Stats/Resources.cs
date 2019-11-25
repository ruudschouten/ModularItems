using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Resources
    {
        [SerializeField] private int health;
        [SerializeField] private int maxHealth;
        [SerializeField] private int spirit;
        [SerializeField] private int maxSpirit;

        public int Health
        {
            get => health;
            set => health = value;
        }

        public int Spirit
        {
            get => spirit;
            set => spirit = value;
        }

        public int MaxHealth
        {
            get => maxHealth;
            set => maxHealth = value;
        }

        public int MaxSpirit
        {
            get => maxSpirit;
            set => maxSpirit = value;
        }

        public static Resources operator +(Resources a, Resources b)
        {
            a.Health += b.Health;
            a.MaxHealth += b.MaxHealth;
            a.Spirit += b.Spirit;
            a.MaxSpirit += b.MaxSpirit;

            return a;
        }
    }
}