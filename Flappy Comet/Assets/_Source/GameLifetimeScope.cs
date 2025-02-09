using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace _Source
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameManager gameManager;
        [SerializeField] private CometController cometPrefab;
        [SerializeField] private Bonus bonusPrefab;
        [SerializeField] private Obstacle obstaclePrefab;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(gameManager).AsSelf();

            builder.RegisterComponentInNewPrefab(cometPrefab, Lifetime.Singleton).AsSelf();
            
            builder.RegisterFactory<Obstacle>(container =>
            {
                return () => Instantiate(obstaclePrefab);
            }, Lifetime.Transient);
            
            builder.RegisterFactory<Obstacle>(container =>
            {
                return () =>
                {
                    var obstacle = Instantiate(obstaclePrefab);
                    container.Inject(obstacle);
                    return obstacle;
                };
            }, Lifetime.Transient);

            builder.RegisterFactory<Bonus>(container =>
            {
                return () =>
                {
                    var bonus = Instantiate(bonusPrefab);
                    container.Inject(bonus);
                    return bonus;
                };
            }, Lifetime.Transient);
        }
    }
}
