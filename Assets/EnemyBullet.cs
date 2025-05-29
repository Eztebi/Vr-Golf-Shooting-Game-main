using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float dealyDeactivation = 3f;
    public int damage = 10;
    private IObjectPool<EnemyBullet> objPool;

    public IObjectPool<EnemyBullet> ObjectPool { set => objPool = value; }
    public void DeactivateHit()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0, 0, 0);
        rb.angularVelocity = new Vector3(0, 0, 0);

        objPool.Release(this);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.CompareTag("Player")) {
    //        PlayerScript player = collision.collider.GetComponent<PlayerScript>();
    //        player.TakeDamage(damage);
    //        Destroy(this.gameObject);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript player = other.GetComponent<PlayerScript>();
            player.TakeDamage(damage);
            Destroy(this.gameObject);
        }
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
    private void Update()
    {
        if (this.gameObject.activeSelf == true)
        {
            StartCoroutine(TimeDeactivation(dealyDeactivation));
            return;
        }
    }
}