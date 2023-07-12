using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RetryUI_Screen : UI_Screen
{
    #region Variables
    public UnityEvent onRetry = new UnityEvent();
    #endregion

    #region Helper Methods
    public override void StartScreen()
    {
        base.StartScreen();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // Check for space bar input
    //     if ((PlayerMovement.Instance.dead) && !(GameHandler.Instance.inactive))
    //     {
    //         onRetry.Invoke();
    //         Debug.Log("Invoked retry screen");
    //         PlayerMovement.Instance.ResetPlayer();
    //         Debug.Log("Player reset");
    //     }
    // }

    public void RetryGame()
    {
        onRetry.Invoke();
        Debug.Log("Invoked retry screen");
        GameHandler.Instance.RestartGame();
        Debug.Log("Player reset");
    }
    #endregion
}
