using UnityEngine;
using Zenject;

namespace _Source
{
    public class Player : MonoBehaviour
    {
        public Transform cameraTransform;
    
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private float fireRate = 0.2f;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float mouseSensitivity = 100f; 
        [SerializeField] private Vector3 cameraOffset = new Vector3(0f, 2f, -5f);
        [SerializeField] private float minPitch = -30f;
        [SerializeField] private float maxPitch = 60f;

        private float nextFireTime;
        private float yaw;
        private float pitch;
        private CharacterController _characterController;
    
        private Bullet.Factory _bulletFactory;
        private Target _target;

        [Inject]
        public void Construct(Bullet.Factory bulletFactory, Target target)
        {
            _bulletFactory = bulletFactory;
            _target = target;
        }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        
            if (cameraTransform != null)
            {
                yaw = transform.eulerAngles.y;
                pitch = cameraTransform.eulerAngles.x;
            }
        }

        private void Update()
        {
            HandleMovement();
            HandleCameraRotation();
        
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate;
            }
        }

        private void HandleMovement()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");
        
            Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
            moveDirection = moveDirection.normalized * moveSpeed;
        
            _characterController.Move(moveDirection * Time.deltaTime);
        }

        private void HandleCameraRotation()
        {
            if (cameraTransform == null) return;
        
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
            transform.rotation = Quaternion.Euler(0f, yaw, 0f);
            cameraTransform.rotation = Quaternion.Euler(pitch, yaw, 0f);
            cameraTransform.position = transform.position + transform.TransformDirection(cameraOffset);
        }

        private void Shoot()
        {
            if (cameraTransform == null) return;
        
            Vector3 direction = cameraTransform.forward;
            var bullet = _bulletFactory.Create(bulletSpawnPoint.position, Quaternion.LookRotation(direction));
            bullet.Initialize(_target);
        }

        private void OnDestroy()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}