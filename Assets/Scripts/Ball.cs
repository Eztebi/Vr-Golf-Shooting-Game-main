using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{
    //public event Action OnClubCollision;

    private Rigidbody body;
    private IObjectPool<Ball> objPool;
    private bool activateWallCollision;
    //private float dealyDeactivation = 25;
    private int currentScore =0;
    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    public IObjectPool<Ball> ObjectPool { set => objPool = value; }
    public int Score { get { return currentScore; } set { currentScore = value; } }
    public void DeactivateHit()
    {
        {
            if (body == null)
                body = GetComponent<Rigidbody>();

            body.linearVelocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            gameObject.layer = LayerMask.NameToLayer("Ball");
            activateWallCollision = false;
            currentScore = 0;
            objPool.Release(this);
        }
    }

    IEnumerator TimeDeactivation(float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactivateHit();
    }



    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("PlayerWall") && activateWallCollision == false)
        {
            gameObject.layer = LayerMask.NameToLayer("BallCrossed");
            activateWallCollision = true;
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (GetComponent<Collider>().CompareTag("PlayerWall") && activateWallCollision == true)
    //    {
    //        gameObject.layer = LayerMask.NameToLayer("BallCrossed");
    //        activateWallCollision = true;
    //    }
    //}
    [SerializeField] private float force = 4;
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
        if (collision.collider.CompareTag("Obstacle"))
        {
            Score += 10; 
        }

    }

}