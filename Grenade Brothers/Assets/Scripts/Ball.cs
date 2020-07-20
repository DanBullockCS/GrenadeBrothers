using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public float speed;
    public Rigidbody2D rb;

    AudioSource aSource;
    public AudioClip[] audioClips;

    // Sound Related Functions
    void Start() {
        aSource = gameObject.GetComponent<AudioSource>();
    }
    void PlayRandom() {
        // Play a Random paper ball audio clip
        if (PlayerPrefs.GetInt("MuteSound") == 0) {
            aSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            aSource.Play();
        }
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
        PlayRandom();

        if (col.gameObject.tag == "Player") {

            // Make sure horizontal velocity doesn't get to big, also reset vertical velocity when player hits ball
            if (rb.velocity.x > 10.0f) {
                rb.velocity = new Vector2(5.0f, 0.0f);
            } else if (rb.velocity.y > 10.0f) {
                rb.velocity = new Vector2(rb.velocity.x, 0.5f);
            } else {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
            }

            // Add the player force
            rb.AddForce(transform.right, ForceMode2D.Impulse); // X-Axis Force
            rb.AddForce(transform.up*10, ForceMode2D.Impulse); // Y-Axis Force
        }
    }
}