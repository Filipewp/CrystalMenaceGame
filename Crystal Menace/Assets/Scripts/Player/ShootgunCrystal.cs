using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootgunCrystal : MonoBehaviour
{
    public GameObject Shootgun1;
    public GameObject Shootgun2;
    public GameObject Shootgun3;
    public GameObject playerShootgun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Shootgun1.GetComponent<WeaponTransform>().ShotGun2 = true;
            Shootgun2.GetComponent<WeaponTransform>().ShotGun2 = true;
            Shootgun3.GetComponent<WeaponTransform>().ShotGun2 = true;
            playerShootgun.GetComponent<Player>().Gun2 = true;
        }
    }
}
