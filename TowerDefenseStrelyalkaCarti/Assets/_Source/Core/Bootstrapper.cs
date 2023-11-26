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
            Score = new Score();
            _game = new Game(Score);
            inputListener.Construct(_game, character, gunChange, cameraMain, characterRb);
            scoreView.Construct(Score);
        }

        private void StartGame()
        {
            _game.OnApplicationStart();
            gunChange.ChangingGun(gunChange.gunType);
        }
    }
}
