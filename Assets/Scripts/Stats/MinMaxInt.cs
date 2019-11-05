using System;
using UnityEngine;

namespace Stats
{
    [Serializable]
    public class MinMaxInt
    {
        [SerializeField] private int min;
        [SerializeField] private int max;

        public int Min
        {
            get => min;
            set => min = value;
        }

        public int Max
        {
            get => max;
            set => max = value;
        }

        public MinMaxInt() {}
        
        public MinMaxInt(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public static MinMaxInt operator +(MinMaxInt a, MinMaxInt b)
        {
            a.Min += b.Min;
            a.Max += b.Max;
            
            return a;
        }
    }
}