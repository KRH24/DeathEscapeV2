using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardFlashStep : MonoBehaviour
{
    public Transform orientation; // Use the same "orientation" object from your movement system
    public Rigidbody rb;
    public float forwardStepForce = 75f;

    private float lastTapTime = 0f;
    private float threshold = 0.3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            float currentTime = Time.time;

            if (currentTime - lastTapTime <= threshold)
            {
                Vector3 forwardDash = orientation.forward * forwardStepForce;
                rb.AddForce(forwardDash, ForceMode.Impulse);
                lastTapTime = 0f;
            }
            else
            {
                lastTapTime = currentTime;
            }
        }
    }
}
