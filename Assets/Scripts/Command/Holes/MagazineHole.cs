using System.ComponentModel;
using UnityEngine;

public class MagazineHole : MonoBehaviour
{
    SpawnMagazines spawneer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (spawneer == null) return;

            else
            {
                ICommand command = new ISpawnMagazines(spawneer, spawneer.magPrefabs);
                CommandInvoker.ExecuteCommand(command);
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawneer = GetComponent<SpawnMagazines>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
