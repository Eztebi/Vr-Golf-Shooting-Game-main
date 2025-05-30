using UnityEngine;

public class Triangle : MonoBehaviour
{
    [SerializeField] private float force=10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball")){
            Ball ball=collision.collider.GetComponent<Ball>();
            ball.Impulse(force);
        }
    }
}
