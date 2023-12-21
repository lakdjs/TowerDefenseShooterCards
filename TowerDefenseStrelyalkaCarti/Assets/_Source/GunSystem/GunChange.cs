using System;
using UnityEngine;

namespace GunSystem
{
    public class GunChange : MonoBehaviour
    {
        public event Action<GunTypes> OnGunChanged;
        public GunTypes gunType;
        private int _bulletCapacity;
        private float _shotCoolDown;
        private float _damage;
        private int _bulletsQuantityPerShot;

        //private void OnEnable()
        //{
        //    ChangingGun(gunType);
        //}

        private void Update()
        {
            Debug.Log(gunType);
            Debug.Log($"cooldown : {_shotCoolDown}");
            Debug.Log($"damage : {_damage}");
            Debug.Log($"quantity : {_bulletsQuantityPerShot}");
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangingGun(GunTypes.pistol);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangingGun(GunTypes.rifle);
            }
            
            if (Input.GetKeyDown(KeyCode.B))
            {
                ChangingGun(GunTypes.shotgun);
            }
        }

        public void ChangingGun(GunTypes gunTypeToChange)
        {
            GunsChangeService.Instance.ChangingWeapon(gunTypeToChange,
                out gunType, 
                out _bulletCapacity,
                out _bulletsQuantityPerShot,
                out _shotCoolDown,
                out _damage);
            OnGunChanged?.Invoke(gunTypeToChange);
        }
    }
}
