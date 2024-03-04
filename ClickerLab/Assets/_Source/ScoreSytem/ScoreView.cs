using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private Score _score;

    public void ConstructScore(Score score)
    {
        _score = score;
        _score.OnScorechange += RefreshScoreText;
    }

    private void RefreshScoreText(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    private void OnDestroy()
    {
        _score.OnScorechange -= RefreshScoreText;
    }
}