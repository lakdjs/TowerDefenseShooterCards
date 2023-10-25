using EnemySystem;
using UnityEngine;

namespace TowerSystem
{
    public class Tower : MonoBehaviour
    {
        [field: SerializeField] public EnemyList EnemyList { get; private set; }
        [field: SerializeField] public float TowerHealth { get; private set; }
        [field: SerializeField] public float TowerRange { get; private set; }
        [field: SerializeField] public float CoolDown { get; private set; }
        [field: SerializeField] public GameObject Projectile { get; private set; }
        [field: SerializeField] public Transform FirePoint { get; private set; }
    }
}
