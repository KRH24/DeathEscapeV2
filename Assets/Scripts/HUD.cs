using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	
	public float DamageThershold = 40f;
    public int lives = 34;
    public GameObject[] HealthImages;
	public GameObject Enemy; 
	public float level1PigoenAttack = 20f;
	public float level1SkeletonAttack = 25f;
	


    // OnTriggerEnter is called when the Collider other enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            if (lives <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                //DamageThershold -= level1PigoenAttack;
                Debug.Log("enemy has hit player");
                lives -= 1;
                //HealthImages[lives].GetComponent<RawImage>().enabled = false;
                HealthImages[lives].SetActive(false);
                Debug.Log("lives left: " + lives);
            }
        }
    }


    // OnTriggerExit is called when the Collider other has stopped touching the trigger.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Reset or perform any logic when exiting the trigger
            DamageThershold = 40f; 
        }
    }
}