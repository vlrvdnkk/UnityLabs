using TimerSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameTimer gameTimer;
        [SerializeField] private GameObject lossPanel;
        [SerializeField] private Button lossRestartButton;

        private Game _game;
        
        private void Awake()
        {
            _game = new Game(lossPanel,lossRestartButton, gameTimer);
        }
    }
}
