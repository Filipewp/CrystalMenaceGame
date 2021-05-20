using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float health = 50f;
    Transform target;
    NavMeshAgent agent;
    bool isDead = false;
    bool isDead1 = false;
    bool isDead2 = false;
    bool isDead3 = false;
    bool isDead4 = false;
    bool isDead5 = false;
    bool totalDeath = false;
    public bool canAttack = true;
    [SerializeField]
    float chaseDistance = 20f;
    [SerializeField]
    float turnSpeed = 5;
    public float damage = 35f;
    [SerializeField]
    float attackTime = 2f;
    public Animator animator;

    public GameObject headShootDead;
    public GameObject torsoShootDead;
    public GameObject armLShootDead;
    public GameObject armRShootDead;
    public GameObject legLShootDead;
    public GameObject legRShootDead;
    private OnHeadShoot offPath;
    private OnHeadShoot offTorso;
    private OnHeadShoot offArmL;
    private OnHeadShoot offArmR;
    private OnHeadShoot offLegL;
    private OnHeadShoot offLegR;

   

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        offPath = headShootDead.GetComponent<OnHeadShoot>();
        offTorso = torsoShootDead.GetComponent<OnHeadShoot>();
        offArmL = armLShootDead.GetComponent<OnHeadShoot>();
        offArmR = armRShootDead.GetComponent<OnHeadShoot>();
        offLegL = legLShootDead.GetComponent<OnHeadShoot>();
        offLegR = legRShootDead.GetComponent<OnHeadShoot>();
       
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        isDead = offPath.deadHead;
        isDead1 = offTorso.deadHead;
        isDead2 = offArmL.deadHead;
        isDead3 = offArmR.deadHead;
        isDead4 = offLegL.deadHead;
        isDead5 = offLegR.deadHead;
        if (isDead==true && isDead2 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead == true && isDead3 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead == true && isDead4 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead == true && isDead5 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead1 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead2 == true && isDead3 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead2 == true && isDead4 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead2 == true && isDead5 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead3 == true && isDead4 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead3 == true && isDead5 == true)
        {
            totalDeath = true;
            Die();
        }
        if (isDead4 == true && isDead5 == true)
        {
            totalDeath = true;
            Die();
        }
       
        if (distance > chaseDistance && totalDeath == false)
        {
            ChasePlayer();
            
        }
        else if(canAttack && !Player.singleton.isDead==true && totalDeath == false)
        {
            AttackPlayer();
        }
        else if(!canAttack && !Player.singleton.isDead == true || totalDeath == true)
        {
            DisableEnemy();
        }
    }
    //public void TakeDamage(float amount)
    //{
    //    health -= amount;
    //    if(health <= 0f)
    //    {
    //        isDead = offPath.deadHead;
    //        Die();
    //    }
    //}

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
    void Die()
    {
        
        agent.enabled = false;
        animator.enabled = false;
        Destroy(gameObject, 5);
    }
}
