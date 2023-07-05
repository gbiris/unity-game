using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ParticleSystem ps;
    private ParticleSystem.EmissionModule emission;
    private ParticleSystem.EmissionModule flamesEmission;
    public ParticleSystem flames;

    public float gravity;
    public float maxSpeed; 
    private Rigidbody2D rb;
    private Vector2 startPos;
    
    private bool dead;

    public static PlayerMovement Instance { get; set; }

    private void OnEnable() 
    {
        Instance = this;
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        flamesEmission = flames.emission;      
    }

    // Update is called once per frame
    void Update()
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
    
    public Vector2 GetVel()
	{
		return rb.velocity;
	}
}
