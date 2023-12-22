using CharacterSystem;
using GunSystem;
using Interfaces;
using UnityEngine;

namespace AmmoSystem
{
    public class CollisionDetectorForCharacter : MonoBehaviour
    {
        [field: SerializeField] public LayerMask TargetMask { get; private set; }
        [field: SerializeField] public LayerMask DestroyMask { get; private set; }
        
        [SerializeField] private float damage;
        private GunChange _gunChange;
        private Character _character;
        private GunsDataSO _gunDataSo; 
        private void Start()
        {
            _gunDataSo = Resources.Load("Guns") as GunsDataSO;
            _gunChange = FindObjectOfType<GunChange>();
            foreach (var gun in _gunDataSo.Guns)
            {
                if(_gunChange.gunType == gun.GunType)
                {
                    damage = gun.Damage;
                }
            }
            //_enemy = GetComponent<Enemy>();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if ((DestroyMask & (1 << other.gameObject.layer)) != 0)
            {
                if ((TargetMask & (1 << other.gameObject.layer)) != 0)
                {
                    other.gameObject.GetComponent<IDamageble>().TakeDamage(damage);
                    //Debug.Log("target");
                }
                // Debug.Log("col");
                Destroy(gameObject);
            }
        }
        
        public void ChangeDamage(float damageToChange)
        {
            damage = damageToChange;
        }
    }
}
