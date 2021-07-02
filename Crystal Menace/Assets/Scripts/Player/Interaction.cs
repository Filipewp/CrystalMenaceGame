using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject ToActivate;
    public GameObject ToDie;
    public GameObject ToDie2;
    public GameObject[] Spawns;
    public GameObject CanvasE;




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
            CanvasE.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
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

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CanvasE.SetActive(false);
        }
    }
}
