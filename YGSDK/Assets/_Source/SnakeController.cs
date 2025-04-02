using UnityEngine;

namespace _Source
{
    public class SnakeController : MonoBehaviour
    {
        [SerializeField] private Vector2 firstDirection;
        [SerializeField] private float moveSpeed = 5f;
        
        [SerializeField] private LayerMask foodLayer;
        [SerializeField] private LayerMask wallLayer;
        
        [SerializeField] private GameManager gameManager;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)) firstDirection = Vector2.up;
            if (Input.GetKeyDown(KeyCode.S)) firstDirection = Vector2.down;
            if (Input.GetKeyDown(KeyCode.A)) firstDirection = Vector2.left;
            if (Input.GetKeyDown(KeyCode.D)) firstDirection = Vector2.right;
        }

        private void FixedUpdate()
        {
            Vector2 movement = firstDirection * moveSpeed * Time.deltaTime;
            transform.position = new Vector2(
                transform.position.x + movement.x,
                transform.position.y + movement.y
            );
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & foodLayer) != 0)
            {
                gameManager.AddScore();

                Destroy(collision.gameObject);
                FindObjectOfType<FoodSpawner>().SpawnFood();
            }
            else if (((1 << collision.gameObject.layer) & wallLayer) != 0)
            {
                gameManager.GameOver();
            }
        }
    }
}
