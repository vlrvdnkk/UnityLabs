using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private KeyCode _attackKeyCode;
    private EnemyPool _enemyPool;

    public void Construct(EnemyPool enemyPool)
    {
        _enemyPool = enemyPool;
    }

    private void Update()
    {
        CheckAttack();
    }

    private void CheckAttack()
    {
        if (Input.GetKeyDown(_attackKeyCode))
        {
            _enemyPool.CallAttack();
        }
    }
}
