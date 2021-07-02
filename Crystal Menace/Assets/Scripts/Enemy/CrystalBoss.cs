using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBoss : MonoBehaviour
{
    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    public GameObject shattered;
    public GameObject body;

    public float currentHealth;
    public float maxHealth = 100;

    public GameObject Spawn1;
    public GameObject Spawn2;
    public GameObject Spawn3;
    public GameObject Spawn4;

    public GameObject doorToOpen;
    public AudioSource lastStand;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        body.SetActive(true);
        shattered.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
           
            Dead();
        }

    }
    //public void DamagePlayer(float damage)
    //{
    //    if (currentHealth > 0)
    //    {
    //        currentHealth -= damage;
           
    //    }
    //    else
    //    {
    //        Dead();
    //    }
    //}

    void Dead()
    {


        Spawn1.GetComponent<TimedSpawn>().stopSpawning = true;
        Spawn2.GetComponent<TimedSpawn>().stopSpawning = true;
        Spawn3.GetComponent<TimedSpawn>().stopSpawning = true;
        Spawn4.GetComponent<TimedSpawn>().stopSpawning = true;
        body.SetActive(false);
        shattered.SetActive(true);
        Detonate();
        lastStand.Play();
        Destroy(shattered, 5.0f);
        doorToOpen.GetComponent<DoorController>().locked = false;


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
