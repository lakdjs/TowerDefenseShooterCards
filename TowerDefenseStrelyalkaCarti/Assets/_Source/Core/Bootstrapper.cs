using System;
using InputSystem;
using ScoreSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
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
            inputListener.Construct(_game);
            scoreView.Construct(Score);
        }

        private void StartGame()
        {
            _game.OnApplicationStart();
        }
    }
}
