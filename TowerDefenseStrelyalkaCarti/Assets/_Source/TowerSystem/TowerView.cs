using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem
{
    [RequireComponent(typeof(Image))]
    public class TowerView : MonoBehaviour
    {
        [field: SerializeField] public TowerTypes TowerType { get; private set; }

        private void Start()
        {
           
        }
    }
}
