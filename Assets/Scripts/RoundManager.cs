using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField]private GameObject roundBoton;
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
        roundBoton.SetActive(true);
    }
    void NextRound()
    {
        round++;
    }
  
    void StartRound()
    {
        //Invoke
    }
    public EnemySpawner spawner; // Asigna en el inspector

    public void IniciarSiguienteRonda()
    {
        round++;
        Round.Value = round;

        int enemigosEnEstaRonda = CalcularEnemigos(round);
        enemiesLeft = enemigosEnEstaRonda;
        EnemiesLeft.Value = enemiesLeft;

        spawner.IniciarRonda(enemigosEnEstaRonda);
        roundBoton.SetActive(false);
    }


private int CalcularEnemigos(int ronda)
{
    return 5 + ronda * 2; // Puedes ajustar la curva de dificultad
}


public void EnemigoEliminado()
    {
        enemiesLeft--;
        EnemiesLeft.Value = enemiesLeft;

        if (enemiesLeft <= 0)
        {
            roundBoton.SetActive(true);
            Debug.Log("Ronda completada");
        }
    }
}
