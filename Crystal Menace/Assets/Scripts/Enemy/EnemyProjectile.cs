using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    float damage = 10f;
    public float accuracy = 1.0f;
    Rigidbody rb;

    [SerializeField]
    float speed = 500f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 bulletAccuracy = new Vector3(Random.Range(0, accuracy), Random.Range(0, accuracy), Random.Range(0, accuracy));
        Vector3 direction = (target.position - transform.position) + bulletAccuracy;
        rb.AddForce(direction * speed * Time.deltaTime);
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Player playerHealth = collision.transform.GetComponent<Player>();
            playerHealth.DamagePlayer(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
