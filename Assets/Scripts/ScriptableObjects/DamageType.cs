using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Damage Type", menuName = "Modular Stats/Damage Type", order = 1)]
    public class DamageType : ScriptableObject
    {
        [SerializeField] private string type;
        [SerializeField] private Color colour;

        public string Type => type;
        public Color Colour => colour;
    }
}