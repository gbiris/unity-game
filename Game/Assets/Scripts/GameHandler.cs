using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private PlayerMovement player;
    private Spawner spawner;
    private Rigidbody2D rb;
    //private Rigidbody2D rb;

    
    public GameObject playText;
    /* public Text scoreText;
    public GameObject gameOver;
    public int score { get; private set; } */

    private void Awake()
    {
        Application.targetFrameRate = 60;
        player = FindObjectOfType<PlayerMovement>();
        rb = player.GetComponent<Rigidbody2D>();
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
        /* score = 0;
        scoreText.text = score.ToString(); */
        //player.gravity = 3;
        Time.timeScale = 1f;
        player.enabled = true;

    
        playText.SetActive(false);
        //gameOver.SetActive(false);
    }

    // public void GameOver()
    // {
    //     //playButton.SetActive(true);
    //     //gameOver.SetActive(true);

    //     Pause();
    // }

    public void Pause()
    {   
        Time.timeScale = 0f;
        player.enabled = false;
    }

/*     public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    } */

}