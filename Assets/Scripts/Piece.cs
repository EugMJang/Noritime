using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    [HideInInspector]
    public int position;
    private int path;

    public Transform[] path0;
    public Transform[] path1;
    public Transform[] path2;
    public Transform[] path3;
    // Start is called before the first frame update
    void Start()
    {
        position = 0;
        path = 0;
    }

    public void highlight(bool doHighlight) {
        if (doHighlight) {

        } else {

        }
    }

    public void move(int spaces) {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
