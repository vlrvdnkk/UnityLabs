using System;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private const int MaxHistoryCount = 10;
    private List<AHistory> _history;
    private Dictionary<Type, ICommand> _commands;

    public CommandInvoker(Dictionary<Type, ICommand> commands)
    {
        _commands = commands;
        _history = new List<AHistory>();
    }

    private ICommand GetCommand<T>() where T : ICommand
    {
        return _commands[typeof(T)];
    }

    public void Execute<T>(Vector2 position) where T : ICommand
    {
        _history.Add(GetCommand<T>().Invoke(position));
        if (_history.Count > MaxHistoryCount)
            _history.RemoveAt(0);
    }

    public void Undo()
    {
        if (_history.Count == 0) return;
        AHistory history = _history[_history.Count - 1];
        history.Command.Undo(history);
        _history.RemoveAt(_history.Count - 1);
    }
}
