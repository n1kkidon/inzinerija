using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;


    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if (optionsMenuUI.active == false)
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
                //SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart() 
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        GameIsPaused = false;
        SceneManager.LoadScene("Menu");
    }
    public void LoadOptionsMenu()
    {
        optionsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
    }
    public void LoadPauseMenu()
    {
        optionsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

}
