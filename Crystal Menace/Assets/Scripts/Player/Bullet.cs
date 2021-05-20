using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float force = 50000;
    GameObject fpsCam;

    void Awake()
    {
        fpsCam = GameObject.FindGameObjectWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
        rb.AddForce(fpsCam.transform.forward * force);
        StartCoroutine(Die());

    }
    IEnumerator Die()
    {
       
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
