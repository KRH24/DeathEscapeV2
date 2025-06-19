using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	
	public float DamageThershold = 40f;
    public int lives = 40;
    public GameObject[] HealthImages;
	public GameObject Enemy; 
	public float level1PigoenAttack = 20f;
	public float level1SkeletonAttack = 25f;
	
    
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    
    }


    // OnTriggerEnter is called when the Collider other enters the trigger.
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            if (lives <= 0)
            {
                Destory(gameObject);
            }
            else
            {
            DamageThershold -= level1PigoenAttack;
            Debug.Log("enemy has hit player");
            lives -= 1;
            HealthImages[lives].SetActive(false); 
            }
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