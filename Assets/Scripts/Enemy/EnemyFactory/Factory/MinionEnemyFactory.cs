using UnityEngine;

public abstract class MinionEnemynFactory : EnemyFactory
{
    protected EnemyData[] minionData;

    public MinionEnemynFactory(EnemyData[] minionData)
    {
        this.minionData = minionData;
    }
}
