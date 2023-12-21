using System;
using Core;
using Interfaces;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyHealth : MonoBehaviour, IDamageble
    {
        private Enemy _enemy;
        private float _health;
        private Bootstrapper _bootstrapper;
        private void Start()
        {
            _bootstrapper = FindFirstObjectByType<Bootstrapper>();
            _enemy = GetComponent<Enemy>();
            _enemy.HpSetedUp += GetHp;
            _health = _enemy.EnemyHealth;
        }

        private void GetHp(float hp)
        {
            _health = hp;
            Debug.Log(_health);
        }
        private void TakingDamage(float damage)
        {
            _health -= damage;
            Debug.Log($"EnemyHealth {_health}");
            if (_health <= 0)
            {
                _enemy.EnemyList.RemoveEnemyFromList(_enemy);
                _bootstrapper.Score.AddScore(_enemy.Gold);
                Destroy(gameObject);
            }
        }
        public void TakeDamage(float damage)
        {
            TakingDamage(damage);
        }
    }
}
