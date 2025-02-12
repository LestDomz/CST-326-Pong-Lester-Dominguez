using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBall : MonoBehaviour
{
    private float speedMultiplier = 2.8f; // Increase speed by 10% per hit
    private float maxSpeed = 10000f; // Set a max speed limit
    private float minSpeed = 7f; // Ensure minimum speed

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, 7f, 0f); // Adjust speed as needed
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 up = new Vector3(0f, 1f, 0f);
        Quaternion posRotation = Quaternion.Euler(45f, 0f, 0f);
        Quaternion negRotation = Quaternion.Euler(45f, 0f, 0f);

        Vector3 posVector = posRotation * up;
        Vector3 negVector = negRotation * up;

        Debug.DrawRay(transform.position, posVector *2f, Color.red);
        Debug.DrawRay(transform.position, posVector * 2f, Color.blue);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"made contact with {other.gameObject.name}");

        Rigidbody rBody = GetComponent<Rigidbody>();
        Vector3 incomingVelocity = rBody.velocity;

        // Reflect velocity based on collision normal
        Vector3 reflectedVelocity = Vector3.Reflect(incomingVelocity, other.contacts[0].normal);

        // Calculate new speed with multiplier
        float newSpeed = incomingVelocity.magnitude * speedMultiplier;
        newSpeed = Mathf.Clamp(newSpeed, minSpeed, maxSpeed); // Keep speed within range

        // Apply new velocity while maintaining direction
        rBody.velocity = reflectedVelocity.normalized * newSpeed;
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f); // Ensure ball moves only on Y-axis
    }

}
