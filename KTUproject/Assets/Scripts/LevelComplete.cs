using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelComplete : MonoBehaviour
{
    public void LoadNextLevel()
    {
        PlayerPrefs.SetString("Current_Level", (SceneManager.GetActiveScene().buildIndex + 1).ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
