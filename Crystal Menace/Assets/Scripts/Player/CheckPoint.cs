using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Player player;
    public Spawner[] spawn;
    public int numberOfSpawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {

            SaveSystem.SavePlayer(player);
            for (int i = 0; i < numberOfSpawner; i++)
            {
                SaveSystem.SaveSpawn(spawn[i]);
            }
           

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
           
        }
    }
}
