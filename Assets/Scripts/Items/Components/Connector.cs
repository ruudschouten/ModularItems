using System.Collections.Generic;
using ScriptableObjects.Types;
using UnityEngine;

namespace Items.Components
{
    public class Connector : MonoBehaviour
    {
        [SerializeField] private ItemComponent component;
        [SerializeField] private List<ConnectorPosition> applyablePositions;

        public ItemComponent Component
        {
            get => component; 
            set => component = value;
        }

        public List<ConnectorPosition> ApplyablePositions => applyablePositions;

        public void Connect(ItemComponent component)
        {
            Component = component;
            component.transform.position = transform.position;
            component.transform.SetParent(transform);
            component.transform.rotation = Quaternion.identity;
        }
    }
}