using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    private Rigidbody rb;
    [SerializeField] private float maxHealth = 3;
    private float currentHealth;

    [SerializeField] private EnemyHealth healthbar;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        currentHealth = maxHealth;
        healthbar.UpdateHealthBar(maxHealth, currentHealth);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bat"))
        {
            Debug.Log("Enemy got hit by Bat");
            Vector3 knockbackDir = (transform.position - other.transform.position).normalized;
            rb.AddForce(knockbackDir * 100f, ForceMode.Impulse);
            currentHealth -= 1.0f;

            if (currentHealth <= 0f)
            {
                Destroy(gameObject);
            }
            else
            {
                
            healthbar.UpdateHealthBar(maxHealth, currentHealth);

            }

        }

    }
}
