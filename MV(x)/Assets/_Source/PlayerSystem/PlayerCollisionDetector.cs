using System;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCollisionDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyMask;
        private Player _player;
        
        public void ConstructCollisionDetect(Player player)
        {
            _player = player;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(_enemyMask == (_enemyMask  | (1<<other.gameObject.layer)))
            {
                _player.GetDamage(-1);
            }
        }
    }
}