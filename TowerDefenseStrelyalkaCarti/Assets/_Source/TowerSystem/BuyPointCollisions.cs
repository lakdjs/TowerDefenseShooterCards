using UnityEngine;

namespace TowerSystem
{
    public class BuyPointCollisions : MonoBehaviour
    {
        [SerializeField] private GameObject buildButton;
        private GameObject _selectedBuildPoint;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Character" && _selectedBuildPoint==null)
            {
                _selectedBuildPoint = gameObject;
                buildButton.SetActive(true);
                buildButton.transform.position =
                    Camera.main.WorldToScreenPoint(_selectedBuildPoint.transform.position);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.tag == "Character" && buildButton != null)
            {
                _selectedBuildPoint = null;
                buildButton.SetActive(false);
            }
        }
    }
}
