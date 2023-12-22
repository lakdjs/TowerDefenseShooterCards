using System.Collections.Generic;
using UnityEngine;

namespace TowerSystem
{
    [CreateAssetMenu(menuName = "SO/New Tower", fileName = "NewTower")]
    public class TowerSO : ScriptableObject
    {
        [field: SerializeField] public List<TowerData> Towers { get; private set; }
    }
}
