using System;
using UnityEngine;
using VContainer;

namespace _Source
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float pingPongSpeed;
        [SerializeField] private float moveRange;
        
        
        private GameManager _gameManager;
        private Vector3 _spawnPosition;
        private Quaternion _spawnRotation;
        
        [Inject]
        private void Construct(GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        public void Initialize(Vector3 spawnPosition, Quaternion spawnRotation, Transform parent)
        {
            _spawnPosition = spawnPosition;
            _spawnRotation = spawnRotation;

            transform.position = _spawnPosition;
            transform.rotation = _spawnRotation;
            transform.SetParent(parent);
        }

        private void Update()
        {
            float newY = Mathf.PingPong(Time.time * pingPongSpeed, moveRange) - moveRange / 2;
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, _spawnPosition.y + newY);

            if (transform.position.x < -_gameManager.ScreenWidth - _gameManager.SpawnBufferWidth)
            {
                Destroy(gameObject);
            }
        }
    }
}