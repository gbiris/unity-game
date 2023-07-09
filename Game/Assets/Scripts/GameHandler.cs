using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameHandler : MonoBehaviour
{
    private PlayerMovement player;
    private Spawner spawner;
    private Rigidbody2D rb;

    public GameObject playText;
    public TMP_Text scoreText;
    public GameObject gameOver;

    public int score { get; private set; }
    public static GameHandler Instance { get; set; }

    private void Awake()
    {
        Instance = this;

        Application.targetFrameRate = 120;

        player = PlayerMovement.Instance;
        spawner = Spawner.Instance;

        scoreText.enabled = false;
        gameOver.SetActive(false);
        Pause();
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.Space)) && (Time.timeScale == 0f))
        {
            Play();
            Debug.Log("Play");
        }

        if ((Input.GetKey(KeyCode.Escape)) && (Time.timeScale == 1f))
        {
            Pause();
        }
    }

    public void Play()
    {
        score = 0;
        Time.timeScale = 1f;
        player.enabled = true;

        scoreText.enabled = true;
        playText.SetActive(false);
        gameOver.SetActive(false);

        // Figure out why I can't use Instace for this
        // Maybe because variable/file names too similiar?
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < obstacles.Length; i++) {
            Destroy(obstacles[i].gameObject);
        }
    }

    public void GameOver()
    {
        //playButton.SetActive(true);
        gameOver.SetActive(true);
    }

// public void RestartGame()
// 	{
// 		PlayerMovement.Instance.Restart();
// 		NewMap();
// 		points = 0;
// 		Time.timeScale = 1f;
// 		score.text = "0";
// 		r = 0f;
// 		r2 = 0f;
// 		watchAdBtn.SetActive(value: true);
// 		CameraMovement.Instance.SetStart();
// 	}

    public void Pause()
    {   
        Time.timeScale = 0f;
        player.enabled = false;
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