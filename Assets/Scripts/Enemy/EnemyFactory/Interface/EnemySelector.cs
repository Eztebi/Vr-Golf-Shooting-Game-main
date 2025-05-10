using UnityEngine;

public class EnemySelector : IEnemySelector
{
    private MinionFactory meleeFactory;
    private MinionFactory rangedFactory;
    private BossEnemyFactory bossFactory;

    public EnemySelector(MinionFactory minionmeleeFactory, MinionFactory minionrangedFactory, BossEnemyFactory bossFactory)
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
}

