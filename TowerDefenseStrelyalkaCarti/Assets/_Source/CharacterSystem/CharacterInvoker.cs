using GunSystem;
using Interfaces;
using UnityEngine;

namespace CharacterSystem
{
    public class CharacterInvoker 
    {
        private Character _character;
        private IControllable _controllable;
        private IShootable _shootable;
        private GunChange _gunChange;
        public CharacterInvoker(Character character, GunChange gunChange, CharacterShooting characterShooting)
        {
            _gunChange = gunChange;
            _character = character;
            _controllable = new CharacterMovement();
            _shootable = characterShooting;
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
