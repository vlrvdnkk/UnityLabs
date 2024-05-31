using UnityEngine;

public class Enemy3 : AEnemy
{
    private static readonly int AttackAnimationHash = Animator.StringToHash("Attack3");

    [SerializeField] private Animator _animator;

    private void Start()
    {
        IsControlledByPlayer = true;
    }

    public override void Attack()
    {
        _animator.SetTrigger(AttackAnimationHash);
    }
}
