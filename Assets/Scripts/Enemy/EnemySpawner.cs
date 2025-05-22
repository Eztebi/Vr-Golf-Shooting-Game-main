using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IEnemySelector
{

    [Header("Enemy Data")]
    [SerializeField] private EnemyData[] meleeEnemies;
    [SerializeField] private EnemyData[] rangedEnemies;
    [SerializeField] private EnemyData[] bossEnemies;

    private MeleeMinionFactory meleeMinionFactory;
    private RangedMinionFactory rangedMinionFactory;
    private BossEnemyFactory bossEnemyFactory;

    SpawnPoints spawnPoints;
    private void Awake()
    {
        // Crear las fábricas con los datos
        meleeMinionFactory = new MeleeMinionFactory(meleeEnemies);
        rangedMinionFactory = new RangedMinionFactory(rangedEnemies);
        bossEnemyFactory = new BossEnemyFactory(bossEnemies);
        spawnPoints = GetComponentInChildren<SpawnPoints>();
    }
    public EnemySpawner(MeleeMinionFactory meleeMinion, RangedMinionFactory rangedMinion, BossEnemyFactory bossFactory)
    {
        this.meleeMinionFactory = meleeMinion;
        this.rangedMinionFactory = rangedMinion;
        this.bossEnemyFactory = bossFactory;
    }
    public void SpawnMinionEnemy(Vector3 position)
    {
        EnemyData data = GetMinionRandom(rangedMinionFactory, meleeMinionFactory);
      
        if (data != null)
        {
            GameObject enemyObj = GameObject.Instantiate(data.prefab, position, Quaternion.identity);
            enemyObj.name = data.enemyName;
            EnemyController controller = enemyObj.GetComponent<EnemyController>();
            if (controller != null)
            {
                controller._enemyData = data;
            }
        }
    }

    public void SpawnBoss(Vector3 position)
    {
        EnemyData data  = bossEnemyFactory.GetEnemyData();

        if (data != null)
        {
            GameObject bossObj = Instantiate(data.prefab, position, Quaternion.identity);
            bossObj.name = data.enemyName;

            EnemyController controller = bossObj.GetComponent<EnemyController>();
            if (controller != null)
            {
                controller.enemyData = data;
            }
        }
    }
    private EnemyData GetMinionRandom(RangedMinionFactory rangedMinion, MeleeMinionFactory meleeMinion)
    {
        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                return meleeMinion.GetEnemyData();
            case 1:
                return rangedMinion.GetEnemyData();
            default:
                return null;
        }

    }
    public EnemyData GetEnemyData(EnemyFactory enemyType)
    {
        return enemyType.GetEnemyData();
    }

    public EnemyData GetEnemyData(MinionEnemynFactory enemyType)
    {
        return enemyType.GetEnemyData();
    }
    private void Update()
    {
        
    }
}


