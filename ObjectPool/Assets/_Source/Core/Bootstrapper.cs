using BulletSystem;
using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace CoreSystem
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private InputListener inputListener;
        [SerializeField] private Player player;

        private BulletPool _bulletPool;
        private CharacterShooter _characterShooter;

        private void Awake()
        {
            _bulletPool = new BulletPool(player);
            _characterShooter = new CharacterShooter(player,_bulletPool);
            inputListener.ConstructCharacterShooter(_characterShooter);
            _bulletPool.MaxPoolSize = player.MaxPoolSize;
            _bulletPool.StartPoolSize = player.StartPoolSize;
        }
    }
}
