using UnityEngine;

public class AttackPerformer : MonoBehaviour
{
    private IAttackStrategy _attackStrategy;
    private Animator _animator;

    public AttackPerformer(Animator animator)
    {
        _animator = animator;
    }

    public void SetStrategy(IAttackStrategy attackStrategy)
    {
        _attackStrategy = attackStrategy;
    }

    public void PerformAttack()
    {
        _attackStrategy.Attack(_animator);
    }
}