using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem
{
    [RequireComponent(typeof(Image))]
    public class TowerView : MonoBehaviour
    {
        [SerializeField] private TowerTypes towerType;
        private Image _icon;
        private void Start()
        {
            _icon = GetComponent<Image>();
            if (TowerViewService.Instance.GetTowerIcon(towerType,
                    out Sprite processIcon))
            {
                _icon.sprite = processIcon;
            }
        }
    }
}
