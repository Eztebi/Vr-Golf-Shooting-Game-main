using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    private Vector3 direction;
    private IObjectPool<EnemyBullet> objPool;
    private Coroutine deactivationRoutine;

    public IObjectPool<EnemyBullet> ObjectPool { set => objPool = value; }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void DeactivateHit()
    {
        if (objPool != null)
        {
            objPool.Release(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DeactivateNoHit()
    {
        if (deactivationRoutine != null)
            StopCoroutine(deactivationRoutine);
        deactivationRoutine = StartCoroutine(TimeDeactivation(3f));
    }

    private IEnumerator TimeDeactivation(float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactivateHit();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript player = other.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.TakeDamage(10);
            }
            DeactivateHit();
        }
        if (other.CompareTag("Bullet"))
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if(bullet != null)
            {
                bullet.DeactivateHit();
            }
            DeactivateHit();
        }

    }
}