using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu3 : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject deathMenuUI;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        if (Player.singleton.isDead == true)
        {
            StartCoroutine(DeathMenuTimer());

        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }


    public void ReLoad()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
    void DeathMenu()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    IEnumerator DeathMenuTimer()
    {
        yield return new WaitForSeconds(2f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
