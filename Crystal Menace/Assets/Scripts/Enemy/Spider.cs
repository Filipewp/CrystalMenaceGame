using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spider : MonoBehaviour
{
    public float health = 50f;
    Transform target;
    NavMeshAgent agent;
    public bool canAttack = true;
    [SerializeField]
    float chaseDistance = 20f;
    [SerializeField]
    float turnSpeed = 5;
    public float damage = 35f;
    [SerializeField]
    float attackTime = 2f;
    public Animator animator;
    public GameObject SpiderShattered;
    public Transform spawnDead;
    public GameObject partToVanish;
    public AudioSource explosionSound;

    public GameObject bomb;
    public float power = 10.0f;
    public float radius = 5.0f;
    public float upForce = 1.0f;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
       
        if (distance > chaseDistance && isDead == false)
        {
            ChasePlayer();

        }
        else if (canAttack && !Player.singleton.isDead == true && isDead == false)
        {
            AttackPlayer();
        }
        else if (!canAttack && !Player.singleton.isDead == true )
        {
            DisableEnemy();
        }

    }
    void ChasePlayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.SetDestination(target.position);
    }

    void AttackPlayer()
    {
        agent.updateRotation = false;
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        agent.updatePosition = false;
        StartCoroutine(AttackTime());
        animator.SetTrigger("Attack");
    }

    void DisableEnemy()
    {
        canAttack = false;
    }
    IEnumerator AttackTime()
    {
        canAttack = false;
        yield return new WaitForSeconds(1f);
        Player.singleton.DamagePlayer(damage);
        yield return new WaitForSeconds(attackTime);
        canAttack = true;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f && isDead==false)
        {
            isDead = true;
            explosionSound.Play();
            Die();
        }

    }
    void Die()
    {
        GameObject clone = GameObject.Instantiate(SpiderShattered, spawnDead.transform.position, spawnDead.transform.rotation);
        
        Detonate();
        Destroy(partToVanish);
        agent.enabled = false;
        animator.enabled = false;
        Destroy(gameObject, 5);
        Destroy(clone, 5);
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
