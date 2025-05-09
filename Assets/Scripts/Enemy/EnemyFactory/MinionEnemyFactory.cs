using UnityEngine;

public class MinionEnemyFactory : EnemyFactory
{
    public GameObject CreateEnemy(EnemyData data, Vector3 position)
    {
        GameObject enemy = GameObject.Instantiate(data.prefab, position, Quaternion.identity);
        enemy.name = $"Normal_{data.enemyName}";
        return enemy;
    }

    //public override IEnemyCreator CreateEnemy()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override IEnemyCreator CreateEnemy(EnemyData data, Vector3 position)
    //{
    //    throw new System.NotImplementedException();
    //}
}