
using UnityEngine;

public interface IEnemySelector
    {

        EnemyData GetEnemyData(EnemyFactory enemyType);
        EnemyData GetEnemyData(MinioEnemynFactory enemyType);
}
