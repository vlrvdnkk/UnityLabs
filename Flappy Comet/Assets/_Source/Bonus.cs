using UnityEngine;
using VContainer;

namespace _Source
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float attractSpeed;
        [SerializeField] private float destroyDistance;

        private CometController _cometController;
        private GameManager _gameManager;
        private Transform _cometTransform;
        private LayerMask _cometLayer;
        private bool _isAttracting;
        private Vector3 _spawnPosition;
        private Quaternion _spawnRotation;

        [Inject]
        private void Construct(CometController controller, GameManager gameManager)
        {
            _cometController = controller;
            _gameManager = gameManager;
        }
        
        public void Initialize(Vector3 spawnPosition, Quaternion spawnRotation, Transform parent)
        {
            _spawnPosition = spawnPosition;
            _spawnRotation = spawnRotation;

            transform.position = _spawnPosition;
            transform.rotation = _spawnRotation;
            transform.SetParent(parent);
        }

        private void Start()
        {
            _cometTransform = _cometController.gameObject.transform;
            _cometLayer = _cometController.gameObject.layer;
        }

        private void Update()
        {
            if (_isAttracting && _cometTransform != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, _cometTransform.position, attractSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, _cometTransform.position) < destroyDistance)
                {
                    GameManager.Instance.AddScore(1);
                    Destroy(gameObject);
                }
            }
            else
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            
            if (transform.position.x < -_gameManager.ScreenWidth - _gameManager.SpawnBufferWidth)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == _cometLayer)
            {
                _isAttracting = true;
            }
        }
    }
}