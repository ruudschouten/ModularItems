using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class Utility
    {
        [SerializeField] private float movementSpeed;

        public float MovementSpeed
        {
            get => movementSpeed;
            set => movementSpeed = value;
        }

        public static Utility operator +(Utility a, Utility b)
        {
            a.MovementSpeed += b.MovementSpeed;

            return a;
        }
    }
}