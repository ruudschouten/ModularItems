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
    }
}