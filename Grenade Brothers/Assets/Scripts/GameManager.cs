using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // The ball
    public GameObject ball;

    // Player Objects
    public GameObject player1;
    public GameObject player1Goal;
    public GameObject player2;
    public GameObject player2Goal;
    
    // TextMeshPro Objects
    public GameObject Player1Text;
    public GameObject Player2Text;
    public GameObject GameMsg;
    public GameObject CountDownMsg;
    public GameObject endCanvas;

    // Scores
    private int Player1Score = 0;
    private int Player2Score = 0;
    
    public void Player1Scored() {
        Player1Score++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        ball.GetComponent<Ball>().ResetPosition();
        StartCoroutine(Countdown(3));
    }

    public void Player2Scored() {
        Player2Score++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        ball.GetComponent<Ball>().ResetPosition();
        StartCoroutine(Countdown(3));
    }
    
    void Start() {
        if (Player1Score != 7 || Player2Score != 7) {
            endCanvas.gameObject.SetActive(false);
        }
        Time.timeScale = 1.0f;
        ball.GetComponent<Ball>().ResetPosition();
        StartCoroutine(Countdown(3));
    }

    void Update() {
        if (Player1Score == 7) {
            GameMsg.GetComponent<TextMeshProUGUI>().text = "Player 1 Wins!";
            Time.timeScale = 0.0f;
            endCanvas.gameObject.SetActive(true);
        } else if (Player2Score == 7) {
            GameMsg.GetComponent<TextMeshProUGUI>().text = "Player 2 Wins!";
            Time.timeScale = 0.0f;
            endCanvas.gameObject.SetActive(true);
        }
    }

    // Do a 3-2-1 Countdown and then run the game
    IEnumerator Countdown(int secs) {
        int count = secs;

        while (count > 0) {
            CountDownMsg.GetComponent<TextMeshProUGUI>().text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        CountDownMsg.GetComponent<TextMeshProUGUI>().text = "GO!";
        ball.GetComponent<Ball>().Launch();

        yield return new WaitForSeconds(1);
        CountDownMsg.GetComponent<TextMeshProUGUI>().text = "";
    }
}