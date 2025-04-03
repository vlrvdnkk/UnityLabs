using Mirror;
using UnityEngine;

namespace _Source.Players
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private float fireCooldown;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;

        private float lastFireTime;

        private void Update()
        {
            if (!isLocalPlayer) return;

            if (Input.GetMouseButtonDown(1) && Time.time - lastFireTime >= fireCooldown)
            {
                CmdFire();
                lastFireTime = Time.time;
            }
        }

        [Command]
        private void CmdFire()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            NetworkServer.Spawn(bullet);
        }
    }
}
