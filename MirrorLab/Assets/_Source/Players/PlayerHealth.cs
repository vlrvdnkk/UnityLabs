using Mirror;
using UnityEngine;

namespace _Source.Players
{
    public class PlayerHealth : NetworkBehaviour
    {
        [Header("Respawn Settings")] 
        [SerializeField] private float minRespawnTime;
        [SerializeField] private float maxRespawnTime;

        public void TakeDamage()
        {
            if (!isServer) return;

            RpcDie();
        }

        [ClientRpc]
        private void RpcDie()
        {
            gameObject.SetActive(false);
        }
    }
}