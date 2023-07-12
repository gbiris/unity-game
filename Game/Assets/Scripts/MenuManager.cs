using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MenuManager
{
    public static bool IsInitialised { get; private set; }
    public static GameObject mainMenu, startMenu, endMenu;

    public static void Init()
    {
        GameObject canvas = GameObject.Find("Canvas");
        mainMenu = canvas.transform.Find("MainMenu").gameObject;
        startMenu = canvas.transform.Find("StartMenu").gameObject;
        endMenu = canvas.transform.Find("EndMenu").gameObject;
        //settingsMenu = canvas.transform.Find("SettingsMenu").gameObject;

        IsInitialised = true;
    }

    public static void OpenMenu(Menu menu, GameObject callingMenu)
    {
        if (!IsInitialised)
            Init();

        switch (menu)
        {
            case Menu.MAIN_MENU:
                mainMenu.SetActive(true);
                break;
            case Menu.START:
                startMenu.SetActive(true);
                break;
            case Menu.END:
                endMenu.SetActive(true);
                break;
        }

        callingMenu.SetActive(false);
    }
}
