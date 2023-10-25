using System;
using System.Collections;
using System.Collections.Generic;
using AmmoSystem;
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
        private float _attackCounter = 3;
        private bool _isAttacking;
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
            _attackCounter -= Time.deltaTime;
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
            else
            {
                if (_attackCounter <= 0)
                {
                    _isAttacking = true;
                    _attackCounter = _tower.CoolDown;
                }
                else
                {
                    _isAttacking = false;
                }
                if (Vector2.Distance(transform.position,
                        _targetEnemy.transform.position)
                    > _tower.TowerRange)
                {
                    _targetEnemy = null;
                }
            }
        }

        public void FixedUpdate()
        {
            if (_isAttacking )
            {
                Attacking();
            }
        }

        public void Attacking()
        {
            _isAttacking = false;
            GameObject newProjectile = Instantiate(_tower.Projectile,_tower.FirePoint);
            if (_targetEnemy == null)
            {
                Destroy(newProjectile);
            }
            else
            {
               StartCoroutine(MoveProjectile(newProjectile));
            }
        }

        IEnumerator MoveProjectile(GameObject projectile)
        {
            while (GetTargetDistance(_targetEnemy) > 0.2f && projectile != null && _targetEnemy != null)
            {
                var dir = _targetEnemy.transform.position - transform.position;
                var angleDir = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                projectile.transform.rotation = Quaternion.AngleAxis(angleDir, Vector3.forward);
                projectile.transform.position = Vector2.MoveTowards(projectile.transform.position,
                    _targetEnemy.transform.position,
                    5f * Time.deltaTime);
                yield return null;
            }

            if (projectile != null || _targetEnemy == null)
            {
                Destroy(projectile);
            }
        }

        private float GetTargetDistance(Enemy thisEnemy)
        {
            if (thisEnemy == null)
            {
                thisEnemy = GetNearestEnemy();
                if (thisEnemy == null)
                {
                    return 0f;
                }
            }

            return Mathf.Abs(Vector2.Distance(transform.position, thisEnemy.transform.position));
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
