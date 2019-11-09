using System;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Factories
{
    public abstract class AbstractFactory<T> : MonoBehaviour
    {
        [SerializeField] protected uint seed;

        protected Random Random;

        public virtual T Create()
        {
            throw new NotImplementedException();
        }

        protected virtual void Awake()
        {
            if (seed == 0)
            {
                seed = (uint) new System.Random().Next();
            }

            Random = new Random(seed);
        }

        protected int GetRandomInRangeOfCollection<T>(List<T> collection, int min = 0)
        {
            return Random.NextInt(min, collection.Count);
        }

        protected void Cleanup(Transform container)
        {
            foreach (Transform child in container)
            {
                Destroy(child.gameObject);
            }
        }
    }
}