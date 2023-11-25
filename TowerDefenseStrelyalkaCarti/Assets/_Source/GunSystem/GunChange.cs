using System;
using UnityEngine;

namespace GunSystem
{
    public class GunChange : MonoBehaviour
    {
        public Action<GunTypes> OnGunChanged;
        [SerializeField] private GunTypes gunType;
        private int _bulletCapacity;
        private float _shotCoolDown;
        private float _damage;
        private int _bulletsQuantityPerShot;

        private void Start()
        {
            ChangingGun(gunType);
        }

        private void Update()
        {
            Debug.Log(gunType);
            Debug.Log($"capacity : {_bulletCapacity}");
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
