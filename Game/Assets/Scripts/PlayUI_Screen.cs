// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;

// public class PlayUI_Screen : UI_Screen
// {
//     # region Variables
//     public float m_ScreenTime = 2f;
//     public UnityEvent onTimeCompleted = new UnityEvent();
//     # endregion
//     private float startTime;

//     # region Helper Methods

//     public override void StartScreen()
//     {
//         base.StartScreen();

//         startTime = Time.time;
//         StartCoroutine(WaitForTime());
//     }
//     # endregion
    
//     IEnumerator WaitForTime()
//     {
//         yield return new WaitForSeconds(m_ScreenTime);

//         if(onTimeCompleted != null)
//         {
//             onTimeCompleted.Invoke();
//         }
//     }

// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayUI_Screen : UI_Screen
{
    #region Variables
    public UnityEvent onSpaceBarPressed = new UnityEvent();
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
        if ((Input.GetKeyDown(KeyCode.Space)) && (GameHandler.Instance.inactive) && (GameHandler.Instance.ingame))
        {
            onSpaceBarPressed.Invoke();
            GameHandler.Instance.StartGame();
        }
    }
    #endregion
}
