using UnityEngine;
namespace GunSystem
{
    public class GunsChangeService
    {
        private static GunsChangeService instance;

        private GunsDataSO _gunsDataSo =
            Resources.Load("Guns") as GunsDataSO;

        public static GunsChangeService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GunsChangeService();
                }

                return instance;
            }
        }

        public void ChangingWeapon(GunTypes gunTypeToChange,
            out GunTypes currGunType,
            out int bulletCapacity,
            out int bulletQuantity,
            out float coolDown,
            out float damage)
        {
            currGunType = gunTypeToChange;
            bulletCapacity = 0;
            bulletQuantity = 0;
            coolDown = 0;
            damage = 0;
            foreach (var guns in _gunsDataSo.Guns)
            {
                if (currGunType == guns.GunType)
                {
                    bulletCapacity = guns.BulletCapacity;
                    bulletQuantity = guns.BulletsQuantityPerShot;
                    coolDown = guns.ShotCoolDown;
                    damage = guns.Damage;
                }
            }
        }
    }
}
