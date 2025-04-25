using UnityEngine;
using Zenject;

namespace _Source
{
    public class DestructibleObstacle : MonoBehaviour, IDestructible
    {
        [SerializeField] private Debris debrisPrefab;
        [SerializeField] private int debrisCount = 5;
        [SerializeField] private float debrisForce = 2f;
        [SerializeField] private float debrisOffsetRadius = 0.5f;

        private Debris.Factory _debrisFactory;

        [Inject]
        public void Construct(Debris.Factory debrisFactory)
        {
            _debrisFactory = debrisFactory;
        }
    

        public void DestroyObstacle()
        {
            if (_debrisFactory == null)
            {
                return;
            }
        
            for (int i = 0; i < debrisCount; i++)
            {
                Vector3 randomOffset = Random.insideUnitSphere * debrisOffsetRadius;
                Debris debris = _debrisFactory.Create(transform.position + randomOffset, Quaternion.identity);
                debris.Rigidbody.AddForce(Random.insideUnitSphere * debrisForce, ForceMode.Impulse);
            }
        
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<DestructibleObstacle>
        {
        }
    }
    
    public interface IDestructible
    {
        void DestroyObstacle();
    }
}