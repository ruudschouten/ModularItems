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
    }
}