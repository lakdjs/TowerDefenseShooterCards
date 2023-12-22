using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using TowerSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyAI : MonoBehaviour
    {
        public bool ReadyToShoot { get; private set; }
        private List<Tower> _towers;
        private Enemy _enemy;
        private Transform _nearestTarget = null;
        private float _smallestDistance;
        private EnemyCombat _enemyCombat;
        private float _curSpeed;
        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _enemyCombat = GetComponent<EnemyCombat>();
            ReadyToShoot = false;   
        }

        private void Update()
        {
            Move(_nearestTarget);
        }

        private void StartMoving()
        {
            _towers = null;
            _towers = FindFirstObjectByType<TowerList>().Towers;
            _smallestDistance = Mathf.Infinity;
            _curSpeed = _enemy.MovementSpeed;
            for (int i = 0; i < _towers.Count; i++)
            {
                if (Vector2.Distance(_towers[i].transform.position, transform.position) < _smallestDistance)
                {
                    _nearestTarget = _towers[i].transform;
                    _smallestDistance = Vector2.Distance(_towers[i].transform.position, transform.position);
                }
            }
            Move(_nearestTarget);
        }

        private void FixedUpdate()
        {
            LookAtTarget();
        }

        /*IEnumerator RollCoroutine(Transform endPosition)
        {
            ReadyToShoot = false;
            float elapsedTime = 0f;

            if (endPosition != null)
            {
                while (Vector2.Distance(transform.position, endPosition.position) > 3.01f)
                {
                    elapsedTime += Time.deltaTime;
                    float t = Mathf.Clamp01(elapsedTime / _enemy.MovementSpeed);
                    transform.position = Vector2.Lerp(transform.position, endPosition.position, t);
                    yield return null;
                }
                ReadyToShoot = true;
            }
            
        }
*/
        private void Move(Transform endPosition)
        { 
            if (_nearestTarget == null)
            {
                StartMoving();
            }
            else
            {
                if (Vector2.Distance(transform.position, endPosition.position) > 3.01f)
                {
                    ReadyToShoot = false;
                    transform.position = Vector3.MoveTowards(transform.position, endPosition.position, _curSpeed);
                }
                else
                {
                    ReadyToShoot = true;
                }
            }
        }
        private void LookAtTarget()
        {
            if (_nearestTarget == null)
            {
                StartMoving();
            }
            else
            {
                Vector2 direction = _nearestTarget.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _enemy.Rb.rotation = angle;
            }
        }

        public void ChangeMovementSpeedForTime(float timeForBuff, float movementFactor)
        {
            StartCoroutine(TimerForChangingSpeed(timeForBuff, movementFactor));
        }

        private IEnumerator TimerForChangingSpeed(float time, float speedFactor)
        {
            float latestSpeed = _curSpeed;
            _curSpeed *= speedFactor;
            float timerTime = time;
            while (timerTime > 0)
            {
                yield return new WaitForSeconds(1);
                timerTime--;
            }

            _curSpeed = latestSpeed;
        }
    }
}
