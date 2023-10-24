using UnityEngine;

namespace Interfaces
{
    public interface IShootable 
    {
        public void Shoot(Transform firePoint, GameObject bulletPrefab);
    }
}
