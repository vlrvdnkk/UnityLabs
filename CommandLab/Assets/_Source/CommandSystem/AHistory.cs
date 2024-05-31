using UnityEngine;

public abstract class AHistory
{
    public ICommand Command;
    public Vector2 Position;

    public AHistory(ICommand command, Vector2 position)
    {
        Command = command;
        Position = position;
    }
}
