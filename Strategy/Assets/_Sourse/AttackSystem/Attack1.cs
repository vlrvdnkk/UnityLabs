using UnityEngine;

public class Attack1 : IAttackStrategy
{
    public void Attack(Animator animator)
    {
        animator.SetTrigger("Attack1");
    }
}
