using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnerData 
{
    public bool activeSpawn;

    public SpawnerData(Spawner spawner)
    {
        activeSpawn = spawner.activeSpawn;
    }
}
