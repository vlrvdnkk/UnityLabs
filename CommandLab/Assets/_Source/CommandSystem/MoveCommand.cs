using UnityEngine;

public class MoveCommand : ICommand
{
    private readonly PlayerMovement _playerMovement;

    public MoveCommand(PlayerMovement characterMovement)
    {
        _playerMovement = characterMovement;
    }

    public AHistory Invoke(Vector2 position)
    {
        Vector2 currentDestination = _playerMovement.CurrentDestination;
        _playerMovement.MoveTo(position);
        MoveCommandHistory moveCommandHistory = new MoveCommandHistory(this, position, currentDestination);

        return moveCommandHistory;
    }

    public void Undo(AHistory history)
    {
        MoveCommandHistory moveHistory = (MoveCommandHistory)history;

        _playerMovement.MoveTo(moveHistory.PreviousPosition);
    }
}
