using UnityEngine;

public class Game
{
    private Score _score;
    public Game(Score score)
    {
        _score = score;
    }

    public void OnApplicationStart()
    {
        _score.SetupScore();
    }

    public void OnApplicationExit()
    {
        _score.ResetScore();
        Application.Quit();
    }
}
