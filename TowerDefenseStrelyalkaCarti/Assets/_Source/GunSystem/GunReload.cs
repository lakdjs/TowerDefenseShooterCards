using System;
using CharacterSystem;
using UnityEngine;

namespace GunSystem
{
    public class GunReload
    {
        public bool CanShoot { get; private set; } = true;
        private GunChange _gunChange;
        private CharacterShooting _characterShooting;
        private int _ammoCount;//обойма
        private int _currAmmo;//в новом оружии
        private int _ammo;//в 1ой обойме
        private float _reloadSpeed;
        private float _reloadTimer = 0.0f;
        private bool IsReloading = false;

        public GunReload(CharacterShooting characterShooting, GunChange gunChange)
        {
            _characterShooting = characterShooting;
            _gunChange = gunChange;
            _gunChange.OnGunChanged += SetUpAmmos;
            
           
        }

        public void Bind()
        {
            _characterShooting.OnShooten += GetOrSpendAmmos;
        }

        private void SetUpAmmos(GunTypes gunTypes)
        {
            string currAmmoName = _gunChange.gunType.ToString();
            _ammoCount = PlayerPrefs.GetInt($"{currAmmoName}.ammoCount");
            _currAmmo = PlayerPrefs.GetInt($"{currAmmoName}.currAmmo");
            _ammo = PlayerPrefs.GetInt($"{currAmmoName}.ammo");
            _reloadSpeed = PlayerPrefs.GetFloat($"{currAmmoName}.reloadSpeed");
            
            Debug.Log($"_ammoCount{_ammoCount}");
            Debug.Log($"_currAmmo{_currAmmo}");
            Debug.Log($"_ammo{_ammo}");
            
            if (_currAmmo <= 0)
            {
                CanShoot = false;
                if (_ammoCount > 0)
                {
                    Reload();
                }
            }
        }

        private void GetOrSpendAmmos(int bulletsQuantity)
        {
            string currAmmoName = _gunChange.gunType.ToString();
            
            if (bulletsQuantity > 0)
            {
                _ammoCount += bulletsQuantity;
                PlayerPrefs.SetInt($"{currAmmoName}.ammoCount",_ammoCount);
            }
            else
            {
                if (_currAmmo <= 0 && !IsReloading)
                {
                    Reload();
                    return;
                }
                _currAmmo += bulletsQuantity;
                PlayerPrefs.SetInt($"{currAmmoName}.currAmmo", _currAmmo);
            }
            Debug.Log($"_ammoCount{_ammoCount}");
            Debug.Log($"_currAmmo{_currAmmo}");
            Debug.Log($"_ammo{_ammo}");
        }

        private void Reload()
        {
            string currAmmoName = _gunChange.gunType.ToString();
            CanShoot = false;
            _reloadTimer = _reloadSpeed;
            if (_ammoCount > 0)
            {
                if (_ammoCount < _ammo)
                {
                    _currAmmo = _ammoCount;
                    _ammoCount -= _currAmmo;
                }
                else
                {
                    _currAmmo = _ammo;
                    _ammoCount -= _currAmmo;
                }
                PlayerPrefs.SetInt($"{currAmmoName}.currAmmo", _currAmmo);
                PlayerPrefs.SetInt($"{currAmmoName}.ammoCount",_ammoCount);
                while (_reloadTimer>=0)
                {
                    _reloadTimer -= Time.deltaTime;
                }
                Debug.Log($"_ammoCount{_ammoCount}");
                Debug.Log($"_currAmmo{_currAmmo}");
                Debug.Log($"_ammo{_ammo}");
                CanShoot = true; 
            }
        }
    }
}
