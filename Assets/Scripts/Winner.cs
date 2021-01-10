using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Winner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Score.blueScore);
        if (Score.redScore == 4) {
            GameObject.Find("Win").SetActive(true);
            GameObject.Find("Win").GetComponent<Text>().text = "Red Wins";
        } else if (Score.blueScore == 4) {
            GameObject.Find("Win").SetActive(true);
            GameObject.Find("Win").GetComponent<Text>().text = "Blue Wins";
        }
       
    }
}
