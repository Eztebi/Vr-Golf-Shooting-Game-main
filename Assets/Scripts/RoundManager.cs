using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private int round;
    private int enemiesLeft;

    [Header("Enemy Data")]
    [SerializeField] private EnemyData[] meleeEnemies;
    [SerializeField] private EnemyData[] rangedEnemies;
    [SerializeField] private EnemyData[] bossEnemies;

    private MeleeMinionFactory meleeFactory;
    private RangedMinionFactory rangedFactory;
    private BossEnemyFactory bossFactory;
    private EnemySpawner enemySpawner;


    private void Awake()
    {
        // Crear las fábricas con los datos
        meleeFactory = new MeleeMinionFactory(meleeEnemies);
        rangedFactory = new RangedMinionFactory(rangedEnemies);
        bossFactory = new BossEnemyFactory(bossEnemies);

        // Crear el spawner
        enemySpawner = new EnemySpawner(meleeFactory, rangedFactory, bossFactory);
    }
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
        enemySpawner.SpawnMinionEnemy(this.transform.position);
        enemySpawner.SpawnBoss(this.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
