using Interfaces;
using UnityEngine;

namespace AmmoSystem
{
    public class CollisionDetectorForProjectile : MonoBehaviour
    {
        [field: SerializeField] public LayerMask TargetMask { get; private set; }
        [field: SerializeField] public LayerMask DestroyMask { get; private set; }
        
        [SerializeField] private float damage;

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
