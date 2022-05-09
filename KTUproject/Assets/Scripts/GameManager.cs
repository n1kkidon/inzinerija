using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject CompleteLevelUi;
    //public Text finishedIn;

    public void CompleteLevel()
    {
        TimeController.instance.EndTimer();
        //string finishTime = TimeController.instance.GetTime();
        //finishedIn.text = "Finished in: "+finishTime;
        CompleteLevelUi.SetActive(true);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
