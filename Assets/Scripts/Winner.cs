using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
    private static GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Restart");
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.redScore == 4) {
            GameObject.Find("Win").GetComponent<Text>().text = "Red Wins";
            button.SetActive(true);
        } else if (Score.blueScore == 4) {
            GameObject.Find("Win").GetComponent<Text>().text = "Blue Wins";
            button.SetActive(true);
        }
       
    }
}
