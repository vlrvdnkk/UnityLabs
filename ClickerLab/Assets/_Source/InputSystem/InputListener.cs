using UnityEngine;

public class InputListener : MonoBehaviour
{
    private Game _game;

    public void ConstructGame(Game game)
    {
        _game = game;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _game.OnApplicationExit();
        }
    }
}
