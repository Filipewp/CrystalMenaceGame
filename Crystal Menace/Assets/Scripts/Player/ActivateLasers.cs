using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLasers : MonoBehaviour
{
    public ParticleSystem Laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activate()
    {
        Laser.Play();
        StartCoroutine(TurnOFF());
    }

    IEnumerator TurnOFF()
    {

        yield return new WaitForSeconds(5f);
        Laser.Stop();
        
    }
}
