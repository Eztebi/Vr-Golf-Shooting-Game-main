using UnityEngine;

public class EnemySelector : IEnemySelector
{
    private MinioEnemynFactory meleeFactory;
    private MinioEnemynFactory rangedFactory;
    private BossEnemyFactory bossFactory;

    public EnemySelector(MinioEnemynFactory minionmeleeFactory, MinioEnemynFactory minionrangedFactory, BossEnemyFactory bossFactory)
    {
        this.meleeFactory = minionmeleeFactory;
        this.rangedFactory = minionrangedFactory;
        this.bossFactory = bossFactory;
    }

    public EnemyData GetEnemyData(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Minion:
                return GetMinion();
            
            case EnemyType.Boss:
                return bossFactory.GetEnemyData();
            default:
                return null;
        }
    }
    public EnemyData GetMinion() {
        int rand = Random.Range(0, 2);
        switch (rand)
        {
            case 0:
                return meleeFactory.GetEnemyData();
            case 1:
                return rangedFactory.GetEnemyData();
            default:
                return null;
        }
        
            
        
    }
    public EnemyData GetBoss()
    {
        int rand;
        return bossFactory.GetEnemyData();
    }

    public EnemyData GetEnemyData(BossEnemyFactory enemyType)
    {
        throw new System.NotImplementedException();
    }

    public EnemyData GetEnemyData()
    {
        throw new System.NotImplementedException();
    }

    public EnemyData GetEnemyData(MinioEnemynFactory enemyType)
    {
        throw new System.NotImplementedException();
    }

    public EnemyData GetEnemyData(EnemyFactory enemyType)
    {
        throw new System.NotImplementedException();
    }
}

