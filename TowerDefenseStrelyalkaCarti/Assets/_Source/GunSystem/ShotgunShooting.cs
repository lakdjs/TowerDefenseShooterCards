using System;
using UnityEngine;

namespace GunSystem
{
    public class ShotgunShooting : AGun
    {
        public GunTypes GunType { get; private set; } = GunTypes.shotgun;

        protected override void Shooting(Transform firePoint, GameObject bulletPrefab)
        {
            GameObject.Instantiate(bulletPrefab,firePoint);
            Vector3 rot = new Vector3(0, 0, 30);
            GameObject bullet2 = GameObject.Instantiate(bulletPrefab,firePoint);
            bullet2.transform.Rotate(new Vector3(0,0,-30));
            GameObject bullet3 = GameObject.Instantiate(bulletPrefab,firePoint);
            bullet3.transform.Rotate(new Vector3(0,0,30));
            Debug.Log("shotgunShoot");
        }
    }
}
