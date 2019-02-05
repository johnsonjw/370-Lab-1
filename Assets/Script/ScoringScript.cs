using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringScript : MonoBehaviour
{
    public BallController player;
    public TextMesh scoreText;
    public TextMesh status;
    public int pointsPerSecond;

    private float timeToFinish;
    private float startTime;
    private bool gameStarted;
    private bool gameOver;
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        status.text = "Press Space to start";
        timeToFinish = 0;
        startTime = 0;
        score = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            
            if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
            {
                gameStarted = true;
                status.text = "WASD to move, space to brake.";
                startTime = Time.time;
            }
            if (gameEnded())
            {
                gameOver = true;
                status.text = "Level complete!";
                score = calculateFinalScore();
            } else
            {
                score = player.getPoints();
            }
            scoreText.text = score + "";
        }
    }

    private float calculateFinalScore()
    {
        float finalScore = 0;
        timeToFinish = Time.time - startTime;
        finalScore = score + (timeToFinish * pointsPerSecond); 
        return finalScore;
    }

    private bool gameEnded()
    {
        return player.getGameStarted() && !player.getPlayerControl();
    }
}