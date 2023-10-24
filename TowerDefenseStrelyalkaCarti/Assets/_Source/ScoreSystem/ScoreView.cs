using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private Score _score;

        public void Construct(Score score)
        {
            _score = score;
        }

        private void Start()
        {
            _score.OnScoreChange += RefreshScoreText;
            scoreText.text = $"score: {_score.ScoreValue}";
        }

        private void RefreshScoreText(int curScore)
        {
            scoreText.text = $"score: {curScore}";
        }

        private void OnDisable()
        {
            _score.OnScoreChange -= RefreshScoreText;
        }
    }
}
