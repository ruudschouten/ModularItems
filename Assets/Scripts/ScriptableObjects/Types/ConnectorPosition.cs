using System;
using ScriptableObjects.Collections;
using ScriptableObjects.DropDown;
using ScriptableObjects.Helpers;
using UnityEngine;

namespace ScriptableObjects.Types
{
    [CreateAssetMenu(fileName = "Connector Position", menuName = "Modular Items/Connector Position")]
    public class ConnectorPosition : ScriptableObject
    {
        [SerializeField] private float weight;

        public float Weight => weight;
    }

    [Serializable]
    public class ConnectorPositionDropdown : ScriptableDropdown<ConnectorPosition>
    {
    }

    public class ConnectorPositionHelper : ScriptableObjectHelper<ConnectorPosition, ConnectorPositionCollection>
    {
    }
}