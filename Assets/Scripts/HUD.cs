using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	
	public float DamageThershold = 40f; 
	public GameObject Enemy; 
	public float level1ZombieAttack = 20f;
	public float level1SkeletonAttack = 25f;
	
    
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    
    }

    // OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
    protected void OnCollisionEnter(Collision other)
    {
        DamageThershold -= level1ZombieAttack; 
        //DamageThershold -= level1SkeletonAttack; 
	}
	


// OnCollisionExit is called when this collider/rigidbody has stopped touching another rigidbody/collider.
    protected void OnCollisionExit(Collision other)
    {
        // Reset the damage threshold or perform any other logic when exiting collision
        DamageThershold = 40f; 
    }
    
    // OnTriggerEnter is called when the Collider other enters the trigger.
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DamageThershold -= level1ZombieAttack; 
        }
    }


    // OnTriggerExit is called when the Collider other has stopped touching the trigger.
    protected void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Reset or perform any logic when exiting the trigger
            DamageThershold = 40f; 
        }
    }
}