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
            SetUp();
            EnemyList = FindFirstObjectByType<EnemyList>();
            EnemyList.AddEnemyInList(this); //gameObject.GetComponent<Enemy>());
        }
        [field: SerializeField] public EnemyTypes EnemyTypes { get; private set; }
        private float _enemyHealth;
        private float _enemyDamage;
        private float _enemySpeed;
        private float _enemyCoolDown;
        private int  _enemyGold;
        public float EnemyHealth
        {
            get => _enemyHealth;
        }
        public float Damage
        {
            get => _enemyDamage;
        }

        public int Gold
        {
            get => _enemyGold;
        }

        public float MovementSpeed
        {
            get => _enemySpeed; 
        }
        public float ShootCoolDown
        {
            get => _enemyCoolDown;
        }
        [field: SerializeField] public Rigidbody2D Rb { get; private set; }
        [field: SerializeField] public GameObject BulletPrefab { get; private set; }
        [field: SerializeField] public Transform FirePoint { get; private set; }

        private void SetUp()
        {
            EnemySetUpService.Instance.SetUpEnemy(EnemyTypes,
                out _enemyHealth,
                out _enemyDamage,
                out _enemyGold,
                out _enemySpeed,
                out _enemyCoolDown);
        }
    }
}
