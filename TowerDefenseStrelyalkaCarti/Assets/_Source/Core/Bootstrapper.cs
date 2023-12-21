using System;
using CharacterSystem;
using GunSystem;
using InputSystem;
using ScoreSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GunChange gunChange;
        [SerializeField] private Character character;
        [SerializeField] private Rigidbody2D characterRb;
        [SerializeField] private Camera cameraMain;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private ScoreView scoreView;
        private CharacterInvoker _characterInvoker;
        private CharacterShooting _characterShooting;
        private GunReload _gunReload;
        private Game _game;
        public Score Score { get; private set; }

        private void Awake()
        {
            Init();
        }

        private void OnEnable()
        {
            StartGame();
        }

        private void Init()
        {
            PlayerPrefs.SetInt($"{GunTypes.pistol.ToString()}.ammoCount",100);
            PlayerPrefs.SetInt($"{GunTypes.pistol.ToString()}.currAmmo",10);
            PlayerPrefs.SetInt($"{GunTypes.pistol.ToString()}.ammo",10);
            PlayerPrefs.SetInt($"{GunTypes.pistol.ToString()}.reloadSpeed",2);
            

            //Debug.Log(PlayerPrefs.GetInt($"{GunTypes.pistol.ToString()}.ammoCount"));
            //Debug.Log(PlayerPrefs.GetInt($"{GunTypes.pistol.ToString()}.currAmmo"));
            //Debug.Log( PlayerPrefs.GetInt($"{GunTypes.pistol.ToString()}.ammo"));
            
            _characterShooting = new CharacterShooting(gunChange);
            _gunReload = new GunReload(_characterShooting,gunChange);
            _characterShooting.Construct(_gunReload);
            _gunReload.Bind();
            _characterInvoker = new CharacterInvoker(character, gunChange,_characterShooting);
            Score = new Score();
            _game = new Game(Score);
            inputListener.Construct(_game, character, gunChange, cameraMain, characterRb, _characterInvoker);
            scoreView.Construct(Score);
        }

        private void StartGame()
        {
            _game.OnApplicationStart();
            gunChange.ChangingGun(gunChange.gunType);
        }
    }
}
