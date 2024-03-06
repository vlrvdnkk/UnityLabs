using System;
using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _playerRigidbody;
        [SerializeField] private PlayerView _playerHealthView;
        [SerializeField] private PlayerCollisionDetector _playerCollisionDetector;
        [SerializeField] private InputListener _inputListener;
        
        private Player _player;
        private PlayerModel _playerModel;
        private PlayerMovement _playerMovement;
            
        private void Awake()
        {
            _playerModel = new PlayerModel(100,5);
            _playerMovement = new PlayerMovement(_playerRigidbody,_playerModel.Speed);
            _player = new Player(_playerModel,_playerMovement,_playerHealthView);
            _playerCollisionDetector.ConstructCollisionDetect(_player);
            _inputListener.ConstructorPlayer(_player);
        }
    }
}
