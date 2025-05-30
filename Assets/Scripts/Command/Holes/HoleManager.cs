using System.Collections.Generic;
using UnityEngine;

enum Holes
{
    Bala1,
    Bala2,
    Bala3,
    Multiplicador1,
    Multiplicador2, 
    Multiplicador3,

}
public class HoleManager : MonoBehaviour
{
    public static HoleManager Instance { get; private set; }
    private Queue<Holes> fifoQueue = new Queue<Holes>();
    SpawnMagazines spawneer;
    Bullet bullet;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
       
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
        //if()
    }

    void DamageMultiplier()
    {
        ICommand command = new IDamageMultiplier(bullet);
        CommandInvoker.ExecuteCommand(command);
    }
    void Start()
    {
        spawneer = GetComponent<SpawnMagazines>();
    }

}
