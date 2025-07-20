using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private float moveSpeed;
    public float sprintSpeed;
    public float walkSpeed;


    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode jumpKey = KeyCode.Space;



    public bool IsGrounded => grounded; // Add this property
    public Rigidbody Rb => rb;          // Also helpful if double jump script needs access





    public MovementState state;


    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    public float wallrunSpeed;
    public bool wallRunning;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;



    [Header("Ground Pound")]
    public float groundPoundForce = 40f;
    public float groundPoundCooldown = 1f;
    private bool canGroundPound = true;
    public KeyCode groundPoundKey = KeyCode.LeftControl;
    private bool isGroundPounding = false;







    public enum MovementState
    {
        walking,
        jumping,
        sprinting,
        air,
        wallrunning,
        groundpounding,
        
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;

    }

    private void Update()
    {
        //ground check
        //grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);



        MyInput();
        SpeedControl();
        StateHandler();
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

        if (grounded && isGroundPounding)
        {
            isGroundPounding = false;

            // Optional: spawn landing FX, bounce upward slightly
            rb.AddForce(Vector3.up * (jumpForce / 2f), ForceMode.Impulse); // slight bounce
        }



    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        //when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {

            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);

        }

        if (Input.GetKeyDown(groundPoundKey) && !grounded && canGroundPound)
        {
            GroundPound();
        }





    }



    private void GroundPound()
    {
        isGroundPounding = true;
        canGroundPound = false;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // stop vertical
        rb.AddForce(Vector3.down * groundPoundForce, ForceMode.Impulse); // slam down
        state = MovementState.groundpounding;

        // Optional: camera shake or animation here

        Invoke(nameof(ResetGroundPound), groundPoundCooldown);
    }


    private void ResetGroundPound()
    {
        canGroundPound = true;
    }








    private void MovePlayer()
    {
        //calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //on ground
        if(grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);


        //in air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);


    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //limit velocity if needed

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);

        }


    }

    private void StateHandler()
    {
        if (grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;


        }
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }

        else
        {
            state = MovementState.air;
        }



        // Mode - Wall Running

        if (wallRunning)
        {
            state = MovementState.wallrunning;
            moveSpeed = wallrunSpeed; 



        }


        if (isGroundPounding)
        {
            state = MovementState.groundpounding;
            moveSpeed = 0f;
            return;
        }







    }

    private void Jump()
    {
        // reset y velocity

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);




    }


    private void ResetJump()
    {

        readyToJump = true;

    }


    
}
