using System.Collections.Generic;
using ScriptableObjects.Collections;
using ScriptableObjects.Types;
using UnityEngine;

namespace ScriptableObjects
{
    public class DamageTypeHelper
    {
        protected List<DamageType> Types;
        protected string[] StringTypes;

        public void LoadTypes()
        {
            Types = new List<DamageType>();
            var collection = (DamageTypeCollection) Resources.Load(GetResourcePathFromCollection(), 
                typeof(DamageTypeCollection));
            
            StringTypes = new string[collection.Entries.Count];

            for (var i = 0; i < collection.Entries.Count; i++)
            {
                var type = collection.Entries[i];
                Types.Add(type);
                StringTypes[i] = type.name;
            }
        }

        public string GetTypeName()
        {
            return typeof(DamageType).Name;
        }
        
        public int GetIndex(DamageType type)
        {
            return Types.IndexOf(type);
        }

        public string[] GetStringTypes()
        {
            return StringTypes;
        }

        public List<DamageType> GetTypes()
        {
            return Types;
        }

        public string GetStringFromIndex(int index)
        {
            return StringTypes[index];
        }

        public DamageType GetFromIndex(int index)
        {
            return Types[index];
        }

        private string GetResourcePathFromCollection()
        {
            return $"ModularStats/{GetTypeName()}/_Collection";
        }
    }
}