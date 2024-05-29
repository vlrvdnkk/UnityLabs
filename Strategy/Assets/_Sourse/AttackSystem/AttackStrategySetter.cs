using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttackStrategySetter : MonoBehaviour
{
    [SerializeField] private ColorBlock _chosenButtonColors;
    [SerializeField] private Button _button1;
    [SerializeField] private Button _button2;
    [SerializeField] private Button _button3;
    private AttackPerformer _attackPerformer;
    private Button _chosenButton;
    private ColorBlock _defaultButtonColors;

    public void Construct(AttackPerformer attackPerformer)
    {
        _attackPerformer = attackPerformer;
    }

    private void Start()
    {
        _button1.onClick.AddListener(() => SetStrategy(new Attack1(), _button1));
        _button2.onClick.AddListener(() => SetStrategy(new Attack2(), _button2));
        _button3.onClick.AddListener(() => SetStrategy(new Attack3(), _button3));
    }

    private void SetStrategy(IAttackStrategy attackStrategy, Button button)
    {
        _attackPerformer.SetStrategy(attackStrategy);
        if (_chosenButton != null)
            _chosenButton.colors = _defaultButtonColors;
        _defaultButtonColors = button.colors;
        button.colors = _chosenButtonColors;
        _chosenButton = button;
    }
}
