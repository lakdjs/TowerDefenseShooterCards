using System.Collections.Generic;
using EnemySystem;
using UnityEngine;

namespace TowerSystem
{
    public class TowerList : MonoBehaviour
    {
        public List<Tower> Towers { get; private set; } = new List<Tower>();

        private void Start()
        {
            //Enemies = new List<Enemy>();
        }

        public void AddTowerInList(Tower tower)
        {
            Towers.Add(tower);
        }

        public void RemoveTowerFromList(Tower tower)
        {
            Towers.Remove(tower);
        }
    }
}
