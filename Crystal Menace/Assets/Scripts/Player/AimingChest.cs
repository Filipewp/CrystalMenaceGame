using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingChest : MonoBehaviour
{
    public Transform chest;
    public Transform Cam;


    //void Update()
    //{
    //    chest.rotation = Cam.rotation ; 
    //}

    void LateUpdate()
    {
        chest.transform.LookAt(chest.transform.position - Cam.transform.forward);
    }
}
