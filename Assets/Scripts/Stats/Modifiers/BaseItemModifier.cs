using Stats;
using Stats.Modifiers;
using UnityEngine;

public abstract class BaseItemModifier : MonoBehaviour
{
    [SerializeField] private new string name;
    [SerializeField] private int requiredItemLevel;
    [SerializeField] private int tier;
    [SerializeField] private int maxAmount;
    [SerializeField] private ItemType domain;
    [SerializeField] private Statistics statistics;

    public string Name => name;
    public int RequiredItemLevel => requiredItemLevel;
    public int Tier => tier;
    public int MaxAmount => maxAmount;
    public ItemType Domain => domain;
    public Statistics Statistics => statistics;
}
