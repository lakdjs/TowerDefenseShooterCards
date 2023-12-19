using CharacterSystem;
using Core;
using GunSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {   
        private Character _character; 
        private Camera _cameraMain;
        private Rigidbody2D _characterRb; 
        private GunChange _gunChange;
        private CharacterInvoker _characterInvoker;
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private Vector3 _mousePosition;
        private Vector3 _direction;
        private Game _game;

        public void Construct(Game game,
            Character character,
            GunChange gunChange,
            Camera cameraMain,
            Rigidbody2D characterRb,
            CharacterInvoker characterInvoker)
        {
            _character = character;
            _game = game;
            _characterInvoker = characterInvoker;
            _cameraMain = cameraMain;
            _characterRb = characterRb;
        }
        private void Awake()
        {
            
        }

        private void Update()
        {
            ReadShoot();
        }

        private void FixedUpdate()
        {
            ReadMove();
            LookAtPoint();
        }

        private void ReadMove()
        {
            float horizontal = Input.GetAxis(Horizontal);
            float vertical = Input.GetAxis(Vertical);
            Vector2 moveDir = new Vector2(horizontal, vertical);
            _characterInvoker.Move(moveDir);
        }
        private void ReadShoot()
        {
            if (Input.GetKeyDown(_character.MouseButton))
            {
                _characterInvoker.Shoot();
            }
        }
        
        private void LookAtPoint()
        {
            _mousePosition = _cameraMain.ScreenToWorldPoint(Input.mousePosition);
            _direction = _mousePosition - _character.gameObject.transform.position;
            _direction.Normalize();
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            _characterRb.rotation = angle;
        }
    }
}
