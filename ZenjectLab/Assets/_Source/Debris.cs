using UnityEngine;
using Zenject;

namespace _Source
{
    public class Debris : MonoBehaviour, IPoolable<Vector3, Quaternion, IMemoryPool>
    {
        [HideInInspector] public Rigidbody Rigidbody;
        [HideInInspector] public Collider Collider;
        private IMemoryPool _pool;

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();
            Collider.isTrigger = true; 
        }

        public void OnSpawned(Vector3 position, Quaternion rotation, IMemoryPool pool)
        {
            transform.position = position;
            transform.rotation = rotation;
            _pool = pool;
            Rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(true);
        }

        public void OnDespawned()
        {
            _pool = null;
            gameObject.SetActive(false);
        }

        public class Factory : PlaceholderFactory<Vector3, Quaternion, Debris>
        {
        }
    }
}