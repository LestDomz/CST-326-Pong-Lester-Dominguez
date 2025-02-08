using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float startingSpeed = 10f;

    void Start()
    {
        LaunchBall();
    }

    private void LaunchBall()
    {
        bool isRight = Random.value >= 0.5f;
        bool isUp = Random.value >= 0.5f;

        float xVelocity = isRight ? 1f : -1f;
        float yVelocity = isUp ? 1f : -1f;

        Vector3 initialDirection = new Vector3(xVelocity, yVelocity, 0f).normalized;
        rb.velocity = initialDirection * startingSpeed;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftScore") || other.gameObject.CompareTag("RightScore"))
        {
            bool scoredOnRight = other.gameObject.CompareTag("RightScore");
            //ScoreManager.Instance.AddScore(!scoredOnRight);
            ResetBall();
        }
    }*/


    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = Vector3.zero; // Move to (0,0,0)

        // Add a short delay before restarting
        StartCoroutine(RestartAfterDelay());
    }

    private IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(1f); // Pause before relaunching

        LaunchBall();
    }

}

