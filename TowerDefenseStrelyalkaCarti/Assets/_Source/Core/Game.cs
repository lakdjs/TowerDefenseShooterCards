using ScoreSystem;
using UnityEngine;

namespace Core
{
    public class Game 
    {
        private Score _score;

        public Game(Score score)
        {
            _score = score;
        }

        public void OnApplicationStart()
        {
            Debug.Log("start");
        }
        public void OnApplicationExit()
        {
            Debug.Log("exit");
        }
    }
}
