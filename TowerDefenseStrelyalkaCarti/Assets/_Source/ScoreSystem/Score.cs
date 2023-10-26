using System;
using UnityEngine;

namespace ScoreSystem
{
    public class Score 
    {
        public const int StartValue = 0;
        private const int EndValue = 0;
        
        private int _addingScore = 1;
        public int ScoreValue { get; private set; }

        public event Action<int> OnScoreChange;
        public void ResetScore()
        {
            ScoreValue = EndValue;
            OnScoreChange?.Invoke(ScoreValue);
        }
        public void SetUpScore()
        {
            Debug.Log("1");
            ScoreValue = StartValue;
            OnScoreChange?.Invoke(ScoreValue);
        }

        public void AddScore(int adding)
        {
            ScoreValue += adding;
            OnScoreChange?.Invoke(ScoreValue);
        }
    }
}
