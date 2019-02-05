using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour 
{
    public float speed;
    public float brakeStrength;
    public float angularBrakeStrength;
    public Rigidbody rb;

    private bool playerControl;
    private bool gameStarted;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameStarted = false;
        playerControl = false;
        points = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!gameStarted)
            {
                gameStarted=true;
                playerControl = true;
            }
           
        }

        //Handling player input
        if (playerControl)
        {
            parseMovement(speed);
            if (Input.GetKey(KeyCode.Space))
            {
                parseBraking(brakeStrength, angularBrakeStrength);
            }
        }
        else if(!gameStarted)
        {
            freezeBall();
            rb.position = new Vector3(rb.position.x, 40, rb.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        scoreCollision(collision);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "goal")
        {
            finishLevel();
        }
    }

    public int getPoints()
    {
        return points;
    }
    public bool getGameStarted()
    {
        return gameStarted;
    }
    public bool getPlayerControl()
    {
        return playerControl;
    }

    private void scoreCollision(Collision collision)
    {
        if (collision.collider.tag == "5Points")
        {
            points += 5;
        }
        if (collision.collider.tag == "10Points")
        {
            points += 10;
        }
        if (collision.collider.tag == "50Points")
        {
            points += 50;
        }
    }
    private void finishLevel()
    {
        freezeBall();
        playerControl = false;
    }
    private void freezeBall()
    {
        rb.velocity = rb.velocity * 0;
        rb.angularVelocity = rb.angularVelocity * 0;
    }
    private void parseMovement  (float moveSpeed)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * moveSpeed);
    }
    private void parseBraking(float linearBrake, float angularBrake)
    {
        rb.velocity = new Vector3(rb.velocity.x * (1 - linearBrake), rb.velocity.y, rb.velocity.z * (1 - linearBrake));
        rb.angularVelocity = rb.angularVelocity * (1 - angularBrake);
    }
}
