using System;
using EnemySystem;
using TowerSystem;
using UnityEngine;


namespace AmmoSystem
{
    public class Projectile : ABullet
    {
        private Enemy _target;
        private Tower _tower;

        private void Update()
        {
            Fly();
        }

        public override void Fly()
        {
            if (_target == null)
            {
                Destroy(gameObject);
            }
            else
            {
                Vector2 dir = _target.transform.position - _tower.FirePoint.transform.position;
                float angleDir = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angleDir, Vector3.forward);
                transform.position = Vector2.MoveTowards(transform.position, _target.transform.position,
                    speed * Time.deltaTime);
            }
        }

        public void SetTargetAndTower(Enemy target, Tower tower)
        {
            _tower = tower;
            _target = target;
        }
    }
}
