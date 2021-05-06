using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CrystalBullet : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam;
    public GameObject bulletCrystal;
    public Transform shootPoint;
    public GameObject crystal;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) )
        {
            crystal.SetActive(true);
            StartCoroutine(GoCrystal());
          
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            Ray ray = fpsCam.ScreenPointToRay(Input.mousePosition);

            RaycastHit[] hits = Physics.RaycastAll(ray, range);

           
            
            

            for (int i = 0; i < hits.Length; i++)
            {
                 RaycastHit hitting = hits[i];
                Enemy enemy = hitting.transform.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(CalculateDamage(hitting.collider.gameObject));
                }
                ShootingEnemy enemyShoot = hitting.transform.GetComponent<ShootingEnemy>();

                if (enemyShoot != null)
                {
                    enemyShoot.TakeDamage(CalculateDamage(hitting.collider.gameObject));
                }

                OnHeadShoot headShoot = hitting.transform.GetComponent<OnHeadShoot>();

                if (headShoot != null)
                {
                    headShoot.Vanish(damage);
                }

            }
            


           
        }
        
    }
    IEnumerator GoCrystal()
    {
        yield return new WaitForSeconds(1f);
        crystal.SetActive(false);
        Instantiate(bulletCrystal, shootPoint.position, shootPoint.rotation);
        Shoot();
    }

    float CalculateDamage(GameObject go )
    {
        float dist = Vector3.Distance(transform.position, go.transform.position);

        float bulletDamage = damage - dist;

        return bulletDamage;

        //if(damage >= 0)
        //{
        //    Debug.Log(go.name + "Took: " + bulletDamage.ToString() + " Of Damage");
            
            
        //}
    }
}
