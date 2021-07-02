using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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
    public AudioSource audSource2;
    public AudioSource death;
    //bomb effect

    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    public bool hasControl = true;

    public Material Material1;
    public Material Material2;

    public GameObject Object;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;

    public bool mutation1 = false;
    public bool mutation2 = false;

    public bool Gun1 = false;
    public bool Gun2 = false;
    public bool Gun3 = false;

   


    private NavMeshAgent myNavmeshAgent;

    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        this.GetComponent<Rigidbody>().sleepThreshold = 0.0f;
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
        //currentHealth++10;

        if (mutation1==true)
        {
            Object.GetComponent<SkinnedMeshRenderer>().material = Material1;
            Object1.GetComponent<SkinnedMeshRenderer>().material = Material2;
            Object2.GetComponent<SkinnedMeshRenderer>().material = Material2;
            Object3.GetComponent<SkinnedMeshRenderer>().material = Material2;

        }
        if (Input.GetKey(KeyCode.LeftShift)&& !Input.GetKey(KeyCode.Mouse1))
        {
            speed = 20;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 15;
        }

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
        
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {

            audSource2.Play();
        }
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && audSource2.isPlaying)
        {
            audSource2.Stop();
        }

        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;


        ThirdPersonCam.SetActive( true);
        AimCam.SetActive(false);
       
            transform.Translate(horizontal, 0, vertical);
        
        

        if (Input.GetMouseButton(1) && (Mutation == false))
        {
            animator.Play("AimLocomotion");
           
           ThirdPersonCam.SetActive(false);
           AimCam.SetActive(true);
        }
        else if (Mutation == false )
        {
            animator.Play("Locomotion");
           // Camanimator.Play("CamZoomOut");
        }

        if (Input.GetMouseButton(1) && (Mutation == true) )
        {
            animator.Play("SymbAimLocomotion");
           
            ThirdPersonCam.SetActive(false);
            AimCam.SetActive(true);
        }
        else if (Mutation == true )
        {
            animator.Play("SymbLocomotion");
            //Camanimator.Play("CamZoomOut");
        }

        //if (Input.GetButtonDown("Jump"))
        //{

        //    rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        //    OnGround = false;
        //}

        //if (Input.GetKeyDown(KeyCode.E) && (Mutation == true) && (isDead = false))
        //{
           
        //    smash.SetActive(true);
        //    StartCoroutine(Die());
        //    animator.SetTrigger(_stomp);
           

        //}

        if (Input.GetKeyDown(KeyCode.Alpha1) && Gun1 == true)
        {

            Weapon1.SetActive(true);
            Weapon2.SetActive(false);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && Gun2 == true)
        {

            Weapon1.SetActive(false);
            Weapon2.SetActive(true);
            Weapon3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && Gun3 == true)
        {

            Weapon1.SetActive(false);
            Weapon2.SetActive(false);
            Weapon3.SetActive(true);
        }


    }
    public void HealPlayer(float healamount)
    {
        if (currentHealth > 0 && currentHealth < 100) 
        {
            currentHealth += healamount;
            healthBar.SetHealth(currentHealth);
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
            death.Play();
            Destroy(shattered, 5.0f);
            
            Debug.Log("Player Is Dead");
        }
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    //if (other.tag == "Enemy")
    //    //{

    //    //    //Enemy enemy = other.transform.GetComponent<Enemy>();
    //    //    //if (enemy != null)
    //    //    //{
    //    //    //    enemy.TakeDamage(damage);
    //    //    //}

    //    //    ShootingEnemy enemyShoot = other.transform.GetComponent<ShootingEnemy>();
    //    //    if (enemyShoot != null)
    //    //    {
    //    //        enemyShoot.TakeDamage(damage);
    //    //    }

           


    //    //}

    //    if (other.tag == "Door" && !hasDoorBeenTriggered)
    //    {
    //        // Stores a cached reference to the door that we are interacting with
    //        doorInteractingWith = other.GetComponent<DoorController>();

    //        // Sets a bool so that we know that the agent is already interacting with a door
    //        hasDoorBeenTriggered = true;

    //        // Takes user input control away
    //        hasControl = false;





    //        // Gets the length of the door open animation so we know how long to wait
    //        doorOpenDelay = doorInteractingWith.animationDuration;


    //        // Starts the coroutine that will carry out the sequence of waiting and opening the door
    //        StartCoroutine(DelayCoroutine());
    //    }
    //}

    //private IEnumerator DelayCoroutine()
    //{

       

    //    // Play the door open animation
    //    doorInteractingWith.OpenDoor();

    //    // Wait for the door open animation to complete
    //    yield return new WaitForSeconds(doorOpenDelay);

       

    //    doorOpenDelay = 0;
    //    hasControl = true;
       
      
    //}


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

