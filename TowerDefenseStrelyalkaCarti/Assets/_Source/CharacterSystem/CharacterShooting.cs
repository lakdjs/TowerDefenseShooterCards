using System;
using GunSystem;
using Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterShooting : IShootable
    {
           public event Action<int> OnShooten;
           private GunReload _gunReload;
           private GunChange _gunChange;
           private AGun _aGun;
           private GunTypes _gunTypes;
           private GunsDataSO _gunsDataSo = Resources.Load("Guns") as GunsDataSO;
           private int _bulletsPerShot;
           private float _damage;
           public CharacterShooting(GunChange gunChange)
           {
               _gunChange = gunChange;
               
               _gunChange.OnGunChanged += ChangeGun;
           }

           public void Construct(GunReload gunReload)
           {
               _gunReload = gunReload;
           }
           private void ChangeGun(GunTypes gunTypes)
           {
               _gunTypes = _gunChange.gunType;
               
               switch (_gunTypes)
               {
                   case GunTypes.pistol:
                       _aGun = new PistolShooting();
                       break;
                   case GunTypes.rifle:
                       _aGun = new RifleShooting();
                       break;
                   case GunTypes.shotgun:
                       _aGun = new ShotgunShooting();
                       break;
               }

               foreach (var gun in _gunsDataSo.Guns)
               {
                   if (gun.GunType == _gunTypes)
                   {
                       _bulletsPerShot = gun.BulletsQuantityPerShot;
                       _damage = gun.Damage;
                   }
               }
           }
           private void Shooting(Transform firePoint, GameObject bulletPrefab)
           {
               if (_gunReload.CanShoot)
               {
                   _aGun.Shoot(firePoint, bulletPrefab);
                   OnShooten?.Invoke(-_bulletsPerShot);
               }
           }
           public void Shoot(Transform firePoint, GameObject bulletPrefab)
           {
               Shooting(firePoint,bulletPrefab);
           }
    }
}
