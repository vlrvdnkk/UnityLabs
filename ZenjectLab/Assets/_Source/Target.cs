using UnityEngine;
using Zenject;

namespace _Source
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private float distanceFromCamera = 5f; 
        [SerializeField] private float heightOffset = 0f; 
        [SerializeField] private Vector3 rotationOffset = Vector3.zero; 
        [SerializeField] private Vector3 offsetFromPlayer = new Vector3(5f, 0f, 0f); 

        private Player _player;
        private Transform _cameraTransform;
        private Quaternion _rotationOffset;

        [Inject]
        public void Construct(Player player)
        {
            _player = player;
            _cameraTransform = player.cameraTransform;
            if (_cameraTransform == null)
            {
                Debug.LogError("Camera Transform not provided for Target!", this);
            }
            _rotationOffset = Quaternion.Euler(rotationOffset);
        }

        private void Update()
        {
            if (_cameraTransform == null) return;
            Vector3 cameraPosition = _cameraTransform.position;
            Vector3 cameraForward = _cameraTransform.forward;
        
            Vector3 targetPosition = cameraPosition + cameraForward * distanceFromCamera + offsetFromPlayer;
            targetPosition.y += heightOffset;
            transform.position = targetPosition;
            transform.rotation = Quaternion.LookRotation(-cameraForward) * _rotationOffset;
        }
    }
}