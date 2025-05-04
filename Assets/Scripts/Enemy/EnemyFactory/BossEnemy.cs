using UnityEngine;

public class BossEnemyFactory : EnemyFactory
{
    public GameObject CreateEnemy(EnemyData data, Vector3 position)
    {
        GameObject enemy = GameObject.Instantiate(data.prefab, position, Quaternion.identity);
        enemy.name = $"Boss_{data.enemyName}";
        return enemy;
    }
}