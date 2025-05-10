using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private IEnemySelector enemySelector;

    public void Initialize(IEnemySelector selector)
    {
        enemySelector = selector;
    }

    public void SpawnEnemy(EnemyType enemyType, Vector3 position)
    {
        EnemyData data = enemySelector.GetEnemyData(enemyType);
        if (data != null)
        {
            GameObject.Instantiate(data.prefab, position, Quaternion.identity).name = data.enemyName;
        }
    }
}