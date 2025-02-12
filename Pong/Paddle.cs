using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float maxPaddleSpeed = 1f;
    public float collisionBallSpeedUp = 3.0f; // Ball speed multiplier on hit
    private AudioSource hitSound; // Reference to AudioSource

    void Start()
    {
        hitSound = GetComponent<AudioSource>(); // Get the AudioSource component
    }

    void Update()
    {
        float movementAxis = 0f;

        if (gameObject.name == "LeftPaddle")
            movementAxis = Input.GetAxis("LeftPaddle");
        else if (gameObject.name == "RightPaddle")
            movementAxis = Input.GetAxis("RightPaddle");

        Vector3 newPosition = transform.position + new Vector3(0f, movementAxis * maxPaddleSpeed * Time.deltaTime, 0f);
        newPosition.y = Mathf.Clamp(newPosition.y, -3.75f, 3.75f);

        transform.position = newPosition;
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

            float bounceDirection = (hitY >= paddleCenterY) ? 1f : -1f;
            float paddleX = transform.position.x;
            float newXDirection = (paddleX < 0) ? 1f : -1f;

            float speed = ballRb.velocity.magnitude * collisionBallSpeedUp;
            Vector3 newVelocity = new Vector3(newXDirection, bounceDirection, 0f).normalized * speed;

            ballRb.velocity = newVelocity;

            // Play the sound effect when the ball hits the paddle
            if (hitSound != null)
            {
                hitSound.Play();
            }
        }
    }
}
