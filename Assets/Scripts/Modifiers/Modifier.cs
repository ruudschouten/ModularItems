using Stats;
using UnityEngine;

namespace Modifiers
{
    public class Modifier : MonoBehaviour
    {
        [SerializeField] private new string name;
        [SerializeField] private int requiredItemLevel;
        [SerializeField] private int maxAmount = 1;
        [SerializeField] private Statistics statistics;

        public string Name => name;
        public int RequiredItemLevel => requiredItemLevel;
        public int MaxAmount => maxAmount;
        public Statistics Statistics => statistics;
    }
}
