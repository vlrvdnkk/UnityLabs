using System.Collections.Generic;
using UnityEngine;

namespace _Source
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int objectCount;
        [SerializeField] private float radius;
        [SerializeField] private float speed;
    
        private List<Transform> _spawnedObjects;

        void Awake()
        {
            _spawnedObjects = new List<Transform>();
        }
        
        void Start()
        {
            for (int i = 0; i < objectCount; i++)
            {
                Vector3 position = new Vector3(Mathf.Cos(i) * radius, 0, Mathf.Sin(i) * radius);
                GameObject obj = Instantiate(prefab, position, Quaternion.identity);
                _spawnedObjects.Add(obj.transform);
            
                Mover mover = obj.GetComponent<Mover>();
                mover.Init(speed, radius);
                Logger logger = obj.GetComponent<Logger>();
                logger.Init();
            }
        }
    }
}