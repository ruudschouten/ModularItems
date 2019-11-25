using System;
using Modifiers;
using ScriptableObjects.Types;
using Stats;

[Serializable]
public class DamageDictionary : SerializableDictionary<DamageType, DamageStat> {}

[Serializable]
public class ItemRarityWeights : SerializableDictionary<ItemRarity, float> {}

[Serializable]
public class ModifierTier : SerializableDictionary<int, Modifier> {}