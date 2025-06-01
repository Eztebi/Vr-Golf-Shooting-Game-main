using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    GunScript gun;
    [SerializeField] private float dealyDeactivation = 3f;
    [SerializeField] private int damage;
    private int tempDamage;
    [SerializeField] private bool time;
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
        tempDamage = damage;
        gun = GetComponentInParent<GunScript>();
    }
    bool isDeactivating = false;


    // Update is called once per frame
    void Update()
    {
        if (!isDeactivating && this.gameObject.activeSelf)
        {
            StartCoroutine(TimeDeactivation(dealyDeactivation));
            isDeactivating = true;
        }
        if (!gun.isDamageMult)
        {
            damage = tempDamage;
        }
        else
        {
            damage = (int)gun.damageMultiplier;
        }
        

    }

    public void AddDamage(int dmg)
    {
        gun.isDamageMult = true;
        damage = dmg;
    }

}
