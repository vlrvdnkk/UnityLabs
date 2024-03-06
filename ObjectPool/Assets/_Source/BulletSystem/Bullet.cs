using System;
using UnityEngine;

namespace BulletSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float lifeTime;
        
        private float _currentLifeTime;
        public Action OnLifeEnd;
        public Action OnBulletDestroy;
        
        private void OnEnable()
        {
            _currentLifeTime = lifeTime;
        }

        private void Update()
        {
            Move();
            CheckLifeTime();
        }

        private void Move()
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        
        private void CheckLifeTime()
        {
            _currentLifeTime -= Time.deltaTime;
            if(_currentLifeTime<0) 
                OnLifeEnd.Invoke();
        }

        private void OnDestroy()
        {
            OnBulletDestroy.Invoke();
        }
    }
}
