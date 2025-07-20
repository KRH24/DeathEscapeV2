using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    [Header("Settings")]
    public float doubleJumpForce = 7f;
    public KeyCode jumpKey = KeyCode.Space;
    public bool doubleJumpUnlocked = false;

    private bool canDoubleJump = false;

    private PlayerMovement pm; // Reference to PlayerMovement

    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!doubleJumpUnlocked) return;
        if (pm.IsGrounded)
        {
            canDoubleJump = true; // Reset on landing
        }

        // Only allow double jump if not grounded and we haven't used it yet
        if (Input.GetKeyDown(jumpKey) && !pm.IsGrounded && canDoubleJump)
        {
            canDoubleJump = false;

            // Zero out downward velocity for cleaner jump
            pm.Rb.linearVelocity = new Vector3(pm.Rb.linearVelocity.x, 0f, pm.Rb.linearVelocity.z);
            pm.Rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.Impulse);

            
        }
    }
}
