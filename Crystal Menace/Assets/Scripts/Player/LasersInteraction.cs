using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasersInteraction : MonoBehaviour
{
    public GameObject ToActivate1;
    public GameObject ToActivate2;
    public GameObject ToActivate3;
    public GameObject ToActivate4;
    public float cooldownTime = 20;
    private float nextFireTime = 0;
    public GameObject Disable1;
    public GameObject Disable2;
    public GameObject Disable3;
    public GameObject Disable4;
    public GameObject Boss;
    public float damage;

    public AudioSource RayLaser;

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
        if (Time.time > nextFireTime)
        {

          




            if (other.tag == "Player")
            {
                CanvasE.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    RayLaser.Play();
                    ToActivate1.SendMessage("Activate");
                    ToActivate2.SendMessage("Activate");
                    ToActivate3.SendMessage("Activate");
                    ToActivate4.SendMessage("Activate");
                    nextFireTime = Time.time + cooldownTime;
                    Disable1.SendMessage("DisableTerminal");
                    Disable2.SendMessage("DisableTerminal");
                    Disable3.SendMessage("DisableTerminal");
                    Disable4.SendMessage("DisableTerminal");
                    Boss.GetComponent<CrystalBoss>().TakeDamage(damage);



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