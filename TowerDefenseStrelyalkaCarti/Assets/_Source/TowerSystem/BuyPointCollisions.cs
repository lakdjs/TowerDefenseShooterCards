using Core;
using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem
{
    public class BuyPointCollisions : MonoBehaviour
    {
        [SerializeField] private GameObject buildButton;
        private GameObject _selectedBuildPoint;
        [SerializeField] private Transform positionForTower;
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private Button buyButton;
        private Bootstrapper _bootstrapper;
        private void Start()
        {
            _bootstrapper = FindFirstObjectByType<Bootstrapper>();
        }

        public void BuyingTower()
        {
            if (towerPrefab.GetComponent<Tower>().TowerCost <= _bootstrapper.Score.ScoreValue)
            {
                _bootstrapper.Score.AddScore(towerPrefab.GetComponent<Tower>().TowerCost);
               GameObject tower = Instantiate(towerPrefab, positionForTower);
               tower.GetComponent<Tower>().Init(buyButton.GetComponent<TowerView>().TowerType);
                //Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Character" && _selectedBuildPoint==null)
            {
                _selectedBuildPoint = gameObject;
                buildButton.SetActive(true);
                buildButton.transform.position =
                    Camera.main.WorldToScreenPoint(_selectedBuildPoint.transform.position);
                buyButton.onClick.AddListener(BuyingTower);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Character" && buildButton != null)
            {
                _selectedBuildPoint = null;
                buildButton.SetActive(false);
                buyButton.onClick.RemoveListener(BuyingTower);
            }
        }
    }
}
