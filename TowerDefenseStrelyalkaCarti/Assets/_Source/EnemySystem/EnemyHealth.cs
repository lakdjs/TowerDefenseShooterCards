using Interfaces;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyHealth : MonoBehaviour, IDamageble
    {
        private Enemy _enemy;
        private float _health;
        
        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _health = _enemy.EnemyHealth;
        }

        private void TakingDamage(float damage)
        {
            _health -= damage;
            Debug.Log($"EnemyHealth {_health}");
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
        }
        public void TakeDamage(float damage)
        {
            TakingDamage(damage);
        }
    }
}
