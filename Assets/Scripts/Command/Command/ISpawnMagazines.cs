using UnityEngine;

public class ISpawnMagazines : ICommand<SpawnMagazines>
{
    SpawnMagazines spawnMags;
    GameObject prefabs;

    public ISpawnMagazines(SpawnMagazines spawnMags, GameObject prefabs)
    {
        this.spawnMags = spawnMags;
        this.prefabs = prefabs;
    }

    public void Execute(SpawnMagazines clase)
    {
        spawnMags.Spawn();
    }

    public void Undo()
    {
        throw new System.NotImplementedException();
    }
}