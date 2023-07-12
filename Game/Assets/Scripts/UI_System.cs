using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UI_System : MonoBehaviour
{
    # region Variables
    [Header("Main Properties")]
    public UI_Screen m_StartScreen;

    [Header("System Events")]
    public UnityEvent onSwitchedScreen = new UnityEvent();

    [Header("Fader Properties")]
    public Image m_Fader;
    public float m_FadeInDuration = 1f;
    public float m_FadeOutDuration = 1f;

    private Component[] screens = new Component[0];

    public UI_Screen previousScreen;
    public UI_Screen PreviousScreen { get { return previousScreen; } }

    public UI_Screen currentScreen;
    public UI_Screen CurrentScreen { get { return currentScreen; } }

    public static UI_System Instance {get; private set;}

    # endregion

    # region Main Methods
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        // true to include inactive screens
        screens = GetComponentsInChildren<UI_Screen>(true);
        InitialiseScreens();

        if(m_StartScreen)
        {
            SwitchScreens(m_StartScreen);
            Debug.Log("Screen started!");
        }

        if(m_Fader)
        {
            m_Fader.gameObject.SetActive(true);
        }
        FadeIn();
    }
    # endregion

    # region Helper Methods

    public void SwitchScreens(UI_Screen aScreen)
    {
        if(aScreen)
        {
            if(currentScreen)
            {
                currentScreen.CloseScreen();
                previousScreen = currentScreen;
            }

            currentScreen = aScreen;
            currentScreen.gameObject.SetActive(true);
            currentScreen.StartScreen();

            if(onSwitchedScreen != null)
            {
                onSwitchedScreen.Invoke();
                Debug.Log(currentScreen);
            }
        }
    }

    public void FadeIn()
    {
        if(m_Fader)
        {
            m_Fader.CrossFadeAlpha(0f, m_FadeInDuration, false);
        }
    }

    public void FadeOut()
    {
        if(m_Fader)
        {
            m_Fader.CrossFadeAlpha(1f, m_FadeOutDuration, false);
        }
    }

    public void GoToPreviousScreen()
    {
        if(previousScreen)
        {
            SwitchScreens(previousScreen);
        }
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(WaitToLoadScene(sceneIndex));
    }

    IEnumerator WaitToLoadScene(int sceneIndex)
    {
        yield return null;
    }

    void InitialiseScreens()
    {
        foreach(var screen in screens)
        {
            screen.gameObject.SetActive(true);
        }
    }
    # endregion
}