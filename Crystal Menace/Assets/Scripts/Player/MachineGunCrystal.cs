using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunCrystal : MonoBehaviour
{
    public GameObject Machinegun1;
    public GameObject Machinegun2;
    public GameObject Machinegun3;
    public GameObject playerMachinegun;
    public GameObject player;

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
            Machinegun1.GetComponent<WeaponTransform>().MachineGun3 = true;
            Machinegun2.GetComponent<WeaponTransform>().MachineGun3 = true;
            Machinegun3.GetComponent<WeaponTransform>().MachineGun3 = true;
            playerMachinegun.GetComponent<Player>().Gun3 = true;
            player.GetComponent<Player>().mutation2 = true;
            player.GetComponent<CrystalSmash>().evolution2 = true;
        }
    }
}
