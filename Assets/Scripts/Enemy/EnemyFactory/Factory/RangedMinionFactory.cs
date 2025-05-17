using UnityEngine;

public class RangedMinionFactory : MinioEnemynFactory
{
    public RangedMinionFactory(EnemyData[] rangedData) : base(rangedData) { }

    public override EnemyData GetEnemyData()
    {
        if (minionData.Length == 0) return null;
        return minionData[Random.Range(0, minionData.Length)];
    }
}