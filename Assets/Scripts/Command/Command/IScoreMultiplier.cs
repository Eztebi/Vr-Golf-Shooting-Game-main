using UnityEngine;

public class IScoreMultiplier : ICommand
{
    Ball ball;
    int score;
    
    public IScoreMultiplier(Ball ball, int score)
    {
        this.ball = ball;
        this.score = score;
    }

    public void Execute()
    {
       RoundManager.Instance.SetNewScore(score);
    }

    public void Undo()
    {

    }
}
