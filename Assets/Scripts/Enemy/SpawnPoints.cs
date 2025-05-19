using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField]public List<SpawnPoint> points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public SpawnPoint NextPoint(List<SpawnPoint> points)
    {
        foreach (SpawnPoint t in points) {
            if (t.hasEnemy == false)
                return t;   
                }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
