using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    private float _elapsedLifeTime;

    private void Update()
    {
        Move();
        CheckLifeTime();
    }

    private void Move()
    {
        transform.position += transform.right * (Time.deltaTime * _speed);
    }

    private void CheckLifeTime()
    {
        _elapsedLifeTime += Time.deltaTime;
        if (_elapsedLifeTime > _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
