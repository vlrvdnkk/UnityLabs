using UnityEngine;
using UnityEngine.UI;

public class EnemySwitcher : MonoBehaviour
{
    [SerializeField] private ColorBlock _chosenButtonColors;
    private EnemyPool _enemyPool;
    private Button _chosenButton;
    [SerializeField] private Button _buttonEnemy1;
    [SerializeField] private Button _buttonEnemy2;
    [SerializeField] private Button _buttonEnemy3;
    private ColorBlock _defaultButtonColors;

    public void Construct(EnemyPool enemyPool)
    {
        _enemyPool = enemyPool;
    }

    private void Start()
    {
        _buttonEnemy1.onClick.AddListener(() => SetEnemy(EnemyType.FirstType, _buttonEnemy1));
        _buttonEnemy2.onClick.AddListener(() => SetEnemy(EnemyType.SecondType, _buttonEnemy2));
        _buttonEnemy3.onClick.AddListener(() => SetEnemy(EnemyType.ThirdType, _buttonEnemy3));
    }

    private void SetEnemy(EnemyType enemyType, Button button)
    {
        if (_chosenButton == button) return;

        _enemyPool.SetEnemy(enemyType);
        if (_chosenButton != null)
            _chosenButton.colors = _defaultButtonColors;
        _defaultButtonColors = button.colors;
        button.colors = _chosenButtonColors;
        _chosenButton = button;
    }
}
