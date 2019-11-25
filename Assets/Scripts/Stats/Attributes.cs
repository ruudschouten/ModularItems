using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Attributes
    {
        [SerializeField] private int strength;
        [SerializeField] private int dexterity;
        [SerializeField] private int intelligence;

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

        public static Attributes operator +(Attributes a, Attributes b)
        {
            a.Strength += b.Strength;
            a.Dexterity += b.Dexterity;
            a.Intelligence += b.Intelligence;

            return a;
        }
    }
}