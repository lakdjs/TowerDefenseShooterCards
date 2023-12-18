using System;
using UnityEngine;

namespace EnemySystem
{
    [Serializable]
    public class EnemyData 
    {
        [field: SerializeField] public EnemyTypes EnemyTypes { get; private set; }
        [field: SerializeField] public float EnemyHealth { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public int Gold { get; private set; }
        [field: SerializeField] public float MovementSpeed { get; private set; }
        [field: SerializeField] public float ShootCoolDown { get; private set; }
    }
}
