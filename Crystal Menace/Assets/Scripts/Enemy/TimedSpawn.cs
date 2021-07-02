using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    public GameObject enemy;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        if (stopSpawning == false)
        {
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        }
    }
    void Update()
    {
        //if (stopSpawning == false)
        //{
        //    InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        //}
    }
    public void SpawnObject()
    {
        if (stopSpawning==false)
        {
            Instantiate(enemy, transform.position, transform.rotation);
        }
        if(stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
