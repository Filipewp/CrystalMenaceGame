using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{

    //    public float damage = 10f;
    //    public float range = 100f;
    //    public float fireRate = 15f;
    //    private float nextTimeToFire = 0f;


    //    public ParticleSystem muzzleFlash;

    //    public Camera fpsCam;

    //    void Update()
    //    {
    //        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
    //        {
    //            nextTimeToFire = Time.time + 1f / fireRate;
    //            Shoot();
    //        }
    //    }

    //   void Shoot()
    //    {
    //        muzzleFlash.Play();
    //        RaycastHit hit;
    //        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
    //        {
    //            Debug.Log(hit.transform.name);

    //            Enemy enemy = hit.transform.GetComponent<Enemy>();


    //            if (enemy != null)
    //            {
    //                enemy.TakeDamage(damage);

    //            }

    //            ShootingEnemy shootingenemy = hit.transform.GetComponent<ShootingEnemy>();

    //            if (shootingenemy != null)
    //            {
    //                shootingenemy.TakeDamage(damage);
    //            }

    //            OnHeadShoot headShoot = hit.transform.GetComponent<OnHeadShoot>();

    //            if (headShoot != null)
    //            {
    //                headShoot.Vanish(damage);
    //            }
    //        }
    //    }
    //}

    //Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    public AudioSource shootSound;
    public AudioSource reloadSound;
    [SerializeField]
    GameObject projectile = null;
    [SerializeField]
    Transform shootPoint;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //Graphics
    public ParticleSystem muzzleFlash; 
    public CameraShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;

    public Player speedAim;

    private void Awake()
    {
        
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();

        //SetText
        text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        { 
            speedAim.GetComponent<Player>().speed = 5;
        
            if (allowButtonHold)
            {
                shooting = Input.GetKey(KeyCode.Mouse0);
                if(bulletsLeft == 0 && !reloading) Reload();
            }
            else shooting = Input.GetKeyDown(KeyCode.Mouse0);
            if(bulletsLeft == 0 && !reloading) Reload();

        }
        else 
        {
            speedAim.GetComponent<Player>().speed = 15;
        }

       

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;
        shootSound.Play();
        muzzleFlash.Play();
        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Instantiate(projectile, shootPoint.position, shootPoint.rotation);
           

            //Enemy enemy = rayHit.transform.GetComponent<Enemy>();


            //if (enemy != null)
            //{
            //    enemy.TakeDamage(damage);

            //}

            ShootingEnemy shootingenemy = rayHit.transform.GetComponent<ShootingEnemy>();

            if (shootingenemy != null)
            {
                shootingenemy.TakeDamage(damage);
            }

            Spider spider = rayHit.transform.GetComponent<Spider>();

            if (spider != null)
            {
                spider.TakeDamage(damage);
            }

            OnHeadShoot headShoot = rayHit.transform.GetComponent<OnHeadShoot>();

            if (headShoot != null)
            {
                headShoot.Vanish(damage);
            }

           

        }

        //ShakeCamera
        StartCoroutine(camShake.Shake(camShakeDuration, camShakeMagnitude));
        

        //Graphics
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
       

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        reloadSound.Play();
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
