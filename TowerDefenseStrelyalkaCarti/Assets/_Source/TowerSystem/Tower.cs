using System;
using EnemySystem;
using UnityEngine;

namespace TowerSystem
{
    [Serializable]
    public class Tower : MonoBehaviour

    { 
    public EnemyList EnemyList { get; private set; }
    [field: SerializeField] public TowerTypes TowerType {get; private set;}
    [field: SerializeField] public Sprite TowerIcon {get; private set;}
    [field: SerializeField] public float TowerHealth { get; private set; }
    [field: SerializeField] public float TowerRange { get; private set; }
    [field: SerializeField] public float CoolDown { get; private set; }
    [field: SerializeField] public int TowerCost { get; private set; }
    [field: SerializeField] public GameObject Projectile { get; private set; }
    [field: SerializeField] public Transform FirePoint { get; private set; }
    [field: SerializeField] public TowerList TowerList { get; private set; }

    private void Start()
    {
        TowerList = FindFirstObjectByType<TowerList>();
        TowerList.AddTowerInList(this);
        EnemyList = FindFirstObjectByType<EnemyList>();
    }
    }
}
