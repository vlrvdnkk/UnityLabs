using TMPro;
using UnityEngine;

namespace _Source.Management
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text timeText;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void UpdateScore(float score)
        {
            scoreText.text = $"Очки: {score:F2}";
        }

        public void UpdateTime(float time)
        {
            timeText.text = $"Время: {time:F2} сек";
        }
    }
}