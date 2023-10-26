using System;
using Core;
using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem
{
    public class BuyTower : MonoBehaviour
    {
        [SerializeField] private Transform positionForTower;
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private Button butButton;
        private Bootstrapper _bootstrapper;
        private void Start()
        {
            _bootstrapper = FindFirstObjectByType<Bootstrapper>();
            butButton.onClick.AddListener(BuyingTower);
        }

        public void BuyingTower()
        {
            if (towerPrefab.GetComponent<Tower>().TowerCost <= _bootstrapper.Score.ScoreValue)
            {
                _bootstrapper.Score.AddScore(-towerPrefab.GetComponent<Tower>().TowerCost);
                Instantiate(towerPrefab, positionForTower);
                Destroy(gameObject);
            }
        }
    }
}
