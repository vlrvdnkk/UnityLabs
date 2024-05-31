using UnityEngine;

public interface ICommand
{
    AHistory Invoke(Vector2 position);
    void Undo(AHistory history);
}
