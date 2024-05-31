using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnData", menuName = "SO/EnemySpawnData")]
public class EnemySpawnSO : ScriptableObject
{
    [SerializeField] private GameObject _firstTypeEnemy;
    [SerializeField] private GameObject _secondTypeEnemy;
    [SerializeField] private GameObject _thirdTypeEnemy;

    public Dictionary<EnemyType, GameObject> GetEnemyPrefabs()
    {
        return new Dictionary<EnemyType, GameObject>
            {
                {EnemyType.FirstType, _firstTypeEnemy},
                {EnemyType.SecondType, _secondTypeEnemy},
                {EnemyType.ThirdType, _thirdTypeEnemy}
            };
    }
}