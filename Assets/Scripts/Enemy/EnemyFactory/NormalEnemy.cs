using UnityEngine;

public class NormalEnemyFactory : EnemyFactory
{
    public GameObject CreateEnemy(EnemyData data, Vector3 position)
    {
        GameObject enemy = GameObject.Instantiate(data.prefab, position, Quaternion.identity);
        enemy.name = $"Normal_{data.enemyName}";
        return enemy;
    }
}