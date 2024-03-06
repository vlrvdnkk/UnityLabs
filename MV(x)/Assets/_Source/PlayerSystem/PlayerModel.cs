using System;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerModel
    {
        public event Action<int> OnHealthChange;
        public event Action OnPlayerDeath;
        private int _hp;
        private float _speed;
        
        public int HP => _hp;
        public float Speed => _speed;

        public PlayerModel(int hp, float speed)
        {
            _hp = hp;
            _speed = speed;
        }
        
        public void AddHp(int value)
        {
            _hp += value;
            OnHealthChange?.Invoke(_hp);
            if(_hp <= 0)
                OnPlayerDeath?.Invoke();
        }
    }
}
