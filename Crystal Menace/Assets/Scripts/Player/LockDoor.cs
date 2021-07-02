using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public GameObject doorToLock;
    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorToLock.GetComponent<DoorController>().locked = true;
            Spawn1.GetComponent<TimedSpawn>().stopSpawning = false;
            Spawn2.GetComponent<TimedSpawn>().stopSpawning = false;
            Spawn3.GetComponent<TimedSpawn>().stopSpawning = false;
            Spawn4.GetComponent<TimedSpawn>().stopSpawning = false;

            Spawn1.SetActive(true);
            Spawn2.SetActive(true);
            Spawn3.SetActive(true);
            Spawn4.SetActive(true);

        }
    }
    void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
