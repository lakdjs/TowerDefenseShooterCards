using UnityEngine;

namespace EnemySystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        
        [field: SerializeField] public float EnemyHealth { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float ShootCoolDown { get; private set; }
        [field: SerializeField] public Rigidbody2D Rb { get; private set; }
        [field: SerializeField] public GameObject BulletPrefab { get; private set; }
        [field: SerializeField] public Transform FirePoint { get; private set; }
    }
}
