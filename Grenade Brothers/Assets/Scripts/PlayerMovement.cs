using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rb;
    public float jumpVelocity = 5f;
    public float groundLevel = 0.5894029f;

    private bool isJumping = false;
    private float movement;

    void Update() {
        if (isPlayer1) {
            movement = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && !isJumping) { 
                rb.velocity = Vector2.up * jumpVelocity;
                isJumping = true;
            }

        } else { // Is Player 2
            movement = Input.GetAxisRaw("Horizontal2"); 

            if (Input.GetButtonDown("Jump2") && !isJumping) { 
                rb.velocity = Vector2.up * jumpVelocity;
                isJumping = true;
            }
        }

        // Check if the player was pushed below the ground
        if (rb.velocity.y < 0 && rb.position.y == groundLevel) {
            isJumping = false;
        }

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D (Collision2D col) {
         if (col.gameObject.tag == "ground") {
             isJumping = false;
         }
     }
}
