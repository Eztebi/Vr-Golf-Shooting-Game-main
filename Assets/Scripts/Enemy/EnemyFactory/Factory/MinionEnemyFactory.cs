using UnityEngine;

public abstract class MinioEnemynFactory : EnemyFactory
{
    protected EnemyData[] minionData;

    public MinioEnemynFactory(EnemyData[] minionData)
    {
        this.minionData = minionData;
    }
}
