using UnityEngine;

public class OutOfBoundsBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Ball ball = other.GetComponent<Ball>();
            ball.DeactivateHit();
        }
    }

}
