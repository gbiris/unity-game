using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandler : MonoBehaviour
{
    private PlayerMovement player;
    private Spawner spawner;
    public bool inactive;
    public bool ingame;
    public TMP_Text scoreText;
    public int score { get; private set; }

     public static GameHandler Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        player = PlayerMovement.Instance;
        spawner = Spawner.Instance;

        spawner.enabled = false;
        inactive = true;
        ingame = false;
        PlayerMovement.Instance.setGravity();
    }

    public void InGame()
    {
        ingame = true;
    }

    public void StartGame()
    {
        player.enabled = true;
        spawner.enabled = true;
        inactive = false;
        PlayerMovement.Instance.setGravity();
    }

    public void RestartGame()
	{
        ingame = true;
        inactive = true;

        ResetScore();

        PlayerMovement.Instance.setGravity();
		PlayerMovement.Instance.ResetPlayer();
        PlayerMovement.Instance.dead = false;

        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < obstacles.Length; i++) 
        {
            Destroy(obstacles[i].gameObject);
        }

        spawner.enabled = false;
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

    public void ResetScore()
    {
        score = 0;
        scoreText.SetText(score.ToString());
    }
}