using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float dealyDeactivation = 3f;
    [SerializeField] private int damage;
    private IObjectPool<Bullet> objPool;

    public IObjectPool<Bullet> ObjectPool { set => objPool = value; }

    public void DeactivateHit()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0,0,0);
        
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Gun"))
        {

        }
        else if (collision.collider.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.collider.GetComponent<EnemyController>();
            enemy.RecieveDamage(damage);
        }
        else
        {
            DeactivateNoHit();
        }
    }
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            StartCoroutine(TimeDeactivation(dealyDeactivation));
            return;
        }

    }
}
