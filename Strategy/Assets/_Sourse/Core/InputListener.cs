using UnityEngine;

public class InputListener : MonoBehaviour
{
    [SerializeField] private KeyCode _attackKeyCode;
    private AttackPerformer _attackPerformer;

    public void Construct(AttackPerformer attackPerformer)
    {
        _attackPerformer = attackPerformer;
    }

    private void Update()
    {
        CheckAttack();
    }

    private void CheckAttack()
    {
        if (Input.GetKeyDown(_attackKeyCode))
        {
            _attackPerformer.PerformAttack();
        }
    }
}
