using UnityEngine;

public class SpawnCommandHistory : AHistory
{
    public GameObject SpawnedGameObject;

    public SpawnCommandHistory(ICommand command, Vector2 position, GameObject spawnedGameObject) : base(command, position)
    {
        SpawnedGameObject = spawnedGameObject;
    }
}
