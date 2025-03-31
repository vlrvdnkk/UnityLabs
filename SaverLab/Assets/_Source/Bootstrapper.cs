using _Source.Management;
using UnityEngine;

namespace _Source
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private UIManager UIManager;
        [SerializeField] private float scorePerSecond = 10f;

        private void Awake()
        {
            gameManager.SetScorePerSecond(scorePerSecond);
            gameManager.LoadGame();
            
            UIManager.UpdateScore(gameManager.Score);
            UIManager.UpdateTime(gameManager.PlayTime);
        }
    }
}