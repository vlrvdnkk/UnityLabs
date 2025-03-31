using _Source.Management;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private Button clickButton;
    
        private bool _isPressing;
        private float _pressTime;
        private float _scorePerSecond;

        private void Start()
        {
            _scorePerSecond = GameManager.Instance.GetScorePerSecond();
        }

        private void Update()
        {
            if (_isPressing)
            {
                _pressTime += Time.deltaTime;
            }
        }

        public void OnPointerDown()
        {
            _isPressing = true;
            _pressTime = 0f;
        }

        public void OnPointerUp()
        {
            _isPressing = false;
            GameManager.Instance.AddScore(_pressTime * _scorePerSecond);
            GameManager.Instance.SaveGame();
        }
    }
}