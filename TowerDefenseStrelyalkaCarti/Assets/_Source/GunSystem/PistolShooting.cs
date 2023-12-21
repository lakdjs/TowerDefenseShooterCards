using System;
using Interfaces;
using UnityEngine;

namespace GunSystem
{
    public class PistolShooting : AGun
    {
        public GunTypes GunType { get; private set; } = GunTypes.pistol;


        protected override void Shoot()
        {
            Debug.Log("PistolShoot");

        }
    }
}
