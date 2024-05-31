using UnityEngine;

public class Enemy1 : AEnemy
{
    private static readonly int AttackAnimationHash = Animator.StringToHash("Attack1");

    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        Attack();
    }

    public override void Attack()
    {
        _animator.SetTrigger(AttackAnimationHash);
    }
}