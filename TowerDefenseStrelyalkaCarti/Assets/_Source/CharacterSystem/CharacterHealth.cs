using System;
using Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterHealth : MonoBehaviour, IDamageble
    {
        private Character _character;
        private float _health;
        
        private void Start()
        {
            _character = GetComponent<Character>();
            _health = _character.PlayerHealth;
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
