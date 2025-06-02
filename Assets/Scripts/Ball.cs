using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Ball : MonoBehaviour
{
    public event Action OnClubCollision;

    Rigidbody body;
    private IObjectPool<Ball> objPool;
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

            objPool.Release(this);
        }
    }

    //public void DeactivateNoHit()
    //{
    //    StartCoroutine(TimeDeactivation(dealyDeactivation));
    //}

    IEnumerator TimeDeactivation(float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactivateHit();
    }

    bool isDeactivating = false;

    //void Update()
    //{
    //    if (!isDeactivating && this.gameObject.activeSelf)
    //    {
    //        StartCoroutine(TimeDeactivation(dealyDeactivation));
    //        isDeactivating = true;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Club"))
        {
            StartCoroutine(BallWaitToSpawn());
        }
    }
    IEnumerator BallWaitToSpawn()
    {
        yield return new WaitForSeconds(2f);
        OnClubCollision?.Invoke();
    }
    public void TriggerClubCollisionEvent()
    {
        OnClubCollision?.Invoke();
    }
}