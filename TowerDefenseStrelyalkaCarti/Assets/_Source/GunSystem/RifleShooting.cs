using System;
using Interfaces;
using UnityEngine;

namespace GunSystem
{
    public class RifleShooting : AGun
    {
        public GunTypes GunType { get; private set; } = GunTypes.rifle;
        

        protected override void Shooting(Transform firePoint, GameObject bulletPrefab)
        {
            GameObject.Instantiate(bulletPrefab,firePoint);
            Debug.Log("rifleShoot");
        }
    }
}
