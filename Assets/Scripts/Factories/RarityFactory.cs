using DataStructures.RandomSelector;
using ScriptableObjects.Types;
using UnityEngine;

namespace Factories
{
    public class RarityFactory : AbstractFactory<ItemRarity>
    {
        [SerializeField] private ItemRarityWeights itemRarity;

        private DynamicRandomSelector<int> _selector;

        private void Awake()
        {
            _selector = new DynamicRandomSelector<int>();

            var index = 0;
            foreach (var pair in itemRarity)
            {
                _selector.Add(index, pair.Value);
                
                index++;
            }

            _selector.Build((int) seed);
        }
        
        public int GetIndex()
        {
            return _selector.SelectRandomItem();
        }
    }
}
