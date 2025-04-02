using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace _Source
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private int points;
        [SerializeField] private Image background;
        private int _score;
        
        public void GameOver()
        {
            RestartGame();
        }
        
        public void AddScore()
        {
            _score += points;
            UpdateScoreUI();
        }

        public void ChangeBackgroundColor()
        {
            background.color = new Color(Random.value, Random.value, Random.value);
        }

        private void UpdateScoreUI()
        {
            scoreText.text = "Score: " + _score;
        }

        private void RestartGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}