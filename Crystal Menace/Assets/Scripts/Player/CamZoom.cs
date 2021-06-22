using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    public bool zoom = false;
    Animator animator;
    public float m_FieldOfView;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            zoom = true;
            animator.SetBool("Zoom", zoom);
            Camera.main.fieldOfView = 35;
        }
        else
        {
            zoom = false;
            animator.SetBool("Zoom", zoom);
            Camera.main.fieldOfView = 60;
        }
    }

   
}
