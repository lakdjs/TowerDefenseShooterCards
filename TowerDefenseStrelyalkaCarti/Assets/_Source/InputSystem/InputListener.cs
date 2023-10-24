using CharacterSystem;
using Core;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private Character character;
        [SerializeField] private Camera cameraMain;
        [SerializeField] private Rigidbody2D characterRb;
        private CharacterInvoker _characterInvoker;
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        private Vector3 _mousePosition;
        private Vector3 _direction;
        private Game _game;

        public void Construct(Game game)
        {
            _game = game;
        }
        private void Awake()
        {
            _characterInvoker = new CharacterInvoker(character);
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
            if (Input.GetKeyDown(character.MouseButton))
            {
                _characterInvoker.Shoot();
            }
        }
        
        private void LookAtPoint()
        {
            _mousePosition = cameraMain.ScreenToWorldPoint(Input.mousePosition);
            _direction = _mousePosition - character.gameObject.transform.position;
            _direction.Normalize();
            float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
            characterRb.rotation = angle;
        }
    }
}
