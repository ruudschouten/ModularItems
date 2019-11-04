using System.Collections.Generic;
using UnityEngine;

namespace Items.Components
{
    public class WeaponComponent : ModifiableItem
    {
        [SerializeField] private List<Connector> connectors;
        [SerializeField] private Weapon connectedTo;
    }
}