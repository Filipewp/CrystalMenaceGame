using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float animationDuration;
    private Animator myAnimator;
    public bool locked = false;
    public GameObject DoorLight;
    public Light lt;
    public Light lt2;
   
 



    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        AnimationClip[] clips = myAnimator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip c in clips)
        {
            if (c.name == "Open")
            {
                animationDuration = c.length;
            }
        }
    }

    void Update()
    {
        if(locked==true)
        {
            DoorLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
            lt.GetComponent<Light>().color=Color.red;
            lt2.GetComponent<Light>().color = Color.red;
        }
        if (locked == false)
        {
            DoorLight.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
            lt.GetComponent<Light>().color = Color.green;
            lt2.GetComponent<Light>().color = Color.green;
        }
    }

    public void OpenDoor()
    {
        myAnimator.ResetTrigger("CloseDoor");
        myAnimator.SetTrigger("OpenDoor");
       
        //StartCoroutine(closeDoorCoroutine());
        //Hascontrol.hasControl = true;
    }
    public void CloseDoor()
    {
        myAnimator.ResetTrigger("OpenDoor");
        myAnimator.SetTrigger("CloseDoor");
       

    }

    private IEnumerator closeDoorCoroutine()
    {
        yield return new WaitForSeconds(2f);
        myAnimator.ResetTrigger("OpenDoor");
        myAnimator.SetTrigger("CloseDoor");
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        if (locked == false)
    //        {

    //            Debug.Log("hit");

    //            OpenDoor();
    //            //StartCoroutine(DelayCoroutine());
    //        }
    //    }
    //    if (other.tag == "Enemy")
    //    {


    //        if (locked == false)
    //        {

    //            Debug.Log("hit");

    //            OpenDoor();
    //            //StartCoroutine(DelayCoroutine());
    //        }
    //    }
    //}
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (locked == false)
            {

                Debug.Log("hit");

                OpenDoor();
                //StartCoroutine(DelayCoroutine());
            }
        }
        if (other.tag == "Enemy")
        {


            if (locked == false)
            {

                Debug.Log("hit");

                OpenDoor();
                //StartCoroutine(DelayCoroutine());
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        CloseDoor();
    }

   

}
