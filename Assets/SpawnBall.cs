using System.Collections;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] Ball ball;
    [SerializeField] Transform positionSpawn;
    private IObjectPool<Ball> objPool;

    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int _defaultCapacityPool = 5;
    [SerializeField] private int _maxSizePool = 10;

    private bool hasBall = false;
    private Coroutine spawnCoroutine = null;
    public bool startSpawning=false;
    private Ball CreateBall()
    {
        Ball bulletInstance = Instantiate(ball);
        bulletInstance.ObjectPool = objPool;
        return bulletInstance;
    }

    private void OnGetFromPool(Ball pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Ball pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(Ball pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    public void Spawn()
    {
        if (objPool != null)
        {
            Ball ballObj = objPool.Get();
            if (ballObj == null) return;

            ballObj.transform.position = positionSpawn.position;
            ballObj.transform.rotation = positionSpawn.rotation;

            Rigidbody rb = ballObj.GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && startSpawning ==true)
        {
            hasBall = true;

           
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball") && startSpawning == true)
        {
            hasBall = false;

            
            if (spawnCoroutine == null)
            {
                spawnCoroutine = StartCoroutine(DelayedSpawn());
            }
        }
    }

    private IEnumerator DelayedSpawn()
    {
        yield return new WaitForSeconds(1f);
        Spawn();
        spawnCoroutine = null;
    }

    void Start()
    {
        objPool = new ObjectPool<Ball>(
            CreateBall,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            collectionCheck,
            _defaultCapacityPool,
            _maxSizePool
        );
        
    }
}