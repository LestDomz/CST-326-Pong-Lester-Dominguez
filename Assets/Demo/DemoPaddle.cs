using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DemoPaddle : MonoBehaviour
{
    public float maxPaddleSpeed = 1f;
    public float paddleForce = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider c = GetComponent<BoxCollider>();
        float max = c.bounds.max.z;
        float min = c.bounds.min.z;
        Debug.Log($"max: {max}, min: {min}");
    }

    private void FixedUpdate()
    {
        //float horizontalValue = Input.GetAxis("Horizontal");
        //Vector3 force = Vector3.right * horizontalValue; // * unitsPerSecond * Time.deltaTime;

        //Rigidbody rb = GetComponent<Rigidbody>();
        //rb.AddForce(force, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        float movementAxis = Input.GetAxis("Vertical");
        //float movementAxis = Input.GetAxis("LeftPaddle");

        Transform paddleTransform = GetComponent<Transform>();

        Vector3 newPosition = paddleTransform.position + new Vector3(0f, movementAxis * maxPaddleSpeed * Time.deltaTime, 0f);
        newPosition.x = Math.Clamp(newPosition.x, -12.5f, 4.4f);

        paddleTransform.position = newPosition;
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.rigidbody;

            // Get paddle bounds
            Bounds paddleBounds = GetComponent<BoxCollider>().bounds;
            float paddleCenterX = paddleBounds.center.x;
            float paddleWidth = paddleBounds.extents.x;

            // Get ball's position relative to the paddle's center
            float impactPointX = collision.transform.position.x;
            float offset = (impactPointX - paddleCenterX) / paddleWidth; // Normalize to range [-1, 1]

            // Adjust angle based on offset
            float angle = offset * 45f; // Max deflection angle of 45 degrees

            // Calculate new direction with reflection
            Vector3 newDirection = Quaternion.Euler(0, 0, angle) * Vector3.up;

            // Maintain speed consistency
            float speed = ballRb.velocity.magnitude;
            ballRb.velocity = newDirection.normalized * speed;
        }
    }*/
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.rigidbody;

            // Get paddle bounds
            Bounds paddleBounds = GetComponent<BoxCollider>().bounds;
            float paddleCenterX = paddleBounds.center.x;
            float paddleWidth = paddleBounds.extents.x;

            // Get ball's position relative to the paddle's center
            float impactPointX = collision.transform.position.x;
            float offset = (impactPointX - paddleCenterX) / paddleWidth; // Normalize to range [-1, 1]

            // Adjust angle based on offset
            float angle = offset * 45f; // Max deflection angle of 45 degrees

            // Reflect the ball's velocity on the Y-axis
            Vector3 reflectedVelocity = Vector3.Reflect(ballRb.velocity, Vector3.up);

            // Apply angle adjustment
            Vector3 newDirection = Quaternion.Euler(0, 0, angle) * reflectedVelocity.normalized;

            // Maintain speed consistency
            float speed = ballRb.velocity.magnitude;
            float minSpeed = 5f;  // Prevent ball from slowing down too much
            float maxSpeed = 30f; // Prevent excessive speed
            speed = Mathf.Clamp(speed, minSpeed, maxSpeed);

            // Apply new velocity
            ballRb.velocity = newDirection * speed;
        }
    }*/

}