using System.Collections.Generic;
using ScriptableObjects.Collections;
using UnityEngine;

namespace ScriptableObjects.Helpers
{
    public abstract class ScriptableObjectHelper<T, TCollection> 
        where T : ScriptableObject, new() where TCollection : ScriptableCollection<T>
    {
        protected List<T> Types;
        protected string[] StringTypes;

        public void LoadTypes()
        {
            Types = new List<T>();
            var scriptableObjects = (TCollection) Resources.Load(GetResourcePathFromCollection(), typeof(TCollection));
            
            StringTypes = new string[scriptableObjects.Entries.Count];

            for (var i = 0; i < scriptableObjects.Entries.Count; i++)
            {
                var type = scriptableObjects.Entries[i];
                Types.Add(type);
                StringTypes[i] = type.name;
            }
        }

        public string GetTypeName()
        {
            return typeof(T).Name;
        }
        
        public int GetIndex(T type)
        {
            return Types.IndexOf(type);
        }

        public string[] GetStringTypes()
        {
            return StringTypes;
        }

        public List<T> GetTypes()
        {
            return Types;
        }

        public string GetStringFromIndex(int index)
        {
            return StringTypes[index];
        }

        public T GetFromIndex(int index)
        {
            return Types[index];
        }

        private string GetResourcePathFromCollection()
        {
            return $"ScriptableObjects/{GetTypeName()}/_Collection";
        }
    }
}