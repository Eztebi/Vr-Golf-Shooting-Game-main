using UnityEngine;

public interface EnemyFactory
{
    GameObject CreateEnemy(EnemyData data, Vector3 position);
}