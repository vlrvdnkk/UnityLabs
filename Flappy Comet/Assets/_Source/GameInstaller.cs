using UnityEngine;
using Zenject;

namespace _Source
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private CometController cometPrefab;
        [SerializeField] private Bonus bonusPrefab;
        [SerializeField] private Obstacle obstaclePrefab;
        public override void InstallBindings()
        {
            Container.Bind<GameManager>().FromInstance(gameManager).AsSingle();
            Container.Bind<CometController>().FromComponentInNewPrefab(cometPrefab).AsSingle();
            
            Container.BindFactory<Bonus, Bonus.Factory>()
                .FromComponentInNewPrefab(bonusPrefab)
                .AsTransient();
            Container.BindFactory<Obstacle, Obstacle.Factory>()
                .FromComponentInNewPrefab(obstaclePrefab)
                .AsTransient();

        }
    }
}