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
        [SerializeField] private Button butButton;
        private Bootstrapper _bootstrapper;
        private void Start()
        {
            _bootstrapper = FindFirstObjectByType<Bootstrapper>();
        }

        public void BuyingTower()
        {
            if (towerPrefab.GetComponent<Tower>().TowerCost <= _bootstrapper.Score.ScoreValue)
            {
                _bootstrapper.Score.AddScore(-towerPrefab.GetComponent<Tower>().TowerCost);
                Instantiate(towerPrefab, positionForTower);
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
                butButton.onClick.AddListener(BuyingTower);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Character" && buildButton != null)
            {
                _selectedBuildPoint = null;
                buildButton.SetActive(false);
                butButton.onClick.RemoveListener(BuyingTower);
            }
        }
    }
}
