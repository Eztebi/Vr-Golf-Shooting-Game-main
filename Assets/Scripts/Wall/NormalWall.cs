using UnityEngine;

public class NormalWall : MonoBehaviour
{
    [SerializeField] private float force = 2;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Ball ball = collision.collider.GetComponent<Ball>();
            ball.Impulse(force);
        }
    }
}
