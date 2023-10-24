using UnityEngine;

namespace AmmoSystem
{
    public class DefaultBullet : ABullet
    {
        private void Start()
        {
            Fly();
        }

        public override void Fly()
        {
            rb.velocity = transform.up * speed;
            Destroy(gameObject,destroyTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("col");
            if ((destroyMask & (1 << other.gameObject.layer)) != 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
