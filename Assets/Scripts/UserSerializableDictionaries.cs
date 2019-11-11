using System;
using ScriptableObjects.Types;
using Stats;
using Stats.Modifiers;
using UnityEngine;

[Serializable]
public class DamageDictionary : SerializableDictionary<DamageType, MinMaxInt> {}

[Serializable]
public class ItemRarityWeights : SerializableDictionary<ItemRarity, float> {}

[Serializable]
public class ModifierTier : SerializableDictionary<int, Modifier> {}