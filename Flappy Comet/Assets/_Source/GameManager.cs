using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace _Source
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public float ScreenWidth { get; private set; }
        public float SpawnBufferWidth => spawnBufferWidth;
    
        [SerializeField] TextMeshProUGUI scoreText;
        [SerializeField] private float minSpawnInterval;
        [SerializeField] private float maxSpawnInterval;
        [SerializeField] private float obstacleSpawnMinY;
        [SerializeField] private float obstacleSpawnMaxY;
        [SerializeField] private float bonusSpawnMinY ;
        [SerializeField] private float bonusSpawnMaxY;
        [Min(0)] [SerializeField] private float spawnBufferWidth;
        [SerializeField] private Transform obstacleParent;
        [SerializeField] private Transform bonusParent;

        private Bonus.Factory _bonusFactory;
        private Obstacle.Factory _obstacleFactory;
        
        private int _score;

        [Inject]
        private void Construct(Bonus.Factory bonusFactory, Obstacle.Factory obstacleFactory)
        {
            Instance = this;
            _bonusFactory = bonusFactory;
            _obstacleFactory  = obstacleFactory;
        }
    
        private void Start()
        {
            ScreenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        }

        public void AddScore(int value)
        {
            _score += value;
            scoreText.text = _score.ToString();
        }

        public void EndGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    
        public IEnumerator SpawnObstacles()
        {
            while (true)
            {
                float spawnX = ScreenWidth + spawnBufferWidth;
                float spawnY = Random.Range(obstacleSpawnMinY, obstacleSpawnMaxY);
                Obstacle obstacle = _obstacleFactory.Create();
                obstacle.Initialize(new Vector3(spawnX, spawnY, 0), Quaternion.identity, obstacleParent);
                float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(randomInterval);
            }
        }

        public IEnumerator SpawnBonuses()
        {
            while (true)
            {
                float spawnX = ScreenWidth + spawnBufferWidth;;
                float spawnY = Random.Range(bonusSpawnMinY, bonusSpawnMaxY);
                Bonus bonus = _bonusFactory.Create();
                bonus.Initialize(new Vector3(spawnX, spawnY, 0), Quaternion.identity, bonusParent);
                float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
                yield return new WaitForSeconds(randomInterval);
            }
        }
    }
}