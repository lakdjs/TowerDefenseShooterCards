using UnityEngine;

namespace TowerSystem
{
    public class Tower : MonoBehaviour
    {
        [field: SerializeField] public float TowerHealth { get; private set; }
        [field: SerializeField] public float TowerRange { get; private set; }
        [field: SerializeField] public float CoolDown { get; private set; }
    }
}
