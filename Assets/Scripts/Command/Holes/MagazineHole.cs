using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class MagazineHole : MonoBehaviour
{
    [SerializeField]private SpawnMagazines spawneer;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (spawneer == null) {
                Debug.Log("No espawneoMagazines");
                return;
            }
            
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
