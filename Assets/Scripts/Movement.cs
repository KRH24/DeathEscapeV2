using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public Rigidbody rb; 
	
	public float fowardForce = 200f;
	public float sideForce = 200f;
	public Transform cameraTrans;

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector3 camForward = cameraTrans.forward;
		Vector3 camRight = cameraTrans.right; 
		
		camForward.y = 0f;
		camRight.y = 0f; 
		
		Vector3 moveDirection = Vector3.zero;
		
	    
		if(Input.GetKey("d")){
	    	
			moveDirection += camRight;
			//rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
	    
		if(Input.GetKey("a")){
	    	
			moveDirection -= camRight;
			//rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		if(Input.GetKey("w")){
	    	
			moveDirection += camForward;
			//rb.AddForce(0, 0, fowardForce * Time.deltaTime, ForceMode.VelocityChange);
		}
		if(Input.GetKey("s")){
	    	
			moveDirection -= camForward;
			//rb.AddForce(0, 0, -fowardForce * Time.deltaTime, ForceMode.VelocityChange);
		}
	    
		moveDirection.Normalize(); 
		
		rb.AddForce(moveDirection * fowardForce * Time.fixedDeltaTime, ForceMode.VelocityChange); 

	}
}