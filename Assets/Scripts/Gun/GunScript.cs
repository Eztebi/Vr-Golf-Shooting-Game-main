using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit;

public class GunScript : MonoBehaviour
{
    [SerializeField] private Transform GunPos;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform muzzlePosition;
    [SerializeField] private float muzzleVelocity;
    [SerializeField] private float bulletCooldown;
    [SerializeField] private int _bulletCount;
    [SerializeField] private int _bulletCountMax;
    [SerializeField] public bool isDamageMult;
    [SerializeField] public float bulletCooldownMult = 10f;
    [SerializeField] public float damageMultiplier;
    public float tempBulletCooldownMult = 10f;
    private IObjectPool<Bullet> objPool;

    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int _defaultCapacityPool = 20;
    [SerializeField] private int _maxSizePool = 40;

    [SerializeField] XRGrabInteractable grabbable;

    private bool isHeld = false;

    private Bullet CreateBullet()
    {
        Bullet bulletInstance = Instantiate(_bulletPrefab);
        bulletInstance.ObjectPool = objPool;
        return bulletInstance;
    }

    private void OnGetFromPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Bullet pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(Bullet pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }

    void Start()
    {
        _bulletCount = _bulletCountMax;
        objPool = new ObjectPool<Bullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, _defaultCapacityPool, _maxSizePool);

        grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Shoot);
        grabbable.selectEntered.AddListener(OnSelectEntered);
        grabbable.selectExited.AddListener(OnSelectExited);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        isHeld = true;
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        isHeld = false;
    }

    void Shoot(ActivateEventArgs arg)
    {
        if (objPool != null && _bulletCount > 0)
        {
            Bullet bullObj = objPool.Get();
            if (bullObj == null) return;

            bullObj.transform.SetPositionAndRotation(muzzlePosition.position, muzzlePosition.rotation);

            Rigidbody rb = bullObj.GetComponent<Rigidbody>();
            rb.angularVelocity = Vector3.zero;
            rb.AddForce(bullObj.transform.forward * muzzleVelocity, ForceMode.Impulse);

            bullObj.DeactivateNoHit();
            _bulletCount--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Mag"))
        {
            Magazines mag = collision.collider.GetComponent<Magazines>();
            _bulletCount = _bulletCountMax;
            mag.DeactivateHit();
        }
    }

    void Update()
    {
        if (!isHeld)
        {
           
           this.transform.position = GunPos.position;
           this.transform.rotation = GunPos.rotation;
            //rb.MoveRotation(GunPos.rotation);
        }
    }
}