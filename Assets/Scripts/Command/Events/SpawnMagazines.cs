using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SpawnMagazines : MonoBehaviour
{
    private IObjectPool<Magazines> objPool;
    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int _defaultCapacityPool = 20;
    [SerializeField] private int _maxSizePool = 40;
    [SerializeField] private List<GameObject> positionMags;
    public Magazines magPrefabs;

    #region Objectpool creation
    private Magazines CreateMag()
    {
        Magazines magInstance = Instantiate(magPrefabs);
        magInstance.ObjectPool = objPool;
        return magInstance;
    }
    
    private void OnGetFromPool(Magazines pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Magazines pooledObject)
    {
        pooledObject.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(Magazines pooledObject)
    {
        Destroy(pooledObject.gameObject);
    }
    #endregion
    private void Start()
    {
        objPool = new ObjectPool<Magazines>(CreateMag, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, _defaultCapacityPool, _maxSizePool);
        Spawn();
    }
    public void Spawn()
    {
        if (objPool != null)
        {
            foreach (GameObject position in positionMags)
            {
                Magazines magObj = objPool.Get();
                if (magObj == null) return;

                magObj.transform.SetPositionAndRotation(position.transform.position, position.transform.rotation);
            }
        }
    }
}
