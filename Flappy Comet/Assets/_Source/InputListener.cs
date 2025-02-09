using UnityEngine;
using VContainer;

namespace _Source
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private GameObject startText;
        
        private CometController _cometController;
        private bool _start;
    
        [Inject]
        private void Construct(CometController controller)
        {
            _cometController = controller;
        }
        
        private void Update()
        {
            if ((Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0)) & !_start)
            {
                startText.SetActive(false);
                _cometController.GravityOn();
                _cometController.ParticleSystemOn();
                GameManager.Instance.StartCoroutine(GameManager.Instance.SpawnObstacles());
                GameManager.Instance.StartCoroutine(GameManager.Instance.SpawnBonuses());
                _start = true;
            }
        }
    }
}