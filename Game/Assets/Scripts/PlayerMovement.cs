using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float gravity;
    public float maxSpeed; 
    private Rigidbody2D rb;
    private Vector2 startPos;

    private bool dead;

 
    private void OnEnable() 
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb.velocity;
        float ang = Mathf.Atan2(vel.y, x: 10) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(x:0, y:0, z:ang -90));

        //if (rb.velocity.magnitude > maxSpeed) {
        //    rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);  
        //}

        if (Input.GetKey(KeyCode.Space)){
            rb.AddForce(Vector2.up * 1200f * gravity * Time.deltaTime);
        }
    }
}