using System;
using System.Collections;
using Core;
using GunSystem;
using HealthView;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyHealth : MonoBehaviour, IDamageble, IAoeDamageble
    {
        [SerializeField] private HealthBarView healthBarView;
        private Enemy _enemy;
        private float _health;
        private float _maxHealth;
        private Bootstrapper _bootstrapper;
        private void Start()
        {
            _bootstrapper = FindFirstObjectByType<Bootstrapper>();
            _enemy = GetComponent<Enemy>();
            _enemy.HpSetedUp += GetHp;
            _health = _enemy.EnemyHealth;
            _maxHealth = _health;
        }

        private void GetHp(float hp)
        {
            _health = hp;
            healthBarView.UpdateHealthBar(_health, _maxHealth);
            Debug.Log(_health);
        }
        private void TakingDamage(float damage)
        {
            _health -= damage;
            healthBarView.UpdateHealthBar(_health, _maxHealth);
           // Debug.Log($"EnemyHealth {_health}");
            if (_health <= 0)
            {
                _enemy.EnemyList.RemoveEnemyFromList(_enemy);
                _bootstrapper.Score.AddScore(_enemy.Gold);
                Destroy(gameObject);
            }
        }

        private void TakingAoeDamage(float damagePerSecond, float time)
        {
            StartCoroutine(TimerForAoeDamage(time, damagePerSecond));
        }

        IEnumerator TimerForAoeDamage(float time, float damage)
        {
            float timerTime = time;
            while (timerTime > 0)
            {
                yield return new WaitForSeconds(1);
                timerTime--;
                TakeDamage(damage);
            }
        }
        public void TakeDamage(float damage)
        {
            TakingDamage(damage);
        }

        public void TakeAoeDamage(float damage, float time)
        {
            TakingAoeDamage(damage, time);
        }
    }
}
