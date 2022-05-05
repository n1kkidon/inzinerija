using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
    public bool initialized = false;
    public Slider mouseSensitivitySlider;

    void Start()
    {
        if (PlayerPrefs.HasKey("Sensitivity")) 
        {
            mouseSensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");         
        }
        initialized = true;
    }

    public void SetMouseSensitivity(float val)
    {
        if (!initialized) return;
        if (!Application.isPlaying) return;
        PlayerPrefs.SetFloat("Sensitivity", val);
        Debug.Log("Set sensitivity to " + val);
    }
}
