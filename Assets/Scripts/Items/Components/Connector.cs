using System.Collections.Generic;
using ScriptableObjects.Types;
using UnityEngine;

namespace Items.Components
{
    public class Connector : MonoBehaviour
    {
        [SerializeField] private ItemComponent component;
        [SerializeField] private ConnectorPositionDropdown applyablePosition;

        public ItemComponent Component
        {
            get => component; 
            set => component = value;
        }

        public ConnectorPosition ApplyablePosition => applyablePosition.Type;

        public void Connect(ItemComponent comp)
        {
            Component = comp;
            comp.transform.position = transform.position;
            comp.transform.SetParent(transform);
            comp.transform.rotation = Quaternion.identity;
        }
    }
}