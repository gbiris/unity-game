using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwitch : MonoBehaviour
{
    public GameObject Main;
    public GameObject Start;
    //public GameObject Settings;
    public GameObject Dead;
    public GameObject Score;

    public static MenuSwitch Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public void MainUI()
    {
        Main.SetActive(true);
        Start.SetActive(false);
        // Settings.SetActive(true);
        Dead.SetActive(false);
        Score.SetActive(false);
    } 

    public void StartUI()
    {
        Main.SetActive(false);
        Start.SetActive(true);
        // Settings.SetActive(true);
        Dead.SetActive(false);
        Score.SetActive(false);
    } 

    public void SettingsUI()
    {
        Main.SetActive(false);
        Start.SetActive(false);
        // Settings.SetActive(true);
        Dead.SetActive(false);
        Score.SetActive(false);
    }

    public void DeadUI()
    {
        Main.SetActive(false);
        Start.SetActive(false);
        // Settings.SetActive(false);
        Dead.SetActive(true);
        Score.SetActive(false);
    }

    public void PlayUI()
    {
        Main.SetActive(false);
        Start.SetActive(false);
        // Settings.SetActive(false);
        Dead.SetActive(false);
        Score.SetActive(true);
    }
}
