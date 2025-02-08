using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPaddle : MonoBehaviour
{
    public float maxPaddleSpeed = 1f;
    public float collisionBallSpeedUp = 3.0f; // Ball speed multiplier on hit

    void Update()
    {
        //Both Paddles move on Vertical Input
        float movementAxis = Input.GetAxis("LeftPaddle");
        Transform paddleTransform = GetComponent<Transform>();

        Vector3 newPosition = paddleTransform.position + new Vector3(0f, movementAxis * maxPaddleSpeed * Time.deltaTime, 0f);
        newPosition.y = Mathf.Clamp(newPosition.y, -3.75f, 3.75f);

        paddleTransform.position = newPosition;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = other.rigidbody;
            if (ballRb == null) return;

            var paddleBounds = GetComponent<BoxCollider>().bounds;
            float paddleCenterY = paddleBounds.center.y;
            float hitY = other.transform.position.y;

            // Determine bounce direction: -1 for downward, +1 for upward
            float bounceDirection = (hitY >= paddleCenterY) ? 1f : -1f;

            // Determine if this is the left or right paddle
            float paddleX = transform.position.x;
            float newXDirection = (paddleX < 0) ? 1f : -1f; // Left paddle sends ball right, right paddle sends ball left

            // Ensure ball moves at exactly 45 degrees
            float speed = ballRb.velocity.magnitude * collisionBallSpeedUp;
            Vector3 newVelocity = new Vector3(newXDirection, bounceDirection, 0f).normalized * speed;

            ballRb.velocity = newVelocity;
        }
    }
}