using UnityEngine;

public class DestroyAllBallsOnRoundFinished : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (RoundManager.Instance.IsRoundFinished == true)
        {
            if (other.CompareTag("Ball"))
            {
                Ball ball = other.GetComponent<Ball>();
                ball.DeactivateHit();
            }
        }
    }
}
