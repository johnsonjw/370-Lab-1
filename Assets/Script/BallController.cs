using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour 
{
    public float speed;
    public float brakeStrength;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKey(KeyCode.Space))
        {
            //Vector3 brakeVelocity = new Vector3(rb.velocity.x*);
            //rb.velocity = new Vector3(rb.velocity.x * (1-brakeStrength), rb.velocity.y, rb.velocity.z * (1 - brakeStrength));
            rb.angularVelocity = rb.angularVelocity * (1-brakeStrength);
        }
    }
}
