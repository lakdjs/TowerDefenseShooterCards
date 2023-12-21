using GunSystem;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI ammoCountText;
        [SerializeField] private TextMeshProUGUI curAmmoText;
        [SerializeField] private TextMeshProUGUI ammoText;
        private GunReload _gunReload;
        
        public void Construct(GunReload gunReload)
        {
            _gunReload = gunReload;
        }

        public void Bind()
        {
            _gunReload.OnAmmoChanged += RefreshAmmoText;
            _gunReload.OnAmmoCountChanged += RefreshAmmoCountText;
            _gunReload.OnCurrAmmoChanged += RefreshCurrAmmoText;
        }
        private void RefreshAmmoCountText(int amount)
        {
            ammoCountText.text = $"ammoCount:{amount}";
        }
        private void RefreshAmmoText(int amount)
        {
            ammoText.text = $"ammo:{amount}";
        }
        private void RefreshCurrAmmoText(int amount)
        {
            curAmmoText.text = $"currAmmo:{amount}";
        }
    }
}
