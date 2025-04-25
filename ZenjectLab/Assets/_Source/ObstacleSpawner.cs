using UnityEngine;
using Zenject;

namespace _Source
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3 spawnAreaMin = new Vector3(-10f, 0f, -10f);
        [SerializeField] private Vector3 spawnAreaMax = new Vector3(10f, 5f, 10f);
        [SerializeField] private float spawnInterval = 2f;
    
        private DestructibleObstacle.Factory _obstacleFactory;
        private float _nextSpawnTime;

        [Inject]
        public void Construct(DestructibleObstacle.Factory obstacleFactory)
        {
            _obstacleFactory = obstacleFactory;
            if (_obstacleFactory == null)
            {
                Debug.LogError("ObstacleFactory is null in ObstacleSpawner!");
            }
        }

        private void Update()
        {
            if (Time.time >= _nextSpawnTime)
            {
                SpawnObstacle();
                _nextSpawnTime = Time.time + spawnInterval;
            }
        }

        private void SpawnObstacle()
        {
            if (_obstacleFactory == null)
            {
                Debug.LogError("Cannot spawn obstacle: ObstacleFactory is null!");
                return;
            }

            Vector3 spawnPos = new Vector3(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                Random.Range(spawnAreaMin.z, spawnAreaMax.z)
            );
        
            DestructibleObstacle obstacle = _obstacleFactory.Create();
            obstacle.transform.position = spawnPos;
            obstacle.transform.rotation = Quaternion.identity;
        }
    }
}