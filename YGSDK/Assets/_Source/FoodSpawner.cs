using UnityEngine;

namespace _Source
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject foodPrefab;
        [SerializeField] private Vector2 areaSize;

        private void Start()
        {
            SpawnFood();
        }

        public void SpawnFood()
        {
            Vector2 spawnPosition = new Vector2(
                Mathf.Round(Random.Range(-areaSize.x, areaSize.x)),
                Mathf.Round(Random.Range(-areaSize.y, areaSize.y))
            );

            Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        }
    }
}