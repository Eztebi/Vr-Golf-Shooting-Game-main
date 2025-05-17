using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : IEnemySelector
{
    private MeleeMinionFactory meleeMinionFactory;
    private RangedMinionFactory rangedMinionFactory;
    private BossEnemyFactory bossEnemyFactory;

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
            GameObject.Instantiate(data.prefab, position, Quaternion.identity).name = data.enemyName;
        }
    }

    public void SpawnBoss(Vector3 position)
    {
        EnemyData data  = bossEnemyFactory.GetEnemyData();

        if (data != null)
        {
            GameObject.Instantiate(data.prefab, position, Quaternion.identity).name = data.enemyName;
        }
    }
    public EnemyData GetMinionRandom(RangedMinionFactory rangedMinion, MeleeMinionFactory meleeMinion)
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

    public EnemyData GetEnemyData(MinioEnemynFactory enemyType)
    {
        return enemyType.GetEnemyData();
    }
}


