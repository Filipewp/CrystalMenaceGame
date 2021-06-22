using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject Door;
    public GameObject Door2;
    public GameObject gen;
    public GameObject gen2;
    public bool generator = false;

    void Start()
    {
        
    }

   
    void Update()
    {
       
    }

    void Activate()
    {
        Debug.Log("Click");
        Door.GetComponent<DoorController>().locked = false;
        Door2.GetComponent<DoorController>().locked = false;
        if (generator == true)
        {
            gen.SendMessage("GeneratorOn");
            gen2.SendMessage("GeneratorOn");
        }
    }
}
