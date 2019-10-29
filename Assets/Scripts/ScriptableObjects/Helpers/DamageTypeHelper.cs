using ScriptableObjects.Collections;

namespace ScriptableObjects.Helpers
{
    public class DamageTypeHelper : ScriptableObjectHelper<DamageType, DamageTypeCollection>
    {
        public DamageTypeHelper() : base("ScriptableObjects/Damage Types/_Collection")
        {
        }
    }
}