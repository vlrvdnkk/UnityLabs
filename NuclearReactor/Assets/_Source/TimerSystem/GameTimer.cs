using System.Globalization;
using TMPro;
using UnityEngine;

namespace TimerSystem
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text timeText;
        private float _timeElapsed;
        private bool _isPaused;

        private void Start()
        {
            _isPaused = false;
        }

        private void Update()
        {
            if(_isPaused) return;
            
            _timeElapsed += Time.deltaTime;

            timeText.text = _timeElapsed.ToString("F2",CultureInfo.InvariantCulture);
        }
        
        public void Pause()
        {
            _isPaused = true;
        }
    }
}
