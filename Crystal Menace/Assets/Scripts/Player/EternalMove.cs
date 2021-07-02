using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EternalMove : MonoBehaviour
{
    public MeshRenderer mr;
    public float speed;
    public AudioClip dialoguesSymb;
    public int Scene;

    public AudioSource audSource;

    float timer = 1.0f;
    float timer2 = 21.0f;
    bool alreadyPlayed = false;


    void Start()
    {
        audSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        mr.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
        timer -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        if (audSource.isPlaying == false && timer < 0 && alreadyPlayed == false)
        {
            gameObject.GetComponent<AudioSource>().clip = dialoguesSymb;
            gameObject.GetComponent<AudioSource>().Play();
            alreadyPlayed = true;
        }
        if (timer2 <= 0)
        {
            SceneChange();
        }

    }

    void SceneChange()
    {
        SceneManager.LoadScene(Scene);
    }

}
