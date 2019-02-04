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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerControl = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerControl = true;
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
        else
        {
            freezeBall();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "goal")
        {
            freezeBall();
            playerControl = false;
        }
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
