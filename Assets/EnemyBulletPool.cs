using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;

public class EnemyBulletPool : MonoBehaviour
{
    private IObjectPool<EnemyBullet> objPool;

    [SerializeField] private EnemyBullet _bulletPrefab;
    [SerializeField] private Transform muzzlePosition;
    [SerializeField] private float muzzleVelocity;
    [SerializeField] private float bulletCooldown;
    [SerializeField] private int _bulletCount;
    [SerializeField] private int _bulletCountMax;

    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int _defaultCapacityPool = 20;
    [SerializeField] private int _maxSizePool = 40;

    private EnemyBullet CreateBullet()
    {
        EnemyBullet bulletInstance = Instantiate(_bulletPrefab);
        bulletInstance.ObjectPool = objPool;
        return bulletInstance;
    }

    private void OnGetFromPool(EnemyBullet pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(EnemyBullet pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(EnemyBullet pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    void Start()
    {
        _bulletCount = _bulletCountMax;
        objPool = new ObjectPool<EnemyBullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, _defaultCapacityPool, _maxSizePool);

    }

    
    void Shoot()
    {
        if (objPool != null)
        {
            EnemyBullet bullObj = objPool.Get();
            if (bullObj == null) return;

            bullObj.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            Rigidbody rb = bullObj.GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(bullObj.transform.forward * muzzleVelocity, ForceMode.Impulse);

            bullObj.DeactivateNoHit();
            _bulletCount--;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is create

    // Update is called once per frame
    void Update()
    {
        
    }
}
