using System;
using ScriptableObjects.Types;
using Stats;

[Serializable]
public class DamageDictionary : SerializableDictionary<DamageType, MinMaxInt> {}
