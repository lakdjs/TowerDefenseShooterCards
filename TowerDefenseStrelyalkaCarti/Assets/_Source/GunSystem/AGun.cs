using System;
using Interfaces;
using UnityEngine;

namespace GunSystem
{
    public abstract class AGun : IShootable
    {
        protected abstract void Shoot();
        public void Shoot(Transform firePoint, GameObject bulletPrefab)
        {
            Shoot();
        }
    }
}
