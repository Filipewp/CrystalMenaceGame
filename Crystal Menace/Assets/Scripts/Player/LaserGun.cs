using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    public GameObject LaserPoint;
    public GameObject dot;
    public float offset = 0.1f;

    private GameObject laserInstance;

    private LineRenderer laser;
    private GameObject lightCollider;


    public int laserRange = 50;

    void Start()
    {


        laser = GetComponent<LineRenderer>();
        GetComponent<LineRenderer>().enabled = true;
        //lightCollider.GetComponent<Light>().enabled = false;
    }

    void LateUpdate()
    {

        laser.SetPosition(0, transform.position);
        RaycastHit hit;

        if (Physics.Raycast(LaserPoint.transform.position, LaserPoint.transform.forward, out hit))
        {
            if (hit.collider)
            {
                laser.SetPosition(1, hit.point);


            }

        }
        else
        {
            laser.SetPosition(1, transform.forward * 5000);

        }


        
        
            GetComponent<LineRenderer>().enabled = true;
            if (laserInstance == null)
            {
                laserInstance = Instantiate(dot, hit.point + hit.normal * offset, Quaternion.identity) as GameObject;

            }
            else
            {
                laserInstance.transform.position = hit.point + hit.normal * offset;
            }

        
       
    }
}
