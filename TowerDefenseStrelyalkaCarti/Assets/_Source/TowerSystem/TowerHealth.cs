using EnemySystem;
using Interfaces;
using Unity.VisualScripting;
using UnityEngine;

namespace TowerSystem
{
    public class TowerHealth : MonoBehaviour, IDamageble
    {
        private Tower _tower;
        private float _health;
        private void Start()
        {
            _tower = GetComponent<Tower>();
            _health = _tower.TowerHealth;
        }

        private void TakingDamage(float damage)
        {
            _health -= damage;
            Debug.Log($"Health {_health}");
            if (_health <= 0)
            {
                if (transform.tag == "Throne")
                {
                    _health = 100;
                    return;
                }
                //_tower.EnemyList.StopAllEnemies();
                _tower.TowerList.RemoveTowerFromList(_tower);
                Destroy(gameObject);
            }
        }
        public void TakeDamage(float damage)
        {
            TakingDamage(damage);
        }
    }
}
