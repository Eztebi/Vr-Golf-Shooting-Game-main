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


    private Ball CreateBall()
    {
        Ball bulletInstance = Instantiate(ball);
        bulletInstance.ObjectPool = objPool;
        return bulletInstance;
    }

    private void OnGetFromPool(Ball pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
        pooledObject.OnClubCollision += Spawn; 
    }

    private void OnReleaseToPool(Ball pooledObject)
    {
        pooledObject.OnClubCollision -= Spawn;
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

            // Coloca la pelota en la posición deseada
            ballObj.transform.position = positionSpawn.position;
            ballObj.transform.rotation = positionSpawn.rotation;

            Rigidbody rb = ballObj.GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;

            //ballObj.DeactivateNoHit();
        }
    }

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objPool = new ObjectPool<Ball>(CreateBall, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, _defaultCapacityPool, _maxSizePool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
