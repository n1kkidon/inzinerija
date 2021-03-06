using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }
    public void StartLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("You are quitting the game");
        Application.Quit();
    }
}
