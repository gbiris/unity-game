using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private ParticleSystem.EmissionModule emission;

    private ParticleSystem.EmissionModule flamesEmission;
    private ParticleSystem.EmissionModule smokeEmission;

    public ParticleSystem smoke;
    public ParticleSystem flames;

    private float gravity;
    private Rigidbody2D rb;

    private Vector2 startPos;
    private Quaternion startRot;
    
    public bool dead;

    public static PlayerMovement Instance { get; set; }

    private void Awake() 
    {
        Instance = this;
        startPos = base.transform.position;
        startRot = base.transform.rotation;
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        flamesEmission = flames.emission;
        smokeEmission = smoke.emission;   
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            flamesEmission.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            flamesEmission.enabled = false;
        }
    }

    void FixedUpdate()
    {
        if (!dead)
		{
        Vector2 vel = rb.velocity;
        float ang = Mathf.Atan2(vel.y, x: 10) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(x:0, y:0, z:ang -90));

        if (Input.GetKey(KeyCode.Space))
        {
            flamesEmission.enabled = true;
            rb.AddForce(Vector2.up * 1200f * gravity * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            flamesEmission.enabled = false;
        }
        }
    }

    public Vector2 GetVel()
	{
		return rb.velocity;
	}

    private void Dead()
    {
        Debug.Log("Dead");
        dead = true;
        rb.AddForce(Vector2.right * 1000f);
        rb.AddTorque(400f);
        smokeEmission.enabled = false;
        flamesEmission.enabled = false;
        // AudioManager.Instance.Play("Dead");
        // deadUI.SetActive(value: true);
        // AudioManager.Instance.StopLoop("Fuel");
        // UIManager.Instance.UpdateDeadScreen(Game.Instance.GetScore());
        // Difficulty.Instance.ResetCamera();
        // Object.Instantiate(explosion, base.transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            Dead();
        } else if (other.gameObject.CompareTag("Scoring")) {
            GameHandler.Instance.IncreaseScore();
        }
    }

    public void Restart()
	{
		ResetPlayer();
		rb.gravityScale = gravity;
		dead = false;
		//deadUI.SetActive(value: false);
		//SelectChar();
		//Difficulty.Instance.NewGame();
	}

    public void ResetPlayer()
	{
		base.transform.position = startPos;
		base.transform.rotation = startRot;
		rb.velocity = Vector2.zero;
		smokeEmission.enabled = true;
		flamesEmission.enabled = true;
		// CameraMovement.Instance.Restart();
    }
}
