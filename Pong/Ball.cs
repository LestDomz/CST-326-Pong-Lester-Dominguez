using System.Collections;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float startingSpeed = 10f;
    private float speedMultiplier = 1.2f;
    private float paddleShrinkFactor = 0.7f;
    private float ballShrinkFactor = 0.7f;
    public GameObject floatingTextPrefab; // Assign in Inspector

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ShrinkPaddleCube"))
        {
            ShrinkPaddles();
            ShowFloatingText("Paddles Shrunk!", other.transform.position);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("ShrinkBallCube"))
        {
            ShrinkBall();
            ShowFloatingText("Ball Shrunk!", other.transform.position);
            Destroy(other.gameObject);
        }
    }

    private void ShrinkPaddles()
    {
        GameObject leftPaddle = GameObject.Find("LeftPaddle");
        GameObject rightPaddle = GameObject.Find("RightPaddle");

        if (leftPaddle && rightPaddle)
        {
            leftPaddle.transform.localScale = new Vector3(rightPaddle.transform.localScale.x * paddleShrinkFactor, 1f, 1f);
            rightPaddle.transform.localScale = new Vector3(rightPaddle.transform.localScale.x * paddleShrinkFactor, 1f, 1f);
        }

    }

    private void ShrinkBall()
    {
        transform.localScale *= ballShrinkFactor;
    }

    private void ShowFloatingText(string message, Vector3 position)
    {
        if (floatingTextPrefab)
        {
            GameObject textObj = Instantiate(floatingTextPrefab, GameObject.Find("Canvas").transform);
            textObj.GetComponent<FloatingText>().ShowMessage(message, position);
        }
    }

    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        StartCoroutine(RestartAfterDelay());
    }

    private IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        LaunchBall();
    }
}
