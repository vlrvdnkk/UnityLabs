using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private Player _player;
        
        public void ConstructorPlayer(Player player)
        {
            _player = player;
        }

        private void Update()
        {
            ReadPlayerMove();
        }

        private void ReadPlayerMove()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            
            _player.MovePlayer(new Vector3(x,y));
        }
    }
}
