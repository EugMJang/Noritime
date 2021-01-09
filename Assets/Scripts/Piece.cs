﻿using System.Collections;
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

    private int currIndex = -1;
    private int currentPos = -1;
    public void move() {
        if (!isFinished && currentPos != position) {
            if (position < currentPos) {
                if (currIndex == 0) {
                    if (path == 1) {
                        path = 0;
                        currIndex = 5;
                    } else if (path == 2) {
                        path = 1;
                        currIndex = 8;
                    } else if (path == 0) {
                        position = 19;
                        currentPos = 20;
                        currIndex = 20;
                    } else {
                        path = 0;
                        currIndex = 10;
                    }
                }

                transform.position = Vector2.MoveTowards(transform.position, currentPath()[currIndex - 1].position,
                moveSpeed * Time.deltaTime);

                if (transform.position == currentPath()[currIndex - 1].position) {
                    currentPos--;
                    currIndex--;
                }
            } else {
                if (currIndex == currentPath().Length - 1) {
                    if (path == 1) {
                        position += 4;
                        currentPos += 4;
                        path = 0;
                        currIndex = 13;
                    } else {
                        isFinished = true;
                        Debug.Log("Finished!");
                        return;
                    }
                }

                transform.position = Vector2.MoveTowards(transform.position, currentPath()[currIndex + 1].position,
                moveSpeed * Time.deltaTime);

                if (transform.position == currentPath()[currIndex + 1].position) {
                    currentPos++;
                    currIndex++;
                }
            }
        } else {
            if (position == 4 && path == 0) {
                path = 1;
                currIndex = -1;
            } else if (position == 7 && path == 1) {
                path = 2;
                currIndex = -1;
            } else if (position == 9 && path == 0) {
                path = 3;
                currIndex = -1;
            }
        }
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "BluePieces" && other.tag == "BluePieces") {
            Debug.Log("hit detected");
            Destroy(other.gameObject);
        }
        if (gameObject.tag == "RedPieces" && other.tag == "RedPieces") {
            Debug.Log("hit detected");
            Destroy(other.gameObject);
        }
        if (gameObject.tag == "RedPieces" && other.tag == "BluePieces") {
            Debug.Log("hit detected");
            Destroy(other.gameObject);
        }
        if (gameObject.tag == "BluePieces" && other.tag == "RedPieces") {
            Debug.Log("hit detected");
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
}
