using System.Collections.Generic;
using PlayerSystem;
using UnityEngine;

namespace BulletSystem
{
    public class BulletPool
    {
        private Queue<GameObject> _bullets;
        private List<GameObject> _firedBullets;
        private Player _player;
        private int _count;
        private int _maxPoolSize;
        private int _startPoolSize;

        public int MaxPoolSize
        {
            get { return _maxPoolSize; }
            set { _maxPoolSize = value; }
        }

        public int StartPoolSize
        {
            get { return _startPoolSize; }
            set { _startPoolSize = value; }
        }

        public BulletPool(Player player)
        {
            _player = player;
            _firedBullets = new List<GameObject>();
            _bullets = new Queue<GameObject>();
            _count = 0;
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _startPoolSize; i++)
            {
                CreateBullet();
            }
        }

        public bool TryGetFromPool(out GameObject bulletInstance)
        {
            if (_bullets.Count == 0)
            {
                if (_count < _maxPoolSize)
                {
                    CreateBullet();
                }
                else if (_count >= _maxPoolSize)
                {
                    bulletInstance = null;
                    return false;
                }
            }

            bulletInstance = _bullets.Dequeue();
            _firedBullets.Add(bulletInstance);
            bulletInstance.SetActive(true);
            return true;
        }

        public void ReturnToPool(GameObject bulletInstance)
        {
            _firedBullets.Remove(bulletInstance);
            _bullets.Enqueue(bulletInstance);
            bulletInstance.SetActive(false);
        }

        private void CreateBullet()
        {
            GameObject bulletInstance = Object.Instantiate(_player.BulletPrefab);
            if (bulletInstance.TryGetComponent(out Bullet bullet))
            {
                bullet.OnLifeEnd += () => ReturnToPool(bullet.gameObject);
                bullet.OnBulletDestroy += () => _count--;
            }
            _count++;
            ReturnToPool(bulletInstance);
        }
    }
}