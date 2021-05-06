using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Camera ThirdPersonCam;
    public Camera AimCam;
    public static Player singleton;
    public float currentHealth;
    public float maxHealth = 100f;
    public float speed = 10f;
    public Rigidbody rb;
    public bool isDead = false;
    public Animator animator;
    public bool Mutation = false;
    public GameObject smash;
    public float damage = 50;

    public bool OnGround;
   
    Vector2 input;


    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
       
       
    }

    private void FixedUpdate()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");


        animator.SetFloat("InputX", input.x);
        animator.SetFloat("InputY", input.y);

    }
    void Update()
    {
        if (Input.GetKey("m"))
        {
            SaveSystem.SavePlayer(this);
            
        }
        if (Input.GetKey("n"))
        {
            PlayerData data = SaveSystem.LoadPlayer();
           

            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;


            
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

       
        ThirdPersonCam.GetComponent<Camera>().enabled = true;
        AimCam.GetComponent<Camera>().enabled = false;

        transform.Translate(horizontal, 0, vertical);

        if (Input.GetMouseButton(1) && (Mutation == false))
        {
            animator.Play("AimLocomotion");
            ThirdPersonCam.GetComponent<Camera>().enabled = false;
            AimCam.GetComponent<Camera>().enabled = true;
        }
        else if (Mutation == false)
        {
            animator.Play("Locomotion");
        }

        if (Input.GetMouseButton(1) && (Mutation == true))
        {
            animator.Play("SymbAimLocomotion");
            ThirdPersonCam.GetComponent<Camera>().enabled = false;
            AimCam.GetComponent<Camera>().enabled = true;
        }
        else if (Mutation == true)
        {
            animator.Play("SymbLocomotion");
        }

        if (Input.GetButtonDown("Jump"))
        {

            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            OnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && (Mutation == true))
        {
            Stomp();
            smash.SetActive(true);
            StartCoroutine(Die());
            
        }

    }
    public void DamagePlayer(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
        }
        else
        {
            Dead();
        }

        void Dead()
        {
            currentHealth = 0;
            isDead = true;
            Debug.Log("Player Is Dead");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
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




        }
    }

    IEnumerator Die()
    {

        yield return new WaitForSeconds(0.5f);
        smash.SetActive(false);
    }

    void Stomp()
    {
        animator.SetTrigger("Stomp");
    }
}

