using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener _inputListener;
    [SerializeField] private EnemySwitcher _enemySwitcher;
    private EnemyPool _enemyPool;
    private EnemySpawnSO _enemySpawnData;

    private void Awake()
    {
        _enemySpawnData = Resources.Load<EnemySpawnSO>("EnemySpawnData");
        _enemyPool = new EnemyPool(_enemySpawnData.GetEnemyPrefabs());
        _inputListener.Construct(_enemyPool);
        _enemySwitcher.Construct(_enemyPool);
    }
}