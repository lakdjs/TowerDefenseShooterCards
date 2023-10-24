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
        private Score _score;
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
            _score = new Score();
            _game = new Game(_score);
            inputListener.Construct(_game);
            scoreView.Construct(_score);
        }

        private void StartGame()
        {
            _game.OnApplicationStart();
        }
    }
}
