using UnityEngine;

public class NormalWall : MonoBehaviour
{
    [SerializeField] private float force = 2;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.collider.GetComponent<Rigidbody>();
            if (ballRb != null && collision.contactCount > 0)
            {
                Vector3 normal = collision.contacts[0].normal;
                ballRb.AddForce(-normal * force, ForceMode.Impulse);
            }
        }
    }
}
