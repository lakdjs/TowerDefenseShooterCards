using Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterMovement : IControllable
    {
        private void Moving(Rigidbody2D rb, float speed, Vector2 moveDir)
        {
            Vector2 velocity = moveDir * speed;
            rb.velocity = new Vector2(velocity.x, velocity.y);
        }

        public void Move(Rigidbody2D rb, float speed, Vector2 direction)
        { 
            Moving(rb, speed, direction);
        }
    }
}
