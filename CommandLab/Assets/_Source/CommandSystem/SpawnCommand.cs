using UnityEngine;

 public class SpawnCommand: ICommand
    {
        private GameObject _prefab;

        private GameObject _gameObject;
        
        public SpawnCommand(GameObject prefab)
        {
            _prefab = prefab;
        }
        
        public AHistory Invoke(Vector2 position)
        {
            _gameObject = Object.Instantiate(_prefab,position,Quaternion.identity);
            return new SpawnCommandHistory(this, position, _gameObject);
        }

        public void Undo(AHistory history)
        {
            SpawnCommandHistory spawnHistory = (SpawnCommandHistory)history;

            Object.Destroy(spawnHistory.SpawnedGameObject);
        }
    }
