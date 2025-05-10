using UnityEngine;

public class MeleeMinionFactory : MinionFactory
{
    public MeleeMinionFactory(EnemyData[] meleeData) : base(meleeData) { }

    public override EnemyData GetEnemyData()
    {
        if (minionData.Length == 0) return null;
        return minionData[Random.Range(0, minionData.Length)];
    }
}