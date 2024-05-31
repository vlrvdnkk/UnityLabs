using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    private readonly Dictionary<EnemyType, AEnemy> _enemies;
    private readonly Dictionary<EnemyType, GameObject> _enemiesPrefab;
    private AEnemy _enemy;

    public EnemyPool(Dictionary<EnemyType, GameObject> enemiesPrefab)
    {
        _enemies = new Dictionary<EnemyType, AEnemy>();
        _enemiesPrefab = enemiesPrefab;
    }

    public void SetEnemy(EnemyType enemyType)
    {
        if (_enemy != null)
            _enemy.gameObject.SetActive(false);

        if (_enemies.TryGetValue(enemyType, out var enemy))
        {
            _enemy = enemy;
        }
        else
        {
            _enemy = CreateEnemy(enemyType);
        }

        _enemy.gameObject.SetActive(true);
    }

    private AEnemy CreateEnemy(EnemyType enemyType)
    {
        AEnemy enemy = Object.Instantiate(_enemiesPrefab[enemyType]).GetComponent<AEnemy>();
        _enemies.Add(enemyType, enemy);
        return enemy;
    }

    public void CallAttack()
    {
        if (_enemy.IsControlledByPlayer)
            _enemy.Attack();
    }
}
