using Interfaces;
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
        }
        public void TakeDamage(float damage)
        {
            TakingDamage(damage);
        }
    }
}
