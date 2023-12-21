using System;
using Interfaces;
using UnityEngine;

namespace GunSystem
{
    public class RifleShooting : AGun
    {
        public GunTypes GunType { get; private set; } = GunTypes.rifle;
        

        protected override void Shoot()
        {
            Debug.Log("rifleShoot");
        }
    }
}
