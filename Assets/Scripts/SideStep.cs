using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidestep : MonoBehaviour
{
	
	public Transform Player;
	public Rigidbody rb;
	public float sideStepForce = 50f;
	bool hasPressed = false; 
	int count = 0;
	
	private float lastLapTime = 0f; 
	private float threshold = 0.3f;
  
    // Update is called once per frame
    void Update()
    {
	    if(Input.GetKeyDown(KeyCode.A)){
	    
	    	hasPressed = true;
	    	//count += 1;
	    	
	    	float CurrentTime = Time.time;
	    	
	    	if(CurrentTime - lastLapTime <= threshold){
	    	
		    	Vector3 sidestep = Player.right * -sideStepForce;
		    	rb.AddForce( sidestep, ForceMode.Impulse);
		    lastLapTime = 0f;
		    
		    }
		    else{
		    	
			    lastLapTime = CurrentTime;
		    	
		    }
		    
	    }
		    if(Input.GetKeyDown(KeyCode.D)){
	    	
			    hasPressed = true;
			    //count += 1;
	    	
			    float CurrentTime = Time.time;
	    	
			    if(CurrentTime - lastLapTime <= threshold){
	    	
				    Vector3 sidestep = Player.right * sideStepForce;
				    rb.AddForce( sidestep, ForceMode.Impulse);
				    lastLapTime = 0f;
		    
			    }
			    else{
		    	
				    lastLapTime = CurrentTime;
		    	
			    }
		       
		    	
	    	
		    }
	    
	    
    
    }

}
