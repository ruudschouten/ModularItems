using ScriptableObjects.Collections;
using ScriptableObjects.Types;
using UnityEditor;

namespace Editor.DropDownPropertyDrawers
{
    [CustomPropertyDrawer(typeof(ConnectorPositionDropdown))]
    public class ConnectorPositionDropdownDrawer : ScriptableDropdownDrawer<ConnectorPosition, ConnectorPositionCollection, ConnectorPositionHelper>
    {
        protected override ConnectorPositionHelper GetHelper()
        {
            return new ConnectorPositionHelper();
        }
    }
}