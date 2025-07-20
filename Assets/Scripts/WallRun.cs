using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

public class WallRun : MonoBehaviour
{
    //Wall Running Script (from https://www.youtube.com/watch?v=gNt9wBOrQO4&t=119s / DaveGameDev on YouTube


    [Header("WallRunning")]
    public LayerMask whatIsWall;
    public LayerMask whatIsGround;
    public float wallRunForce = 30f;
    public float maxWallRunTime;
    private float wallRunTimer;


    [Header("Input")]
    private float horizontalInput;
    private float verticalInput;

    [Header("Detection")]
    public float wallCheckDistance;
    public float minJumpHeight;
    private RaycastHit leftWallhit;
    private RaycastHit rightWallhit;
    private bool wallLeft;
    private bool wallRight;

    [Header("References")]
    public Transform orientation;
    private PlayerMovement pm; 
    private Rigidbody rb;


    private void Start()
    {

       rb = GetComponent<Rigidbody>();
       pm = GetComponent<PlayerMovement>();



    }

    private void Update()
    {

        CheckForWall();
        StateMachine();

    }

    private void FixedUpdate()
    {
        if (pm.wallRunning)
        {

            WallRunningMovement();


        }
    }

    private void CheckForWall()
    {
        wallRight = Physics.Raycast(transform.position, orientation.right, out rightWallhit, wallCheckDistance, whatIsWall);
        wallLeft = Physics.Raycast(transform.position, -orientation.right, out leftWallhit, wallCheckDistance, whatIsWall);



    }

    private bool AboveGround()
    {

        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, whatIsGround);

    }


    private void StateMachine()
    {
        // Getting Inputs

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // State 1 - WallRunning

        /*if((wallLeft || wallRight) && verticalInput > 0 && AboveGround())
        {

            //start wallrun here

            if (!pm.wallRunning) 
            
            { 
            
            StartWallRun();
            
            
            }


            else
            {
                if (pm.wallRunning) 
                { 
                
                StopWallRun();
                
                
                }
            }*/

        bool canWallRun = (wallLeft || wallRight) && verticalInput > 0 && AboveGround();
        if (canWallRun)
        {
            if (!pm.wallRunning)
                StartWallRun();
        }
        else
        {
            if (pm.wallRunning)
                StopWallRun();
        }





    

}

    private void StartWallRun()
    {

        pm.wallRunning = true;



    }

    private void WallRunningMovement()
    {

        rb.useGravity = false;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;

        //  Vector3 wallForward = Vector3.Cross(wallNormal, transform.up);


        Vector3 wallNormal = wallRight ? rightWallhit.normal : leftWallhit.normal;
        Vector3 wallForward = Vector3.Cross(wallNormal, Vector3.up).normalized;

        // Flip if going opposite of player direction
        if (Vector3.Dot(orientation.forward, wallForward) < 0)
            wallForward = -wallForward;


        rb.linearDamping = 0f;
        rb.linearDamping = pm.groundDrag; 








        //forward force
        rb.AddForce(wallForward * wallRunForce, ForceMode.Force);

       // if((orientation.forward - wallForward).magnitude > (orientation.forward - -wallForward).magnitude)
         //   wallForward = -wallForward;

        //push to wall force

        if(!(wallLeft && horizontalInput > 0) && !(wallRight && horizontalInput < 0)) 
            rb.AddForce(-wallNormal * 30f, ForceMode.Force);

    }



    private void StopWallRun()
    {

        pm.wallRunning = false;
        rb.useGravity=true;


    }





}
