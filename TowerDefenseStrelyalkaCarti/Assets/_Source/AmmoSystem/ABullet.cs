using UnityEngine;

namespace AmmoSystem
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class ABullet : MonoBehaviour
    {
        [SerializeField] protected float speed;
        [SerializeField] protected float destroyTime;
        [SerializeField] protected Rigidbody2D rb;
        public abstract void Fly();
        public abstract void ChangeDamage(float damage);
    }
}

