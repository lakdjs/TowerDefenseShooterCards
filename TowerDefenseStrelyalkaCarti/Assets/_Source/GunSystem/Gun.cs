using System;
using UnityEngine;

namespace GunSystem
{
    [Serializable]
    public class Gun 
    {
        [field: SerializeField] public GunTypes GunType { get; private set; }
        [field: SerializeField] public int BulletCapacity { get; private set; }
        [field: SerializeField] public float ShotCoolDown { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public int BulletsQuantityPerShot { get; private set; }
    }
}
