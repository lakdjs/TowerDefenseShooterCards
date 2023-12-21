using System;
using Interfaces;
using UnityEngine;

namespace GunSystem
{
    public class PistolShooting : AGun
    {
        public GunTypes GunType { get; private set; } = GunTypes.pistol;


        protected override void Shooting(Transform firePoint, GameObject bulletPrefab)
        {
            GameObject.Instantiate(bulletPrefab,firePoint);
            Debug.Log("PistolShoot");
        }
    }
}
