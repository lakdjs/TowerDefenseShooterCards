using System;
using Interfaces;
using UnityEngine;

namespace GunSystem
{
    public abstract class AGun : IShootable
    {
        protected abstract void Shooting(Transform firePoint, GameObject bulletPrefab);
        public void Shoot(Transform firePoint, GameObject bulletPrefab)
        {
            Shooting(firePoint, bulletPrefab);
        }
    }
}
