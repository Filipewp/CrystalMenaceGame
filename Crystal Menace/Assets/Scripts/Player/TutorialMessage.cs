using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
    public GameObject Tutorial;
    public GameObject boxC;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Tutorial.SetActive(true);
            StartCoroutine(timeToDisappear());

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            boxC.GetComponent<BoxCollider>().enabled = false;
        }
    }

    IEnumerator timeToDisappear()
    {
        yield return new WaitForSeconds(6f);
        Tutorial.SetActive(false);
    }
}
