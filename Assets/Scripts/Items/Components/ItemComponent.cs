using System.Collections.Generic;
using System.Linq;
using ScriptableObjects.Types;
using UnityEngine;

namespace Items.Components
{
    public class ItemComponent : ModifiableItem
    {
        [SerializeField] private ItemComponent anchor;
        [SerializeField] private List<Connector> connectors;
        [SerializeField] private List<ConnectorPosition> preferredPosition;

        public List<ConnectorPosition> PreferredPosition => preferredPosition;
        
        private int _usedConnectors;

        public bool HasConnectors()
        {
            return connectors.Count > 0;
        }

        public bool ConnectorsLeft()
        {
            return connectors.Count > _usedConnectors;
        }

        public bool HitMaxConnectors()
        {
            return Rarity.MaxConnectors < connectors.Count;
        }

        public Connector GetAvailableConnector(List<ConnectorPosition> positions)
        {
            return (from connector in connectors 
                from applyablePosition in connector.ApplyablePositions 
                from position in positions 
                where applyablePosition == position 
                select connector).FirstOrDefault();
        }

        /// <summary>
        /// Adds <paramref name="component"/> to this item if it has connectors left and if the preferred position is found.
        /// </summary>
        /// <param name="component">Component to add</param>
        /// <returns></returns>
        public bool AddComponent(ItemComponent component)
        {
            if (!HasConnectors()) return false;
            if (!ConnectorsLeft()) return false;
            if (HitMaxConnectors()) return false;
            var availableConnector = GetAvailableConnector(component.PreferredPosition);
            if (availableConnector == null) return false;

            availableConnector.Connect(component);
            
            _usedConnectors++;
            return true;
        }
    }
}