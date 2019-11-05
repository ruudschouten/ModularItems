using System.Collections.Generic;
using System.Linq;
using ScriptableObjects.Types;
using Stats;
using UnityEngine;

namespace Items.Components
{
    public class ItemComponent : ModifiableItem
    {
        [SerializeField] private List<DamageStat> damage;
        [SerializeField] private List<Connector> connectors;
        [SerializeField] private List<ConnectorPosition> preferredPosition;

        public List<DamageStat> Damage => damage;

        public List<ConnectorPosition> PreferredPosition => preferredPosition;
        public List<Connector> Connectors => connectors;

        // Used primarily to let the Weapon know a component has been added to it, and its Components have changed 
        public bool Changed
        {
            get => _changed;
            set => _changed = value;
        }

        public List<Connector> FreeConnectors
        {
            get
            {
                if (_freeConnectors != null && !_changed)
                {
                    return _freeConnectors;
                }
                
                _freeConnectors = new List<Connector>();

                foreach (var connector in Connectors)
                {
                    if (_usedPositions.Contains(connector.ApplyablePosition)) continue;
                    
                    _freeConnectors.Add(connector);
                }

                return _freeConnectors;
            }
        } 

        private bool _changed;
        private int _usedConnectors;
        private List<ConnectorPosition> _usedPositions = new List<ConnectorPosition>();
        private List<Connector> _freeConnectors;

        public bool HasConnectors()
        {
            return connectors.Count > 0;
        }

        public bool ConnectorsLeft()
        {
            return connectors.Count > _usedConnectors;
        }

        public Connector GetAvailableConnector(List<ConnectorPosition> positions)
        {
            return (from connector in FreeConnectors 
                from position in positions 
                where connector.ApplyablePosition == position 
                select connector).FirstOrDefault();
        }

        public bool CanAddComponent()
        {
            if (!HasConnectors()) return false;
            if (!ConnectorsLeft()) return false;
            
            return true;
        }
        
        /// <summary>
        /// Adds <paramref name="component"/> to this item if it has connectors left and if the preferred position is found.
        /// </summary>
        /// <param name="component">Component to add</param>
        /// <returns></returns>
        public void AddComponent(ItemComponent component)
        {
            var availableConnector = GetAvailableConnector(component.PreferredPosition);
            
            if (availableConnector == null)
            {
                // Couldn't fit component on preferred position, add it somewhere else
                availableConnector = connectors.First(x => x.Component == null);
            }

            availableConnector.Connect(component);
            
            _usedConnectors++;
            _usedPositions.Add(availableConnector.ApplyablePosition);
            _changed = true;
        }
    }
}