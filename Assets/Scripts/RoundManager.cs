using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int round;
    private int enemiesLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        round = 0;
        enemiesLeft = 0;
    }
    void NextRound()
    {
        round++;
    }
    int EnemiesLeft()
    {
        return enemiesLeft;
    }
    void StartRound()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
