using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float maxPaddleSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movementAxis = Input.GetAxis("Horizontal");

        Transform paddleTransform = GetComponent<Transform>();
        paddleTransform.position += new Vector3(0f, 0f, movementAxis * maxPaddleSpeed * Time.deltaTime);
    }
}
