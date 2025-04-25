using UnityEngine;
using Zenject;

namespace _Source
{
    [RequireComponent(typeof(Rigidbody), typeof(AudioSource))]
    public class Bullet : MonoBehaviour, IPoolable<Vector3, Quaternion, IMemoryPool>
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float lifetime = 3f;
        [SerializeField] private AudioClip shootSound;
        [SerializeField] private AudioClip hitSound;
        [SerializeField] private float targetRadius = 5f;
        [SerializeField] private LayerMask collidingObjectsLayer;
    
        private Rigidbody _rb;
        private Target _target;
        private IMemoryPool _pool;
        private float _spawnTime;
        private AudioSource _audioSource;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _audioSource = GetComponent<AudioSource>();
            if (_audioSource == null)
            {
            }
        }

        public void Initialize(Target target)
        {
            if (target == null)
            {
                return;
            }
            _target = target;
            _spawnTime = Time.time;
            if (_audioSource != null && shootSound != null)
            {
                _audioSource.PlayOneShot(shootSound);
            }
        }

        private void FixedUpdate()
        {
            if (_pool == null || _target == null)
            {
                return;
            }

            if (Time.time - _spawnTime >= lifetime)
            {
                _pool.Despawn(this);
                return;
            }
        
            Collider[] hits = Physics.OverlapSphere(transform.position, targetRadius);
            bool hasObstacle = false;
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent<IDestructible>(out _))
                {
                    hasObstacle = true;
                    break;
                }
            }
        
            if (!hasObstacle)
            {
                Vector3 direction = (_target.transform.position - transform.position).normalized;
                _rb.velocity = direction * speed;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_pool == null)
            {
                return;
            }
        
            if (((1 << collision.gameObject.layer) & collidingObjectsLayer.value) != 0)
            {
                if (hitSound != null)
                {
                    GameObject soundObject = new GameObject("HitSound");
                    soundObject.transform.position = transform.position;
                    AudioSource soundSource = soundObject.AddComponent<AudioSource>();
                    soundSource.PlayOneShot(hitSound);
                    Destroy(soundObject, hitSound.length);
                }
            }
        
            if (collision.gameObject.TryGetComponent<IDestructible>(out var destructible))
            {
                destructible.DestroyObstacle();
            }
            _pool.Despawn(this);
        }

        public void OnSpawned(Vector3 position, Quaternion rotation, IMemoryPool pool)
        {
            transform.position = position;
            transform.rotation = rotation;
            _pool = pool;
            _rb.velocity = transform.forward * speed;
            gameObject.SetActive(true);
        }

        public void OnDespawned()
        {
            _pool = null;
            _target = null;
            _rb.velocity = Vector3.zero; 
            gameObject.SetActive(false); 
        }

        public class Factory : PlaceholderFactory<Vector3, Quaternion, Bullet>
        {
        }
    }
}