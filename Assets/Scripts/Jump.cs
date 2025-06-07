using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
	private bool wantJump = false; 
	private bool isGrounded;
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
		isGrounded = Physics.Raycast(player.position, Vector3.down, 1.1f);
		if (wantJump && isGrounded)
		{
			rb.AddForce(Vector3.up * vert, ForceMode.Impulse);
			wantJump = false;
		}
		else
		{
			wantJump = false; // prevent stuck jump input
		}	
	}

}
