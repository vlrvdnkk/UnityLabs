using UnityEngine;

public class Bootstrapper : MonoBehaviour
{

    [SerializeField] private ClickableComponent whiteClickableComponent;
    [SerializeField] private ClickableComponent blackClickableComponent;
    [SerializeField] private InputListener inputListener;
    [SerializeField] private ScoreView scoreView;
    private Game _game;
    private Score _score;

    private void Awake()
    {
        Init();
        StartGame();
    }

    private void Init()
    {
        _score = new Score();
        _game = new Game(_score);
        whiteClickableComponent.ConstructComponent(_score, true);
        blackClickableComponent.ConstructComponent(_score, false);
        inputListener.ConstructGame(_game);
        scoreView.ConstructScore(_score);
    }

    private void StartGame()
    {
        _game.OnApplicationStart();
    }
}
