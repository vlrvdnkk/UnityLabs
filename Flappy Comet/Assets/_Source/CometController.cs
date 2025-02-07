using UnityEngine;

namespace _Source
{
    public class CometController : MonoBehaviour
    {
        [SerializeField] private new ParticleSystem particleSystem;
        [SerializeField] private float jumpForce; 
        [SerializeField] private Rigidbody2D rb;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Jump();
            }
        }

        private void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Lerp(rb.velocity.y, jumpForce, Time.deltaTime));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameManager.Instance.EndGame();
        }
        
        public void GravityOn()
        {
            rb.gravityScale = 1;
        }

        public void ParticleSystemOn()
        {
            particleSystem.Play();
        }
    }
}