using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    [CreateAssetMenu(menuName = "SO/New Enemy Data", fileName = "NewEnemyData")]
    public class EnemyDataSO : ScriptableObject
    {
        [field: SerializeField] public List<EnemyData> EnemyData { get; private set; }
    }
}
