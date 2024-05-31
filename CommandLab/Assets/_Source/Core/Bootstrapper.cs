using System;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private InputListener _inputListener;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _prefab;
    private CommandInvoker _commandInvoker;
    private Dictionary<Type, ICommand> _commands;

    private void Awake()
    {
        _commands = new Dictionary<Type, ICommand>()
            {
                {typeof(MoveCommand),new MoveCommand(_playerMovement)},
                {typeof(SpawnCommand),new SpawnCommand(_prefab)},
            };
        _commandInvoker = new CommandInvoker(_commands);

        _inputListener.Construct(_commandInvoker);
    }
}
