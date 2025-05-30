using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void Impulse(float force)
    {
        body.AddForce(this.transform.position*force);
    }
   
}
