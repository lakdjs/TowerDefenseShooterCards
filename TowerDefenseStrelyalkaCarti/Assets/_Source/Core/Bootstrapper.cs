using System;
using CharacterSystem;
using GunSystem;
using InputSystem;
using ScoreSystem;
using UnityEngine;
using UnityEngine.Serialization;

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
        [SerializeField] private GunReload gunReload;
        [SerializeField] private BulletView bulletView;
        private CharacterInvoker _characterInvoker;
        private CharacterShooting _characterShooting;
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
            PlayerPrefs.SetInt($"{GunTypes.pistol.ToString()}.ammoCount",60);
            PlayerPrefs.SetInt($"{GunTypes.pistol.ToString()}.currAmmo",10);
            PlayerPrefs.SetInt($"{GunTypes.pistol.ToString()}.ammo",10);
            PlayerPrefs.SetFloat($"{GunTypes.pistol.ToString()}.reloadSpeed",2);
            
            PlayerPrefs.SetInt($"{GunTypes.rifle.ToString()}.ammoCount",100);
            PlayerPrefs.SetInt($"{GunTypes.rifle.ToString()}.currAmmo",20);
            PlayerPrefs.SetInt($"{GunTypes.rifle.ToString()}.ammo",20);
            PlayerPrefs.SetFloat($"{GunTypes.rifle.ToString()}.reloadSpeed",5);
            
            PlayerPrefs.SetInt($"{GunTypes.shotgun.ToString()}.ammoCount",15);
            PlayerPrefs.SetInt($"{GunTypes.shotgun.ToString()}.currAmmo",6);
            PlayerPrefs.SetInt($"{GunTypes.shotgun.ToString()}.ammo",6);
            PlayerPrefs.SetFloat($"{GunTypes.shotgun.ToString()}.reloadSpeed",10);
            

            //Debug.Log(PlayerPrefs.GetInt($"{GunTypes.pistol.ToString()}.ammoCount"));
            //Debug.Log(PlayerPrefs.GetInt($"{GunTypes.pistol.ToString()}.currAmmo"));
            //Debug.Log( PlayerPrefs.GetInt($"{GunTypes.pistol.ToString()}.ammo"));
            
            _characterShooting = new CharacterShooting(gunChange);
            gunReload.Construct(_characterShooting,gunChange);
            _characterShooting.Construct(gunReload);
            gunReload.Bind();
            bulletView.Construct(gunReload);
            bulletView.Bind();
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
