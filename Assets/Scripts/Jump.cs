using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
	private bool wantJump = false; 
	private bool isGrounded;
	private int jumpCount = 0;
	private int maxJumps = 1;
	public float vert;
	public Transform player; 
	public Rigidbody rb;



	void Update(){
		if(Input.GetKeyDown(KeyCode.Space))
		{
		
			wantJump = true;
		}
	}

	void FixedUpdate(){
		//isGrounded = Physics.Raycast(player.position, Vector3.down, 1.1f);
        float distToGround = GetComponent<Collider>().bounds.extents.y + 0.1f;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, distToGround);

		if (isGrounded)
		{
			jumpCount = 0;
			Debug.Log("Grounded: " + isGrounded);
		}
		if (wantJump && jumpCount < maxJumps)
		{
			rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
			rb.AddForce(Vector3.up * vert, ForceMode.Impulse);
			jumpCount++;
		}
		
		wantJump = false; // prevent stuck jump input	
	}

}
