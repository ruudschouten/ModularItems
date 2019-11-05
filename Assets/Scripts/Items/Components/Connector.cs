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
            comp.transform.SetParent(transform, false);
//            comp.transform.position = transform.position;
            comp.transform.rotation = new Quaternion();
            
            Component = comp;
        }
    }
}