using System;
using Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterHealth : MonoBehaviour, IDamageble
    {
        private Character _character;
        public float Health { get; private set; }

        private void Start()
        {
            _character = GetComponent<Character>();
            Health = _character.PlayerHealth;
        }

        private void TakingDamage(float damage)
        {
            if (damage > 0)
            {
                Health -= damage; 
                Debug.Log($"Health {Health}");
                return;
            }
            if(damage <= 0)
            {
                float hpNeededToFull = 100 - Health;
                if(hpNeededToFull < -damage)
                {
                    Health = 100;
                    Debug.Log($"Health {Health}");
                    return;
                }
                if (hpNeededToFull > -damage)
                {
                    Health -= damage;
                    Debug.Log($"Health {Health}");
                    return;
                }
                
            }
            Debug.Log($"Health {Health}");
        }
        public void TakeDamage(float damage)
        {
            TakingDamage(damage);
        }
    }
}
