using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Optional: Smooth movement and better collision handling
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate() // Use FixedUpdate for physics
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            
            Vector3 newPosition = rb.position + direction * speed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);

            
            // rb.AddForce(direction * speed, ForceMode.Acceleration);
        }
    }
}
