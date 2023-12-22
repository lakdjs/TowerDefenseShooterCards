using System;
using EnemySystem;
using UnityEngine;
using UnityEngine.UI;

namespace TowerSystem
{
    [RequireComponent(typeof(Sprite))]
    public class Tower : MonoBehaviour

    { 
    public EnemyList EnemyList { get; private set; }
    [field: SerializeField] public TowerTypes TowerType {get; private set;}
    [field: SerializeField] public Sprite TowerIcon {get; private set;}
    private float _health;
    private float _range;
    private float _coolDown;
    private float _damage;
    private int _cost;
    public float TowerHealth => _health;
    public float TowerRange => _range;
    public float CoolDown => _coolDown;
    public float Damage => _damage;
    public int TowerCost => _cost;
    [field: SerializeField] public GameObject Projectile { get; private set; }
    [field: SerializeField] public Transform FirePoint { get; private set; }
    public TowerList TowerList { get; private set; }
    private Sprite _icon;
    private Sprite _sprite;

    public void Init(TowerTypes towerTypes)
    {
        TowerViewService.Instance.GetTowerIcon(towerTypes,
            out _icon, out _health, out _range, out _coolDown,out _damage, out _cost);
    }
    private void Start()
    {
        TowerList = FindObjectOfType<TowerList>();
        TowerList.AddTowerInList(this);
        EnemyList = FindObjectOfType<EnemyList>();
        _icon = GetComponent<SpriteRenderer>().sprite;
        TowerViewService.Instance.GetTowerIcon(TowerType,
            out _icon, out _health, out _range, out _coolDown,out _damage, out _cost);
        
    }
    }
}
