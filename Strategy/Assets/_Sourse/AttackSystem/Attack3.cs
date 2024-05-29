using UnityEngine;

public class Attack3 : IAttackStrategy
{
    public void Attack(Animator animator)
    {
        animator.SetTrigger("Attack3");
    }
}
