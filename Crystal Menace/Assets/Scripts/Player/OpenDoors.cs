using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject Door;
    public GameObject Door2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activate()
    {
        
        Door.GetComponent<DoorController>().locked = false;
        Door2.GetComponent<DoorController>().locked = false;
    }
}
