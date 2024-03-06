using BulletSystem;
using UnityEngine;

namespace PlayerSystem
{
    public class CharacterShooter
    {
        private Player _player;
        private BulletPool _bulletPool;

        public CharacterShooter(Player player, BulletPool bulletPool)
        {
            _player = player;
            _bulletPool = bulletPool;
        }
        
        public void Shoot()
        {
            if (_bulletPool.TryGetFromPool(out GameObject bulletInstance))
            {
                bulletInstance.transform.position = _player.FirePoint.position;
                bulletInstance.transform.rotation = _player.FirePoint.rotation;
            }
        }
    
    }
}
