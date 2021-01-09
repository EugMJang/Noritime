using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnController : MonoBehaviour
{
    public static GameObject currentPlayer;
   void Start()
    {
        currentPlayer = GameObject.Find("RedPlayer");
    }

    public static void switchTurns() {
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
