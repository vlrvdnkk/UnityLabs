using _Source.Players;
using Mirror;
using UnityEngine;

namespace _Source.Objects
{
    public class Bullet : NetworkBehaviour
    {
        [SerializeField] private float speed = 10f;
        [SerializeField] private float lifeTime = 5f;
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private LayerMask playerLayer;

        private void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        private void Update()
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & wallLayer) != 0)
            {
                Destroy(gameObject);
            }
            else if (((1 << collision.gameObject.layer) & playerLayer) != 0)
            {
                collision.GetComponent<PlayerHealth>().TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}