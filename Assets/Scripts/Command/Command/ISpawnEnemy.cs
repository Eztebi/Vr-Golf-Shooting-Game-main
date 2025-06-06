using UnityEngine;

public class ISpawnEnemy : ICommand
{
    EnemySpawner enemyspawneer;

    public ISpawnEnemy(EnemySpawner enemySpawner)
    {
        this.enemyspawneer = enemySpawner;
    }

    public void Execute()
    {
        enemyspawneer.SpawnAllMinions();
    }

    public void Undo()
    {

    }
}
