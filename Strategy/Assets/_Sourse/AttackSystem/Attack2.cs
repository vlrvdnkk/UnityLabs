using UnityEngine;

public class Attack2 : IAttackStrategy
{
    public void Attack(Animator animator)
    {
        animator.SetTrigger("Attack2");
    }
}
