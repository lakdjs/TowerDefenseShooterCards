using Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterInvoker 
    {
        private Character _character;
        private IControllable _controllable;
        private IShootable _shootable;

        public CharacterInvoker(Character character)
        {
            _character = character;
            _controllable = new CharacterMovement();
            _shootable = new CharacterShooting();
        }

        public void Move(Vector2 moveDirection)
        {
            _controllable.Move(_character.Rb,_character.MovementSpeed,moveDirection);
        }

        public void Shoot()
        {
            _shootable.Shoot(_character.FirePoint,_character.BulletPrefab);
        }
    }
}
