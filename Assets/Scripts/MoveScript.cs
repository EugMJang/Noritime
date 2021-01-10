using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    private static Text backone;
    private static Text one;
    private static Text two;
    private static Text three;
    private static Text four;
    private static Text five;
    private static Text descriptionText;

    public static void add(int side) {
        if (side == -1) {
            backone.text = "x" + (numTimes(-1) + 1);
        } else if (side == 1) {
            one.text = "x" + (numTimes(1) + 1);
        } else if (side == 2) {
            two.text = "x" + (numTimes(2) + 1);
        } else if (side == 3) {
            three.text = "x" + (numTimes(3) + 1);
        } else if (side == 4) {
            four.text = "x" + (numTimes(4) + 1);
        } else if (side == 5) {
            five.text = "x" + (numTimes(5) + 1);
        }
    }

    public static int moveNum = 0;
    public void clicked(int side) {
        if (turnController.currentPlayer.GetComponent<Player>().selectedPiece != null) {
            Piece piece = turnController.currentPlayer.GetComponent<Player>().selectedPiece.GetComponent<Piece>();
            if (side == -1 && numTimes(-1) > 0) {
                if (piece.position != -1) {
                    backone.text = "x" + (numTimes(-1) - 1);
                    moveNum = -1;
                }
            } else if (side == 1 && numTimes(1) > 0) {
                one.text = "x" + (numTimes(1) - 1);
                moveNum = 1;
            } else if (side == 2 && numTimes(2) > 0) {
                two.text = "x" + (numTimes(2) - 1);
                moveNum = 2;
            } else if (side == 3 && numTimes(3) > 0) {
                three.text = "x" + (numTimes(3) - 1);
                moveNum = 3;
            } else if (side == 4 && numTimes(4) > 0) {
                four.text = "x" + (numTimes(4) - 1);
                moveNum = 4;
            } else if (side == 5 && numTimes(5) > 0) {
                five.text = "x" + (numTimes(5) - 1);
                moveNum = 5;
            }
            
            if (moveNum != 0 || piece == null) {
                piece.position = piece.position + moveNum;
                piece.doneMoving = false;
                descriptionText.text = $"You moved {moveNum} spaces!";
            }
        }
    }

    public static int numTimes(int side) {
        if (side == -1) {
            return Int32.Parse(backone.text.Split('x')[1]);
        } else if (side == 1) {
            return Int32.Parse(one.text.Split('x')[1]);
        } else if (side == 2) {
            return Int32.Parse(two.text.Split('x')[1]);
        } else if (side == 3) {
            return Int32.Parse(three.text.Split('x')[1]);
        } else if (side == 4) {
            return Int32.Parse(four.text.Split('x')[1]);
        } else if (side == 5) {
            return Int32.Parse(five.text.Split('x')[1]);
        } else {
            throw new System.ArgumentException("Invalid number");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        backone = GameObject.Find("-1 times").GetComponent<Text>();
        one = GameObject.Find("1 times").GetComponent<Text>();
        two = GameObject.Find("2 times").GetComponent<Text>();
        three = GameObject.Find("3 times").GetComponent<Text>();
        four = GameObject.Find("4 times").GetComponent<Text>();
        five = GameObject.Find("5 times").GetComponent<Text>();
        descriptionText = GameObject.Find("DescriptionText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
