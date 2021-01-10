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
    public int numPieces;

    public Transform[] path0;
    public Transform[] path1;
    public Transform[] path2;
    public Transform[] path3;
    
    private Vector3 starting_position;

    private Sprite[] redSprites;
    private Sprite[] blueSprites;
    // Start is called before the first frame update
    void Start()
    {
        starting_position = transform.position;
        position = -1;
        path = 0;
        canMove = false;
        numPieces = 1;

        redSprites = Resources.LoadAll<Sprite>("RedSprites/");
        blueSprites = Resources.LoadAll<Sprite>("BlueSprites/");
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
    [HideInInspector]
    public bool doneMoving = false;
    public void move() {
        if (currentPos != position) {
            if (position == -1) {
                transform.position = Vector2.MoveTowards(transform.position, starting_position,
                moveSpeed * Time.deltaTime);
                if (transform.position == starting_position) {
                    currentPos = -1;
                    currIndex = -1;
                    path = 0;
                    doneMoving = false;
                    return;
                }
            } else if (position < currentPos) {
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
                        Destroy(gameObject);
                        Debug.Log("Finished!");
                        turnController.currentPlayer.GetComponent<Player>().numMoves -= 1;
                        if (turnController.currentPlayer.GetComponent<Player>().numMoves == 0) {
                            turnController.switchTurns();
                        }
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
        } else if (position != -1) {
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
            turnController.currentPlayer.GetComponent<Player>().numMoves -= 1;
            if (turnController.currentPlayer.GetComponent<Player>().numMoves == 0) {
                turnController.switchTurns();
            }
            doneMoving = true;
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
        if (gameObject == turnController.currentPlayer.GetComponent<Player>().selectedPiece) {
            if (other.gameObject.GetComponent<Piece>().position != -1) {
                if (gameObject.tag == other.tag) {
                    if (position == other.gameObject.GetComponent<Piece>().position) {
                        Debug.Log("hit detected");
                        other.transform.SetParent(transform);
                        if (other.gameObject.GetComponent<Piece>().numPieces > 1) {
                            for (int i = 0; i < other.transform.childCount;) {
                                other.transform.GetChild(i).SetParent(transform);
                            }
                        }
                        other.gameObject.SetActive(false);
                        numPieces += other.gameObject.GetComponent<Piece>().numPieces;
                    }
                }
                else {
                    if (position == other.gameObject.GetComponent<Piece>().position) {
                        Debug.Log("hit detected");
                        for (int i = 0; i < other.transform.childCount; i++) {
                            Transform child = other.transform.GetChild(i);
                            child.gameObject.GetComponent<Piece>().position = -1;
                            child.gameObject.GetComponent<Piece>().doneMoving = false;
                            child.gameObject.GetComponent<Piece>().numPieces = 1;
                            child.gameObject.SetActive(true);
                            if (child.tag == "RedPieces") {
                                child.SetParent(GameObject.Find("RedPlayer").transform);
                            } else {
                                child.SetParent(GameObject.Find("BluePlayer").transform);
                            }
                            i--;
                        }
                        other.gameObject.GetComponent<Piece>().numPieces = 1;
                        other.gameObject.GetComponent<Piece>().position = -1;
                        other.gameObject.GetComponent<Piece>().doneMoving = false;
                        if (MoveScript.moveNum != 4 && MoveScript.moveNum != 5) {
                            turnController.currentPlayer.GetComponent<Player>().numMoves += 1;
                            turnController.currentPlayer.GetComponent<Player>().canRoll = true;
                        }
                    }
                }
            }
        }
    }

    private void updateSprites() {
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        if (gameObject == turnController.currentPlayer.GetComponent<Player>().selectedPiece) {
        }
        if (gameObject.tag == "RedPieces") {
            rend.sprite = redSprites[numPieces - 1];
        } else {
            rend.sprite = blueSprites[numPieces - 1];
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Adjust collider to be within bounds of sprite
        var sprite = FindObjectOfType<SpriteRenderer>();
        var collider = FindObjectOfType<BoxCollider2D>();

        collider.offset = new Vector2(0, 0);
        collider.size = new Vector3(sprite.bounds.size.x / transform.lossyScale.x,
                                     sprite.bounds.size.y / transform.lossyScale.y,
                                     sprite.bounds.size.z / transform.lossyScale.z);

        if (!doneMoving){
            move();
        }
        
        updateSprites();
    }
}