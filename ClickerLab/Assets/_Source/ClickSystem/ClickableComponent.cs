using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ClickableComponent : MonoBehaviour
{
    private Score _score;
    private bool _addScore;
    public void ConstructComponent(Score score, bool addScore)
    {
        _score = score;
        _addScore = addScore;
    }

    private void OnMouseDown()
    {
        if (_addScore)
        {
            _score.AddScore();
        }
        else
        {
            _score.ReduceScore();
        }
    }
}