using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Defensive
    {
        [SerializeField] private int armourRating;
        [SerializeField] private int evasionRating;

        public int ArmourRating
        {
            get => armourRating;
            set => armourRating = value;
        }

        public int EvasionRating
        {
            get => evasionRating;
            set => evasionRating = value;
        }

        public static Defensive operator +(Defensive a, Defensive b)
        {
            a.ArmourRating += b.ArmourRating;
            a.EvasionRating += b.EvasionRating;

            return a;
        }
    }
}