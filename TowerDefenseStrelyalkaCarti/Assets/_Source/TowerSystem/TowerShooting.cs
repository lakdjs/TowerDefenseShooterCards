using System;
using System.Collections.Generic;
using EnemySystem;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerSystem
{
    public class TowerShooting : MonoBehaviour,IShootable
    {
        private Tower _tower;
        private Enemy _targetEnemy;
        private float _attackCounter;

        private void Start()
        {
            _tower = GetComponent<Tower>();
        }

        private void Update()
        {
            SetTargetEnemy();
        }

        private void SetTargetEnemy()
        {
            if (_targetEnemy == null)
            {
                Enemy nearestEnemy = GetNearestEnemy();
                if (nearestEnemy != null &&
                    Vector2.Distance(transform.position,
                        nearestEnemy.transform.position)
                    <= _tower.TowerRange)
                {
                    _targetEnemy = nearestEnemy;
                }
            }

            if (Vector2.Distance(transform.position,
                    _targetEnemy.transform.position)
                > _tower.TowerRange)
            {
                _targetEnemy = null;
            }
        }

        public void Attacking()
        {
            Instantiate(_tower.Projectile,_tower.FirePoint);
        }
        private List<Enemy> GetEnemiesInRange()
        {
            List<Enemy> enemiesInRange = new List<Enemy>();
            foreach (Enemy enemy in _tower.EnemyList.Enemies)
            {
                if (Vector2.Distance(transform.position, enemy.transform.position) <= _tower.TowerRange)
                {
                    enemiesInRange.Add(enemy);
                }
            }
            return enemiesInRange;
        }
        private Enemy GetNearestEnemy()
        {
            Enemy nearestEnemy = null;
            float smallestDistance = float.PositiveInfinity;

            foreach (Enemy enemy in GetEnemiesInRange())
            {
                if (Vector2.Distance(transform.position, enemy.transform.position) <= smallestDistance)
                {
                    smallestDistance = Vector2.Distance(transform.position, enemy.transform.position);
                    nearestEnemy = enemy;
                }
            }

            return nearestEnemy;
        }
        public void Shoot(Transform firePoint, GameObject bulletPrefab)
        {
            throw new System.NotImplementedException();
        }
    }
}
