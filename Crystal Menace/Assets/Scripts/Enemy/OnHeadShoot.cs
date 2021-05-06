using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OnHeadShoot : MonoBehaviour
{
    //bomb effect

    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    //VanishPart

    public Animator parent;
    public GameObject partToVanish;
    public GameObject replacement;
    Collider coll;
    public GameObject positionHead;
    public bool deadHead = false;


    //public Canvas canv;

    public float health = 50f;

    private void Start()
    {
        coll = GetComponent<Collider>();
        
    }



    public void Vanish(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            parent.enabled = false;
            GameObject clone = GameObject.Instantiate(replacement, positionHead.transform.position, positionHead.transform.rotation);
            coll.enabled = false;
            Detonate();
            Destroy(partToVanish);
            deadHead = true;
            Destroy(clone, 5.0f);


        }

    }


    void Detonate()
    {
        Vector3 explosionPosition = bomb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPosition, radius, upForce, ForceMode.Impulse);
            }
        }
    }

}
