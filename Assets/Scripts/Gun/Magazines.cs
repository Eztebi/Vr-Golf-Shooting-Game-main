using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Magazines : MonoBehaviour
{
    private IObjectPool<Magazines> objPool;

    public IObjectPool<Magazines> ObjectPool { set => objPool = value; }

    public void DeactivateHit()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);

        objPool.Release(this);
    }


}
