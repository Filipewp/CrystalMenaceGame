using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBall : MonoBehaviour
{
    public Transform target;
    //public GameObject player;
    public float step = 10.0f;

    const float m_dropChance = 1f / 5f;
    public GameObject enemyPos;
    public GameObject healOrbs;
    bool loot = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Life").transform;
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(Vector3.Normalize(target.position - transform.position) * step);

      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().HealPlayer(10);
            //player.GetComponent<Player>().HealPlayer(10);
            Destroy(gameObject);

        }
    }

    
}
