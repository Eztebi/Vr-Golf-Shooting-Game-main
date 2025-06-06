using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static RoundManager Instance { get; private set; }

    [SerializeField] private GameObject roundBoton;

    private int round;
    private int enemiesLeft;
    [SerializeField]private int score = 0;
    [SerializeField]private int scoreGoal = 1000;

    [SerializeField] private bool isRoundFinished = true;

    public Observer<int> EnemiesLeft = new Observer<int>(0);
    public Observer<int> Round = new Observer<int>(0);
    public Observer<int> Score = new Observer<int>(0);
    public Observer<int> ScoreGoal = new Observer<int>(1000);

    public int ScoreGet { get { return score; } set { score = value; } }
    public int ScoreSet { set { score = value; } }

    public int ScoreGoalGet { get { return scoreGoal; } set { scoreGoal = value; } }
    public int ScoreGoalSet { set { scoreGoal = value; } }

    public bool IsRoundFinished => isRoundFinished;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        round = 0;
        enemiesLeft = 0;
        score = 0;
        scoreGoal = 1000;
    }

    void Start()
    {
        
        EnemiesLeft.Value = enemiesLeft;
        Round.Value = round;
        Score.Value = score;
        ScoreGoal.Value = scoreGoal;

        EnemiesLeft.Invoke();
        Round.Invoke();
        Score.Invoke();
        ScoreGoal.Invoke();

        roundBoton.SetActive(true);
    }

    public EnemySpawner enemySpawner;
    public SpawnBall ballSpawneer;

    public void IniciarSiguienteRonda()
    {
        score = 0;
        scoreGoal = 1000;

        Score.Value = 0;
        ScoreGoal.Value = 1000;

        Score.Invoke();
        ScoreGoal.Invoke();

        isRoundFinished = false;
        round++;
        Round.Value = round;

        enemiesLeft = 0;
        EnemiesLeft.Value = enemiesLeft;
        EnemiesLeft.Invoke();

        roundBoton.SetActive(false);
        ballSpawneer.startSpawning = true;
        ballSpawneer.Spawn();
    }
    public void EnemigoSpawneado()
    {
        enemiesLeft++;
        EnemiesLeft.Value = enemiesLeft;
        EnemiesLeft.Invoke();
    }
    public void SetNewScore(int score)
    {
        Score.Value += score;
        this.score += score;
    }

    private int CalcularEnemigos(int ronda)
    {
        return 5 + ronda * 2 - 5;
    }

    public void EnemigoEliminado()
    {
        enemiesLeft--;
        EnemiesLeft.Value = enemiesLeft;
        EnemiesLeft.Invoke();

        if ((enemiesLeft <= 0) && (score >= scoreGoal))
        {
            roundBoton.SetActive(true);
            Debug.Log("Ronda completada");
            ballSpawneer.startSpawning = false;
            isRoundFinished = true;
        }
    }
}
