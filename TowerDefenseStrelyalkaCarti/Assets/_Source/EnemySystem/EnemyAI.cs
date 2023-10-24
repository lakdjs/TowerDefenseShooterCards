using System;
using System.Collections;
using Interfaces;
using TowerSystem;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyAI : MonoBehaviour
    {
        public event Action<bool> OnTargetArrived;
        //public bool CanShoot { get; private set; } = false;
        private Transform _tower;
        private Enemy _enemy;
        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _tower = FindObjectOfType<Tower>().transform;
            StartCoroutine(RollCoroutine((_tower.transform)));
        }

        private void FixedUpdate()
        {
            LookAtTarget();
        }

        IEnumerator RollCoroutine(Transform endPosition)
        {
            float elapsedTime = 0f;
            
            while (Vector2.Distance(transform.position, endPosition.position) > 3.01f)
            {
                elapsedTime += Time.deltaTime;
                float t = Mathf.Clamp01(elapsedTime / _enemy.MovementSpeed);
                transform.position = Vector2.Lerp(transform.position, _tower.transform.position, t);
                yield return null;
            }
            OnTargetArrived?.Invoke(true);
        }
        private void LookAtTarget()
        {
           Vector2 direction = _tower.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _enemy.Rb.rotation = angle;
        }
    }
}
