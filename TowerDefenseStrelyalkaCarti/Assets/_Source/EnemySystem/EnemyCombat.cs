using System;
using System.Collections;
using Interfaces;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyCombat : MonoBehaviour, IShootable
    {
        private bool _isShooting;
        private EnemyAI _enemyAI;
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _enemyAI = GetComponent<EnemyAI>();
        }

        private void Update()
        {
            if (_enemyAI.ReadyToShoot)
            {
                Shoot(_enemy.FirePoint, _enemy.BulletPrefab);
            }
        }

        private void Shooting(Transform firePoint, GameObject bulletPrefab)
        {
            StartCoroutine(attackShoot(firePoint, bulletPrefab));
        }

        public void Shoot(Transform firePoint, GameObject bulletPrefab)
        {
            Shooting(firePoint, bulletPrefab);
        }
        IEnumerator attackShoot(Transform firePoint, GameObject bulletPrefab)
        {
            if (!_isShooting)
            {
                _isShooting = true;
                Instantiate(bulletPrefab, firePoint);
                yield return new WaitForSeconds(_enemy.ShootCoolDown);
                _isShooting = false;
            }
        }
    }
}
