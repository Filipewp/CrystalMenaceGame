using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] SpawnPoint;
    public int SpawnPoints = 0;
    public bool activeSpawn = true;


    void Update()
    {
        if (Input.GetKey("k"))
        {
            SpawnerData SpawnData = SaveSystem.LoadSpawn();

            activeSpawn = SpawnData.activeSpawn;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && activeSpawn == true)
        {

            for (int i = 0; i < SpawnPoints; i++)
            {
                GameObject clone = GameObject.Instantiate(enemy[0], SpawnPoint[0].transform.position, SpawnPoint[0].transform.rotation);
                
            }
            

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            activeSpawn = false;
            
        }
    }
}
