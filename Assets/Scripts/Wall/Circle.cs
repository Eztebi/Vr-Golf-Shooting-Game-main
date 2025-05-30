using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private float force = 5;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Ball ball = collision.collider.GetComponent<Ball>();
            ball.Impulse(force);
        }
    }
}
