using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [HideInInspector]
    public int position;
    public float moveSpeed;
    private int path;
    public bool canMove;

    public bool isFinished;

    public Transform[] path0;
    public Transform[] path1;
    public Transform[] path2;
    public Transform[] path3;
    
    private Vector2 starting_position;
    // Start is called before the first frame update
    void Start()
    {
        starting_position = transform.position;
        position = -1;
        path = 0;
        canMove = false;
    }

    public void highlight(bool doHighlight) {
        if (doHighlight) {
            GetComponent<Renderer>().material.color = new Color(0.547f, 0f, 0.547f, 1f);
        } else {
            GetComponent<Renderer>().material.color = new Color(1f, 1f, 1.0f, 1.0f);
        }
    }

    public void move() {
        
    }
    public Transform[] currentPath() {
        if (path == 0) {
            return path0;
        } else if (path == 1) {
            return path1;
        } else if (path == 2) {
            return path2;
        } else if (path == 3) {
            return path3;
        } else {
            throw new ArgumentException("Not a valid path");
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
