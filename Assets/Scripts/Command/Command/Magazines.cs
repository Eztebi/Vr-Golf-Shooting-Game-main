using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Magazines : MonoBehaviour
{
    [SerializeField] private float dealyDeactivation = 3f;
    [SerializeField] private int damage;
    private IObjectPool<Magazines> objPool;

    public IObjectPool<Magazines> ObjectPool { set => objPool = value; }

    public void DeactivateHit()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);

        objPool.Release(this);
    }
    public void DeactivateNoHit()
    {
        StartCoroutine(TimeDeactivation(dealyDeactivation));
    }
    IEnumerator TimeDeactivation(float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactivateHit();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
