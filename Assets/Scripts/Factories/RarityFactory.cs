using System.Linq;
using DataStructures.RandomSelector;
using ScriptableObjects.Types;
using UnityEngine;

namespace Factories
{
    public class RarityFactory : AbstractFactory<ItemRarity>
    {
        [SerializeField] private ItemRarityWeights itemRarity;

        private DynamicRandomSelector<ItemRarity> _selector;

        private void Awake()
        {
            _selector = new DynamicRandomSelector<ItemRarity>();

            var index = 0;
            foreach (var pair in itemRarity)
            {
                _selector.Add(pair.Key, pair.Value);
                
                index++;
            }

            _selector.Build((int) seed);
        }
        
        public override ItemRarity Create()
        {
            return _selector.SelectRandomItem();;
        }
    }
}
