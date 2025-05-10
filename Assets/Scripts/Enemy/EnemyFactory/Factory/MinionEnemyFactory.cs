using UnityEngine;

public abstract class MinionFactory : EnemyFactory
{
    protected EnemyData[] minionData;

    public MinionFactory(EnemyData[] minionData)
    {
        this.minionData = minionData;
    }
}
