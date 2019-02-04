using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringScript : MonoBehaviour
{
    public Rigidbody player;
    public TextMesh score;
    public TextMesh status;
    private bool gameStarted;
    // Start is called before the first frame update
    void Start()
    {
        status.text = "Press Space to start";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            gameStarted = true;
            status.text = "WASD to move, space to slow down.";
        }
    }
}
