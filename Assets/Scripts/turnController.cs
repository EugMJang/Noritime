using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnController : MonoBehaviour
{
    public static GameObject currentPlayer;
   void Start()
    {
        currentPlayer = GameObject.Find("BluePlayer");
    }

    public static void switchTurns() {
        if (currentPlayer.GetComponent<Player>().selectedPiece != null) {
            currentPlayer.GetComponent<Player>().selectedPiece.GetComponent<Piece>().highlight(false);
            currentPlayer.GetComponent<Player>().selectedPiece = null;
        }
        currentPlayer.GetComponent<Player>().numMoves = 1;
        currentPlayer.GetComponent<Player>().canRoll = true;
        if (currentPlayer == GameObject.Find("RedPlayer")) {
            currentPlayer = GameObject.Find("BluePlayer");
        } else {
            currentPlayer = GameObject.Find("RedPlayer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPlayer == GameObject.Find("BluePlayer")) {
            gameObject.GetComponent<Text>().text = "Blue's turn";
        } else {
            gameObject.GetComponent<Text>().text = "Red's turn";
        }
    }
}
