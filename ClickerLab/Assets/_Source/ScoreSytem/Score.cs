using System;

public class Score
{
    private const int _startValue = 5;
    private const int _endValue = 0;
    private int _score;

    public Action<int> OnScorechange;

    public int Value
    {
        get { return _score; }
        set
        {
            _score = value;
            OnScorechange?.Invoke(_score);
        }
    }

    public Score()
    {
        SetupScore();
    }

    public void ResetScore()
    {
        Value = _endValue;
    }

    public void SetupScore()
    {
        Value = _startValue;
    }

    public void AddScore()
    {
        Value++;
    }

    public void ReduceScore()
    {
        if (Value == 0) return;
        Value--;
    }
}
