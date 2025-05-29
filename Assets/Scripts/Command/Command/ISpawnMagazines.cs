using UnityEngine;

public class ISpawnMagazines : ICommand
{
    SpawnMagazines spawnMags;
    Magazines prefabs;
    
    public ISpawnMagazines(SpawnMagazines spawnMags, Magazines prefabs)
    {
        this.spawnMags = spawnMags;
        this.prefabs = prefabs;
    }

    public void Execute()
    {
        spawnMags.Spawn();
    }

    public void Undo()
    {
        
    }
}