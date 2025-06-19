using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowardFlashStep : MonoBehaviour
{
	
	public Transform Player;
	public Rigidbody rb;
	public float forwardStepForce = 75f;
	//bool hasPressed = false; 


	private float lastLapTime = 0f; 
	private float threshold = 0.3f;
  
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.W)){
	    	
			//hasPressed = true;
			
	    	
			float CurrentTime = Time.time;
	    	
			if(CurrentTime - lastLapTime <= threshold){

				Vector3 fowardDash = Player.forward * forwardStepForce;
				rb.AddForce( fowardDash, ForceMode.Impulse);
				lastLapTime = 0f;
		    
			}
			else{
		    	
				lastLapTime = CurrentTime;
		    	
			}
		       
		    	
	    	
		}
	}
}

