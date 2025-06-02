using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int round;
    private int enemiesLeft;
    public Observer<int> EnemiesLeft = new Observer<int>(0);
    public Observer<int> Round = new Observer<int>(0);

    //public event RoundFinishes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        round = 0;
        enemiesLeft = 0;
        EnemiesLeft.Invoke();
        Round.Invoke();
        EnemiesLeft.Value = enemiesLeft;
        Round.Value = round;    
    }
    void NextRound()
    {
        round++;
    }
  
    void StartRound()
    {
        //Invoke
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
