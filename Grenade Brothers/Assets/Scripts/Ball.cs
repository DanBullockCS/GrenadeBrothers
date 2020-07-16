using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed;
    public Rigidbody2D rb;

    void Start() {
        Launch(); // Launch the Ball at the beginning of the game
    }

    public void Launch() {
        float x = Random.Range(0, 2) == 0 ? -3 : 3;
        float y = Random.Range(0, 2) == 0 ? -3 : 3;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void ResetPosition() {
        rb.position = new Vector2(0.03f, 2.35f);
        rb.velocity = new Vector2(0.0f, 0.0f);
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            rb.AddForce(transform.up, ForceMode2D.Impulse);
        }
    }
}