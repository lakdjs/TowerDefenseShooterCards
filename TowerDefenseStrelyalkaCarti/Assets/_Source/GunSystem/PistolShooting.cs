using Interfaces;
using UnityEngine;

namespace GunSystem
{
    public class PistolShooting : AGun
    {
        public GunTypes GunTypes { get; private set; } = GunTypes.pistol;
        protected override void Shoot()
        {
            Debug.Log("PistolShoot");
        }
    }
}
