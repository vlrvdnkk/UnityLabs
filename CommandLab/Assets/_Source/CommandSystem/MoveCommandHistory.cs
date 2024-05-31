using UnityEngine;

public class MoveCommandHistory : AHistory
{
    public Vector2 PreviousPosition;

    public MoveCommandHistory(ICommand command, Vector2 position, Vector2 previousPosition) : base(command, position)
    {
        PreviousPosition = previousPosition;
    }
}
