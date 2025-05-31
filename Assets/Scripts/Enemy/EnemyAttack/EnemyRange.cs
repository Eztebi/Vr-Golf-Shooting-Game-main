using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;


[CreateAssetMenu(menuName = "Attack Behaviors/Ranged")]
public class RangedAttackSO : AttackSO
{
    [Header("Setup")]
    public GameObject projectilePrefab;
    [SerializeField] private EnemyBullet _bulletPrefab;
    [SerializeField] private float muzzleVelocity = 10f;
    [SerializeField] private float delayShoot = 1f;

    [Header("Pool Settings")]
    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int _defaultCapacityPool = 10;
    [SerializeField] private int _maxSizePool = 40;

    private float timer = 0f;
    private IObjectPool<EnemyBullet> objPool;

    public override void ExecuteAttack(GameObject user, Transform target)
    {
        if (objPool == null)
        {
            InitPool();
        }

        if (target == null) return;

        timer += Time.deltaTime;

        if (timer >= delayShoot)
        {
            timer = 0f;
            Shoot(user, target);
        }
    }

    private void InitPool()
    {
        IObjectPool<EnemyBullet> tempPool = null;

        tempPool = new ObjectPool<EnemyBullet>(
            () =>
            {
                EnemyBullet bullet = Object.Instantiate(_bulletPrefab);
                bullet.ObjectPool = tempPool;
                return bullet;
            },
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            collectionCheck,
            _defaultCapacityPool,
            _maxSizePool
        );

        objPool = tempPool;
    }

    void Shoot(GameObject user, Transform target)
    {
        if (objPool != null && target != null)
        {
            EnemyBullet bullet = objPool.Get();
            if (bullet == null) return;

            Transform firePoint = user.transform.Find("FirePoint") ?? user.transform;

            // Posiciona la bala en el FirePoint
            bullet.transform.position = firePoint.position;

            // Calcula la dirección hacia el objetivo
            Vector3 direction = (target.position - firePoint.position).normalized;

            // Asigna dirección y orientación a la bala
            bullet.SetDirection(direction);

            // Activa el temporizador para desactivarse si no choca
            bullet.DeactivateNoHit();

        }
    }
    private void OnGetFromPool(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(EnemyBullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(EnemyBullet bullet)
    {
        Object.Destroy(bullet.gameObject);
    }
}