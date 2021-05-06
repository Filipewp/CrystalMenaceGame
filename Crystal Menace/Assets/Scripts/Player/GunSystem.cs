using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    
    public Camera fpsCam;

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

   void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
           

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
               
            }

            ShootingEnemy shootingenemy = hit.transform.GetComponent<ShootingEnemy>();

            if (shootingenemy != null)
            {
                shootingenemy.TakeDamage(damage);
            }

            OnHeadShoot headShoot = hit.transform.GetComponent<OnHeadShoot>();

            if (headShoot != null)
            {
                headShoot.Vanish(damage);
            }
        }
    }
}
