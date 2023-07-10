using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;

    public static UIManager Instance { get; set; }
    public int score { get; private set; }

    private void Awake()
    {
       Instance = this; 
    }

    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        if (PlayerMovement.Instance.dead)
		{
			return;
		}
        score++;
        scoreText.SetText(score.ToString());
    }
}
