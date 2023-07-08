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

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<PlayerMovement>();
        spawner = FindObjectOfType<Spawner>();

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
        //player.gravity = 3;
        Time.timeScale = 1f;
        player.enabled = true;

        scoreText.enabled = true;
        playText.SetActive(false);
        gameOver.SetActive(false);

        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < obstacles.Length; i++) {
            Destroy(obstacles[i].gameObject);
        }
    }

    public void GameOver()
    {
        //playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }

    public void Pause()
    {   
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        //scoreText = score.SetText;
        scoreText.SetText(score.ToString());
    }

}