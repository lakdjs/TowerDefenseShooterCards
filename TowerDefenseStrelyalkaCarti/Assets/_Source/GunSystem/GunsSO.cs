using System.Collections.Generic;
using UnityEngine;

namespace GunSystem
{
    [CreateAssetMenu(menuName = "SO/New Gun", fileName = "NewGun")]
    public class GunsDataSO : ScriptableObject
    {
        [field: SerializeField] public List<Gun> Guns { get; private set; }
    }
}
