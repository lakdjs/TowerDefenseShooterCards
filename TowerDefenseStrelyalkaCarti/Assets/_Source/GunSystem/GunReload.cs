using System;
using System.Collections;
using System.Threading;
using CharacterSystem;
using UnityEngine;

namespace GunSystem
{
    public class GunReload: MonoBehaviour

    {
        public event Action<int> OnAmmoChanged; 
        public event Action<int> OnAmmoCountChanged; 
        public event Action<int> OnCurrAmmoChanged; 
    public bool CanShoot { get; private set; } = true;
    private GunChange _gunChange;
    private CharacterShooting _characterShooting;
    public int AmmoCount { get; private set; } //обойма
    public int CurrAmmo { get; private set; } //в новом оружии
    public int Ammo { get; private set; } //в 1ой обойме
    private float _reloadSpeed;
    private float _reloadTimer = 0.0f;
    private bool IsReloading = false;

    public void Construct(CharacterShooting characterShooting, GunChange gunChange)
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
        AmmoCount = PlayerPrefs.GetInt($"{currAmmoName}.ammoCount");
        CurrAmmo = PlayerPrefs.GetInt($"{currAmmoName}.currAmmo");
        Ammo = PlayerPrefs.GetInt($"{currAmmoName}.ammo");
        _reloadSpeed = PlayerPrefs.GetFloat($"{currAmmoName}.reloadSpeed");

        //Debug.Log($"_ammoCount{_ammoCount}");
        //Debug.Log($"_currAmmo{_currAmmo}");
        //Debug.Log($"_ammo{_ammo}");

        if (CurrAmmo <= 0)
        {
            CanShoot = false;
            if (AmmoCount > 0)
            {
                Reload();
            }
        }
        OnAmmoChanged?.Invoke(Ammo);
        OnAmmoCountChanged?.Invoke(AmmoCount);
        OnCurrAmmoChanged?.Invoke(CurrAmmo);
    }

    private void GetOrSpendAmmos(int bulletsQuantity)
    {
        string currAmmoName = _gunChange.gunType.ToString();

        if (bulletsQuantity > 0)
        {
            //AmmoCount += bulletsQuantity;
            PlayerPrefs.SetInt($"{currAmmoName}.ammoCount", AmmoCount);
        }
        else
        {
            if (CurrAmmo <= _gunChange.BulletQuantityPerShot && !IsReloading)
            {
                CanShoot = false;
                CurrAmmo += bulletsQuantity;
                OnCurrAmmoChanged?.Invoke(CurrAmmo);
                StartCoroutine(TimerToReload(_reloadSpeed));
                Reload();
                return;
            }
            
            //CurrAmmo += bulletsQuantity;
            PlayerPrefs.SetInt($"{currAmmoName}.currAmmo", CurrAmmo);
        }
        CurrAmmo += bulletsQuantity;
        OnAmmoChanged?.Invoke(Ammo);
        OnAmmoCountChanged?.Invoke(AmmoCount);
        OnCurrAmmoChanged?.Invoke(CurrAmmo);
        //Debug.Log($"_ammoCount{_ammoCount}"); 
        //Debug.Log($"_currAmmo{_currAmmo}");
        //Debug.Log($"_ammo{_ammo}");
    }

    private void Reload()
    {
        
    }

    IEnumerator TimerToReload(float time)
    {
        CanShoot = false;
        _reloadTimer = _reloadSpeed;
        while (_reloadTimer > 0)
        {
            yield return new WaitForSeconds(1);
            _reloadTimer--;
        }
        
        string currAmmoName = _gunChange.gunType.ToString();
        CanShoot = false;
        if (AmmoCount > 0)
        {
            if (AmmoCount < Ammo)
            {
                CurrAmmo = AmmoCount;
                AmmoCount -= CurrAmmo;
            }
            else
            {
                CurrAmmo = Ammo;
                AmmoCount -= CurrAmmo;
            }

            //PlayerPrefs.SetInt($"{currAmmoName}.currAmmo", _currAmmo);
            //PlayerPrefs.SetInt($"{currAmmoName}.ammoCount", _ammoCount);

            CanShoot = true;
        }

        Debug.Log("RELOADED");
        OnAmmoChanged?.Invoke(Ammo);
        OnAmmoCountChanged?.Invoke(AmmoCount);
        OnCurrAmmoChanged?.Invoke(CurrAmmo);
    }
    }
}
