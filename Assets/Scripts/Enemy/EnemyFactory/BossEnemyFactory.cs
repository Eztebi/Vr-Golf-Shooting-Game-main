 using UnityEngine;

public class BossEnemyFactory : EnemyFactory
{
    private EnemyData[] bossData;

    public BossEnemyFactory(EnemyData[] bossData)
    {
        this.bossData = bossData;
    }

    public override EnemyData GetEnemyData()
    {
        if (bossData.Length == 0) return null;
        return bossData[Random.Range(0, bossData.Length)];
    }
}
