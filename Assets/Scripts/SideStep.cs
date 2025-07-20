using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidestep : MonoBehaviour
{
    public Transform orientation; // Reference to your camera-facing orientation
    public Rigidbody rb;
    public float sideStepForce = 50f;
    private float lastTapTime = 0f;
    private float threshold = 0.3f;

    void Update()
    {
        // Sidestep Left (Double-Tap A)
        if (Input.GetKeyDown(KeyCode.A))
        {
            float currentTime = Time.time;

            if (currentTime - lastTapTime <= threshold)
            {
                Vector3 sidestep = -orientation.right * sideStepForce;
                rb.AddForce(sidestep, ForceMode.Impulse);
                lastTapTime = 0f; // reset
            }
            else
            {
                lastTapTime = currentTime;
            }
        }

        // Sidestep Right (Double-Tap D)
        if (Input.GetKeyDown(KeyCode.D))
        {
            float currentTime = Time.time;

            if (currentTime - lastTapTime <= threshold)
            {
                Vector3 sidestep = orientation.right * sideStepForce;
                rb.AddForce(sidestep, ForceMode.Impulse);
                lastTapTime = 0f;
            }
            else
            {
                lastTapTime = currentTime;
            }
        }
    }
}
