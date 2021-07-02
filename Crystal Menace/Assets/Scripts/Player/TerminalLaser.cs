using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalLaser : MonoBehaviour
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
    void DisableTerminal()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<LasersInteraction>().enabled = false;
        Laser.Stop();
        StartCoroutine(TurnOFF());
    }

    IEnumerator TurnOFF()
    {

        yield return new WaitForSeconds(20f);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<LasersInteraction>().enabled = true;
        Laser.Play();

    }
}
