using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class OptionsMenuController : MonoBehaviour
{
    public CharacterController controller;
    public bool initialized = false;
    public bool CheatsOn = false;
    public Slider mouseSensitivitySlider;
    public CinemachineFreeLook cam;
    public Toggle CheatToggle;
    public Toggle InvincibleToggle;

    void Start()
    {
        CheatsOn = false;
        if (PlayerPrefs.HasKey("Sensitivity") && PlayerPrefs.HasKey("SensitivityY"))
        {
            mouseSensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");
            cam.m_XAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Sensitivity");
            cam.m_YAxis.m_MaxSpeed = PlayerPrefs.GetFloat("SensitivityY");
        }
        initialized = true;
    }

    /// <summary>
    /// Nustato sensitivity pagal slider'io reiksme
    /// </summary>
    /// <param name="val">Sensitivity value</param>
    public void SetMouseSensitivity(float val)
    {
        if (!initialized) return;
        if (!Application.isPlaying) return;
        PlayerPrefs.SetFloat("Sensitivity", val);
        PlayerPrefs.SetFloat("SensitivityY", (val / 100));
        Debug.Log("Set sensitivity to " + val);
        cam.m_XAxis.m_MaxSpeed = val;
        cam.m_YAxis.m_MaxSpeed = (val / 100);
    }

    public void ChangeCheatState()
    {
        if (!initialized) return;
        if (!Application.isPlaying) return;
        if (CheatToggle.isOn && InvincibleToggle.isOn)
        {
            CheatsOn = true;
            Debug.Log("Turned on rage mode lmao");
        }
    }
}