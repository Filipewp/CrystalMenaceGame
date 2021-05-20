using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSmash : MonoBehaviour
{
    public GameObject smash;
    public float damage = 50;
    public Animator animator;
    public bool Mutation = false;
    public bool stomp = false;
    private int _Stomp = 0;
    public GameObject Crystals;
    public GameObject pointCrystal;
    public GameObject ShatteredCrystal;
    public AudioSource StompSound;

    public float cooldownTime = 2;
    private float nextFireTime = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        _Stomp = Animator.StringToHash("Stomp");
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.E) && (Mutation == true))
            {
                stomp = true;
                smash.SetActive(true);
                StartCoroutine(Die());
                animator.SetTrigger(_Stomp);
                StompSound.Play();
                //animator.Play("CrystalStomp");
                GameObject clone = GameObject.Instantiate(Crystals, pointCrystal.transform.position, pointCrystal.transform.rotation);
                Destroy(clone, 1.0f);
                //StartCoroutine(Shatter(clone));
                nextFireTime = Time.time + cooldownTime;
            }
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Enemy")
        {

            //Enemy enemy = other.transform.GetComponent<Enemy>();
            //if (enemy != null)
            //{
            //    enemy.TakeDamage(damage);
            //}

            //ShootingEnemy enemyShoot = other.transform.GetComponent<ShootingEnemy>();
            //if (enemyShoot != null)
            //{
            //    enemyShoot.TakeDamage(damage);
            //}

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

    //IEnumerator Shatter(GameObject clone2)
    //{

    //    yield return new WaitForSeconds(0.9f);
    //    GameObject clone = GameObject.Instantiate(ShatteredCrystal, clone2.transform.position, clone2.transform.rotation);
    //    Destroy(clone, 2.0f);
    //}
}
