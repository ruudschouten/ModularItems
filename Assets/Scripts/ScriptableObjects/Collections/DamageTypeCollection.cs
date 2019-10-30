using ScriptableObjects.Types;
using UnityEngine;

namespace ScriptableObjects.Collections
{
    [CreateAssetMenu(fileName = "_Collection", menuName = "Modular Items/Collections/Damage Type")]
    public class DamageTypeCollection : ScriptableCollection<DamageType>
    {
    }
}