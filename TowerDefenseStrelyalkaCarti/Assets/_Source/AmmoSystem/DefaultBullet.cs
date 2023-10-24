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
    }
}
