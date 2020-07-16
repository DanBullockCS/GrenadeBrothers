using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {
    public bool isPlayer1Goal;

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "ball") {
            if (isPlayer1Goal) {
                GameObject.Find("EventSystem").GetComponent<GameManager>().Player2Scored(); // Player 2 Has Scored
            } else {
                GameObject.Find("EventSystem").GetComponent<GameManager>().Player1Scored(); // Player 1 Has Scored
            }
        }
    }

}