using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSmash : MonoBehaviour
{
    public GameObject smash;
    public float damage = 50;
    public Animator animator;
    public bool Mutation = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (Mutation == true))
        {

            smash.SetActive(true);
            StartCoroutine(Die());
            //animator.Play("CrystalStomp");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Enemy")
        {

            Enemy enemy = other.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            ShootingEnemy enemyShoot = other.transform.GetComponent<ShootingEnemy>();
            if (enemyShoot != null)
            {
                enemyShoot.TakeDamage(damage);
            }

            OnHeadShoot headShoot = other.transform.GetComponent<OnHeadShoot>();

            if (headShoot != null)
            {
                headShoot.Vanish(damage);
            }


        }
    }

    IEnumerator Die()
    {

        yield return new WaitForSeconds(0.5f);
        smash.SetActive(false);
    }
    
}
