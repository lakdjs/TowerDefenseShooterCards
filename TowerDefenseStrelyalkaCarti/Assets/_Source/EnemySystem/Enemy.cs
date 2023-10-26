using System;
using UnityEngine;

namespace EnemySystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        public EnemyList EnemyList { get; private set; }

        private void Start()
        {
            EnemyList = FindFirstObjectByType<EnemyList>();
            EnemyList.AddEnemyInList(this); //gameObject.GetComponent<Enemy>());
        }
        
        [field: SerializeField] public float EnemyHealth { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public int Gold { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float ShootCoolDown { get; private set; }
        [field: SerializeField] public Rigidbody2D Rb { get; private set; }
        [field: SerializeField] public GameObject BulletPrefab { get; private set; }
        [field: SerializeField] public Transform FirePoint { get; private set; }
    }
}
