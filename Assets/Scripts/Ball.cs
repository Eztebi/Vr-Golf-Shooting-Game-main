using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{
    //public event Action OnClubCollision;

    Rigidbody body;
    private IObjectPool<Ball> objPool;
    private bool activateWallCollision;
    //private float dealyDeactivation = 25;

    void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    public IObjectPool<Ball> ObjectPool { set => objPool = value; }

    public void DeactivateHit()
    {
        {
            if (body == null)
                body = GetComponent<Rigidbody>();

            body.linearVelocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            gameObject.layer = LayerMask.NameToLayer("Ball");
            activateWallCollision = false;
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
}