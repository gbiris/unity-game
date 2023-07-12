using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeadUI_Screen : UI_Screen
{
    #region Variables
    public UnityEvent onDead = new UnityEvent();
    #endregion

    #region Helper Methods
    public override void StartScreen()
    {
        base.StartScreen();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for space bar input
        if ((PlayerMovement.Instance.dead) && !(GameHandler.Instance.inactive))
        {
            onDead.Invoke();
            GameHandler.Instance.inactive = true;
        }
    }
    #endregion
}
