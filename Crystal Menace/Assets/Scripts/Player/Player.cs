using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public GameObject ThirdPersonCam;
    public GameObject AimCam;
    public static Player singleton;
    public float currentHealth;
    public float maxHealth = 100;
    public float speed = 10f;
    public Rigidbody rb;
    public bool isDead = false;
    public Animator animator;
    public HealthBar healthBar;
    public bool Mutation = false;
    public GameObject smash;
    public float damage = 50;
    public bool zoom = false;
    private int _stomp = 0;
    public GameObject shattered;
    public GameObject body;
    public bool OnGround;
   
    Vector2 input;

    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    bool change1 = true;
    bool change2 = true;
    bool change3 = true;

    //bomb effect

    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;
    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _stomp = Animator.StringToHash("Stomp");
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
        body.SetActive(true);
        shattered.SetActive(false);


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

       
        //ThirdPersonCam.SetActive( true);
        //AimCam.SetActive(false);

        transform.Translate(horizontal, 0, vertical);

        if (Input.GetMouseButton(1) && (Mutation == false))
        {
            animator.Play("AimLocomotion");
           
           // ThirdPersonCam.SetActive(false);
            //AimCam.SetActive(true);
        }
        else if (Mutation == false )
        {
            animator.Play("Locomotion");
           // Camanimator.Play("CamZoomOut");
        }

        if (Input.GetMouseButton(1) && (Mutation == true) )
        {
            animator.Play("SymbAimLocomotion");
           
            //ThirdPersonCam.SetActive(false);
            //AimCam.SetActive(true);
        }
        else if (Mutation == true )
        {
            animator.Play("SymbLocomotion");
            //Camanimator.Play("CamZoomOut");
        }

        if (Input.GetButtonDown("Jump"))
        {

            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            OnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && (Mutation == true) && (isDead = false))
        {
           
            smash.SetActive(true);
            StartCoroutine(Die());
            animator.SetTrigger(_stomp);
           

        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && change1 == true)
        {

            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && change2 == true)
        {

            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && change3 == true)
        {

            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(true);
        }


    }
    public void DamagePlayer(float damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            Dead();
        }

        void Dead()
        {
            speed = 0;
            currentHealth = 0;
            isDead = true;
            GetComponent<CrystalBullet>().enabled = false;
            GetComponent<CrystalSmash>().enabled = false;
            body.SetActive(false);
            shattered.SetActive(true);
            Detonate();
            Destroy(shattered, 5.0f);
            
            Debug.Log("Player Is Dead");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {

            //Enemy enemy = other.transform.GetComponent<Enemy>();
            //if (enemy != null)
            //{
            //    enemy.TakeDamage(damage);
            //}

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
    void Stomp()
    {
        animator.SetTrigger("Stomp");
    }
}

