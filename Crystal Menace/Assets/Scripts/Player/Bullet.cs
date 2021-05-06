using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float force = 50000;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
        StartCoroutine(Die());

    }
    IEnumerator Die()
    {
       
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
