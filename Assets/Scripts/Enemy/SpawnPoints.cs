using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField]public List<SpawnPoint> points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public SpawnPoint NextPoint()
    {
        foreach (SpawnPoint t in points) {
            if (t.hasEnemy == false)
            {
                t.hasEnemy = true;
                return t;
            }

        }
        return null;
    }
    public void FreePoint()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
