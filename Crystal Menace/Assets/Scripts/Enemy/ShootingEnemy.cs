using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject projectile = null;
    public float health = 50f;
    Transform target;
    NavMeshAgent agent;
    bool isDead = false;
    public bool canAttack = true;
    [SerializeField]
    float chaseDistance = 2f;
    public Animator animator;
    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    float turnSpeed = 5;

    float fireRate = 0.5f;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance > chaseDistance && !isDead)
        {
            ChasePlayer();

        }
        else if (canAttack && !Player.singleton.isDead && !isDead)
        {
            AttackPlayer();
        }
        else if (!canAttack && !Player.singleton.isDead)
        {
            DisableEnemy();
        }

      
    }

    void Shoot()
    {
        animator.SetTrigger("Attack");
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }
    void DisableEnemy()
    {
        canAttack = false;
    }

    void ChasePlayer()
    {
        agent.updateRotation = true;
        agent.updatePosition = true;
        agent.SetDestination(target.position);
    }

    void AttackPlayer()
    {
        fireRate -= Time.deltaTime;

        agent.updateRotation = false;
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        agent.updatePosition = false;
                
        if (fireRate <= 0)
        {
            fireRate = 0.6f;
            Shoot();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            isDead = true;
            Die();
        }

    }

    void Die()
    {
       

        animator.enabled = false;
        
        Destroy(gameObject, 10);
    }
}
