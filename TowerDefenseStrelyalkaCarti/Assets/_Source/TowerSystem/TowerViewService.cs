using UnityEngine;

namespace TowerSystem
{
    public class TowerViewService
    {
        private static TowerViewService instance;
        private TowerSO _towerSo = Resources.Load("Towers") as TowerSO;

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

        public void GetTowerIcon(TowerTypes type,
            out Sprite icon,
           out float health,
           out float range,
           out float coolDown,
            out float damage,
           out int cost)
        {
            icon = null;
            health = 0;
            range = 0;
            coolDown = 0;
            damage = 0;
            cost = 0;
            if (_towerSo)
            {
                foreach (var viewData in _towerSo.Towers)
                {
                    if (viewData.TowerType == type)
                    {
                        icon = viewData.TowerIcon;
                        health = viewData.TowerHealth;
                        range = viewData.TowerRange;
                        coolDown = viewData.CoolDown;
                        damage = viewData.Damage;
                        cost = viewData.TowerCost;
                    }
                }
            }
        }
    }
}
