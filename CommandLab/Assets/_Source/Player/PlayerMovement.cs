using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Vector2 _clickPoint;

    public Vector2 CurrentDestination => _clickPoint;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, _clickPoint, _speed * Time.deltaTime);
    }

    public void MoveTo(Vector2 position)
    {
        _clickPoint = position;
    }
}
