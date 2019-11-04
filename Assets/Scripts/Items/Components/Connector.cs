using ScriptableObjects.Types;
using UnityEngine;

namespace Items.Components
{
    public class Connector : MonoBehaviour
    {
        [SerializeField] private Connector connectedTo;
        [SerializeField] private ConnectorPositionDropdown position;

        public Connector ConnectedTo
        {
            get => connectedTo;
            set => connectedTo = value;
        }

        public ConnectorPosition Position => position.Type;
    }
}