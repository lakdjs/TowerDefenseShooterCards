using System;
using UnityEngine;

namespace GunSystem
{
    public class ShotgunShooting : AGun
    {
        public GunTypes GunType { get; private set; } = GunTypes.shotgun;

        protected override void Shoot()
        {
            Debug.Log("shotgunShoot");
        }
    }
}
