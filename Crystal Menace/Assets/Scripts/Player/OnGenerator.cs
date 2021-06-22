using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGenerator : MonoBehaviour
{
    public AudioSource Gen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratorOn()
    {
        this.gameObject.GetComponent<Animator>().enabled = true;
        Gen.Play();
    }
}
