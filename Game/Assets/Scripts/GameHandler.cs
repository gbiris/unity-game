using UnityEngine;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    private PlayerMovement player;
    private Spawner spawner;
    private Rigidbody2D rb;
    //private Rigidbody2D rb;

    /* public Text scoreText;
    public GameObject playButton;
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
    }

    public void Play()
    {
        /* score = 0;
        scoreText.text = score.ToString(); */
        //player.gravity = 3;
        Time.timeScale = 1f;
        player.enabled = true;

    
        //playButton.SetActive(false);
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
        //player.gravity = 0;
        
        Time.timeScale = 0f;
        player.enabled = false;
       /*  GameObject[] Player = FindObjectOfType
        Rigid = Player[0].GetComponent<Rigidbody2D>();
        Rigid.gravityScale = 0; */
    }

/*     public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    } */

}