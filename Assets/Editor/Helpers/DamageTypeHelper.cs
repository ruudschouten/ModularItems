using System.Collections.Generic;
using ScriptableObjects;
using ScriptableObjects.Collections;
using UnityEngine;

namespace Editor.Helpers
{
    public class DamageTypeHelper
    {
        private static List<DamageType> _types;
        private static string[] _stringTypes;

        public static void LoadDamageTypes()
        {
            _types = new List<DamageType>();
            var scriptableObjects =
                (DamageTypeCollection) Resources.Load("ScriptableObjects/Damage Types/_Collection", typeof(DamageTypeCollection));
            _stringTypes = new string[scriptableObjects.Entries.Count];
            for (var i = 0; i < scriptableObjects.Entries.Count; i++)
            {
                var damageTypes = scriptableObjects.Entries[i];
                _types.Add(damageTypes);
                _stringTypes[i] = damageTypes.name;
            }
        }

        public static int GetIndex(DamageType type)
        {
            return _types.IndexOf(type);
        }

        public static string[] GetStringSet()
        {
            return _stringTypes;
        }

        public static List<DamageType> GetTypes()
        {
            if(_types == null) LoadDamageTypes();
            return _types;
        }

        public static string GetStringFromIndex(int index)
        {
            return _stringTypes[index];
        }

        public static DamageType GetFromIndex(int index)
        {
            return _types[index];
        }
    }
}