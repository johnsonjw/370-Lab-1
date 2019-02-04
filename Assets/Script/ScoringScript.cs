using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringScript : MonoBehaviour
{
    public Rigidbody player;
    public TextMesh scoreText;
    public TextMesh status;
    private bool gameStarted;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        status.text = "Press Space to start";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score + "";
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            gameStarted = true;
            status.text = "WASD to move, space to slow down.";
        }
    }
}
