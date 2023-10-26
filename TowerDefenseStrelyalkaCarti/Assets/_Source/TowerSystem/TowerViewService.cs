using UnityEngine;

namespace TowerSystem
{
    public class TowerViewService
    {
        private static TowerViewService instance;
        private TowerSO _towerSo = Resources.Load("NewTower") as TowerSO;

        public static TowerViewService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TowerViewService();
                }

                return instance;
            }
        }

        public bool GetTowerIcon(TowerTypes type, out Sprite icon)
        {
            icon = null;
            if (_towerSo)
            {
                foreach (var viewData in _towerSo.Towers)
                {
                    if (viewData.TowerType == type)
                    {
                        icon = viewData.TowerIcon;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
