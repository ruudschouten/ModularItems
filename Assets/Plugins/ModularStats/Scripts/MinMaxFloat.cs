using System;
using UnityEngine;

[Serializable]
public class MinMaxFloat
{
    [SerializeField] private float min;
    [SerializeField] private float max;

    public float Min
    {
        get => min;
        set => min = value;
    }

    public float Max
    {
        get => max;
        set => max = value;
    }

    public MinMaxFloat()
    {
    }

    public MinMaxFloat(float min, float max)
    {
        Min = min;
        Max = max;
    }

    public static MinMaxFloat operator +(MinMaxFloat a, MinMaxFloat b)
    {
        a.Min += b.Min;
        a.Max += b.Max;

        return a;
    }
}