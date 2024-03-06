using UnityEngine;

namespace PlayerSystem
{
    public class Player
    {
        private readonly PlayerModel _model;
        private readonly PlayerView _view;
        private readonly PlayerMovement _playerMovement;
        
        public Player(PlayerModel model, PlayerMovement playerMovement, PlayerView healthView)
        {
            _model = model;
            _view = healthView;
            _playerMovement = playerMovement;
        }

        public void GetDamage(int damage)
        {
            _model.AddHp(damage);
            _view.UpdateHpText(_model.HP);

            if (_model.HP < 30)
                _view.ChangeColor(new Color(200, 200, 200));
        }

        public void MovePlayer(Vector3 destination)
        {
            _playerMovement.Move(destination);
        }
    }
}