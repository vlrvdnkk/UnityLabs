using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode shootKeyCode;
        private CharacterShooter _characterShooter;

        public void ConstructCharacterShooter(CharacterShooter characterShooter)
        {
            _characterShooter = characterShooter;
        }
        
        private void Update()
        {
            CheckShoot();
        }

        private void CheckShoot()
        {
            if (Input.GetKeyDown(shootKeyCode))
            {
                _characterShooter.Shoot();
            }
        }
    }
}
