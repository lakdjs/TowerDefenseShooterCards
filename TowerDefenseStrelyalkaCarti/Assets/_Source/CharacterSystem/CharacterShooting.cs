using GunSystem;
using Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterShooting : IShootable
    {
           private GunChange _gunChange;
           private AGun _aGun;
           private GunTypes _gunTypes;
           public CharacterShooting(GunChange gunChange)
           {
               _gunChange = gunChange;
               _gunChange.OnGunChanged += ChangeGun;
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
           }
           private void Shooting(Transform firePoint, GameObject bulletPrefab)
           {
               _aGun.Shoot(firePoint, bulletPrefab);
           }
           
           public void Shoot(Transform firePoint, GameObject bulletPrefab)
           {
               Shooting(firePoint,bulletPrefab);
           }
    }
}
