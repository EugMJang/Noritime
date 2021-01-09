using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectedPiece;
    // Start is called before the first frame update
    void Start()
    {
        selectedPiece = null;
    }

    private GameObject prev = null;
    private void onClick() {
        if (Input.GetMouseButtonDown(0) && turnController.currentPlayer == gameObject) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.transform.parent == transform) {
                if (hit.collider.gameObject == prev) {
                    selectedPiece = null;
                    hit.collider.gameObject.GetComponent<Piece>().highlight(false);
                    prev = null;
                } else {
                    if (selectedPiece != null) {
                        selectedPiece.GetComponent<Piece>().highlight(false);
                    }
                    hit.collider.gameObject.GetComponent<Piece>().highlight(true);
                    selectedPiece = hit.collider.gameObject;
                    prev = hit.collider.gameObject;
                }
            }
        }
    }

    public bool canBackOne() {
        foreach (Transform child in transform) {
            if (child.gameObject.GetComponent<Piece>().position == 0) {
                return false;
            }
        }
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        onClick();
    }
}
