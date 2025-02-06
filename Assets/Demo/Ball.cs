using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float startingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        bool isRight = UnityEngine.Random.value >= 0.5;

        float xVelocity = -1f;

        if (isRight == true)
        {
            xVelocity = 1f;
        }

        float yVelocity = UnityEngine.Random.Range(-1,1);

        rb.velocity = new Vector3(xVelocity * startingSpeed, yVelocity * startingSpeed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
