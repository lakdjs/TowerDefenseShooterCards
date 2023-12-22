using System;
using UnityEngine;
using UnityEngine.UI;

namespace HealthView
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Slider healthBar;
        
        public void UpdateHealthBar(float curHealth, float maxHealth)
        {
            healthBar.value = curHealth / maxHealth;
        }
    }
}
