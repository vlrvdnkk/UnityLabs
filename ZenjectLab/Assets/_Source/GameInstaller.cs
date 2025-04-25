using UnityEngine;
using Zenject;

namespace _Source
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Target targetPrefab;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private DestructibleObstacle obstaclePrefab;
        [SerializeField] private ObstacleSpawner spawnerPrefab;
        [SerializeField] private Debris debrisPrefab;
    
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromComponentInNewPrefab(playerPrefab).AsSingle().NonLazy();
            Container.Bind<Target>().FromComponentInNewPrefab(targetPrefab).AsSingle().NonLazy();
        
            Container.BindFactory<Vector3, Quaternion, Bullet, Bullet.Factory>()
                .FromPoolableMemoryPool(x => x
                    .WithInitialSize(20)
                    .FromComponentInNewPrefab(bulletPrefab)
                    .UnderTransformGroup("Bullets"));
                
            Container.BindFactory<DestructibleObstacle, DestructibleObstacle.Factory>()
                .FromComponentInNewPrefab(obstaclePrefab)
                .AsSingle();
        
            Container.BindFactory<Vector3, Quaternion, Debris, Debris.Factory>()
                .FromPoolableMemoryPool(x => x
                    .WithInitialSize(20)
                    .FromComponentInNewPrefab(debrisPrefab)
                    .UnderTransformGroup("Debris"));
        }
    }
}
