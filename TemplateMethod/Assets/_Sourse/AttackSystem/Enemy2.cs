using UnityEngine;

public class Enemy2 : AEnemy
{
    private static readonly int AttackAnimationHash = Animator.StringToHash("Attack2");

    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _missilePrefab;
    [SerializeField] private float _attackCooldown;
    private float _timeFromAttack;

    public override void Attack()
    {
        _animator.SetTrigger(AttackAnimationHash);
        Instantiate(_missilePrefab, transform);
    }

    private void Update()
    {
        CheckCooldown();
    }

    private void CheckCooldown()
    {
        _timeFromAttack += Time.deltaTime;
        if (_timeFromAttack > _attackCooldown)
        {
            Attack();
            _timeFromAttack = 0;
        }
    }
}
