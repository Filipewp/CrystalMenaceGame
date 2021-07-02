using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbCrystal : MonoBehaviour
{
    public GameObject Door;
    public GameObject player;
    public ParticleSystem Fog;

    // Start is called before the first frame update
    void Start()
    {
        Fog.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Activate()
    {
        player.GetComponent<Player>().mutation1 = true;
        player.GetComponent<CrystalBullet>().evolution1 = true;
        Fog.Play();
        Door.GetComponent<DoorController>().locked = false;
    }
}