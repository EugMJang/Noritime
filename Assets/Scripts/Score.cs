using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int redScore;
    public static int blueScore;
    // Start is called before the first frame update
    void Start()
    {
        redScore = 0;
        blueScore = 0;
        GameObject.Find("RedScore").GetComponent<Text>().text = "Red: "+redScore;
        GameObject.Find("BlueScore").GetComponent<Text>().text = "Blue: "+blueScore;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("RedScore").GetComponent<Text>().text = "Red: "+redScore;
        GameObject.Find("BlueScore").GetComponent<Text>().text = "Blue: "+blueScore;
    }
}
