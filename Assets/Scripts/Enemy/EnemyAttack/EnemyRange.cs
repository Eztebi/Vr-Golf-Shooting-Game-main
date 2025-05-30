using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(menuName = "Attack Behaviors/Ranged")]
public class RangedAttackSO : AttackSO
{
    public GameObject weapon;
    public GameObject projectilePrefab;
    public float delayShoot;
    public float bulletAmount;
    private float timer = 0;
    public override void ExecuteAttack(GameObject user, Transform target)
    {
        if (objPool == null)
        {
            objPool = new ObjectPool<EnemyBullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, _defaultCapacityPool, _maxSizePool);
            thisTransform.transform.position = user.transform.position;
        }
            if (target != null)
        {

            if (timer > delayShoot)
            {
                //Shoot(user,target);
                //Transform firePoint = user.transform.Find("FirePoint") ?? user.transform;
                //GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

                //Vector3 direction = (target.position - firePoint.position).normalized;
                //projectile.GetComponent<Rigidbody>().linearVelocity = direction * 10f; // ajustar velocidad
                timer = 0;
            }
            else { timer += Time.deltaTime; }
        }
    }
    private IObjectPool<EnemyBullet> objPool;

    [SerializeField] private EnemyBullet _bulletPrefab;
    [SerializeField] private Transform muzzlePosition;
    [SerializeField] private float muzzleVelocity;
    [SerializeField] private float bulletCooldown;
    [SerializeField] private int _bulletCount;
    [SerializeField] private int _bulletCountMax;
    private GameObject thisTransform;
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


    void Shoot(GameObject user , Transform target)
    {
        if (objPool != null)
        {
            EnemyBullet bullObj = objPool.Get();
            if (bullObj == null) return;

            bullObj.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            Rigidbody rb = bullObj.GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(bullObj.transform.forward * muzzleVelocity, ForceMode.Impulse);
            Transform firePoint = user.transform.Find("FirePoint") ?? user.transform;
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity,thisTransform.transform);

            Vector3 direction = (target.position - firePoint.position).normalized;
            projectile.GetComponent<Rigidbody>().linearVelocity = direction * 10f;
            bullObj.DeactivateNoHit();
            _bulletCount--;
        }
    }




}