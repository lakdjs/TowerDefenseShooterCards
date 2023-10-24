using Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterShooting : IShootable
    {
           private void Shooting(Transform firePoint, GameObject bulletPrefab)
           {
               GameObject.Instantiate(bulletPrefab,firePoint);
           }
           
           public void Shoot(Transform firePoint, GameObject bulletPrefab)
           {
               Shooting(firePoint,bulletPrefab);
           }
    }
}
