using System;
using UnityEngine;

namespace TowerSystem
{
    [Serializable]
    public class TowerData 
    {
        [field: SerializeField] public TowerTypes TowerType {get; private set;}
        [field: SerializeField] public Sprite TowerIcon {get; private set;}
        [field: SerializeField] public float TowerHealth { get; private set; }
        [field: SerializeField] public float TowerRange { get; private set; }
        [field: SerializeField] public float CoolDown { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public int TowerCost { get; private set; }
    }
}
