using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject ToActivate;
    public GameObject ToDie;
    public GameObject ToDie2;
    public GameObject[] Spawns;
   



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {

                ToActivate.SendMessage("Activate");
                ToDie.SendMessage("DieNow");
                ToDie2.SendMessage("DieNow");
                for (int i = 0; i < Spawns.Length; i++)
                {
                    Spawns[i].SetActive(true);
                }
               
            }


        }
    }
}
