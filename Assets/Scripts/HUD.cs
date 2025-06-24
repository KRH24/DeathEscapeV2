using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
	
	public float DamageThershold = 40f;
    public int lives = 34;
    public GameObject[] HealthImages;
	public GameObject Enemy; 
	public int level1PigoenAttack = 15;
	public int level1SkeletonAttack = 1;
    private float lastTimeHit = 0f;
    public float hitCooldown = 1f;

    void Start()
    {
        lives = HealthImages.Length;
    }

    // OnTriggerEnter is called when the Collider other enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("enemy has hit player at: " + Time.time);

            if (Time.time - lastTimeHit < hitCooldown)
            {

                //Ignore hit if within cooldown period
                return;
            }

            lastTimeHit = Time.time;

            if (lives <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                //DamageThershold -= level1PigoenAttack;
                Debug.Log("enemy has hit player");
                Debug.Log("lives left: " + lives);
                // lives -= 1;
                //HealthImages[lives].GetComponent<RawImage>().enabled = false;
                // HealthImages[lives].SetActive(false);
                int damage = level1SkeletonAttack;
                int oldLives = lives;
                lives -= damage;

                if (lives < 0)
                {

                    lives = 0;
                }

                Debug.Log("----------");
                Debug.Log("Before hit - oldLives: " + oldLives);
                Debug.Log("After hit - lives: " + lives);
                Debug.Log("Expected damage: " + (oldLives - lives));

                for (int i = oldLives - 1; i >= lives; i--)
                {
                    Debug.Log("Disabling health icon index: " + i);
                    if (i >= 0 && i < HealthImages.Length)
                    {
                        HealthImages[i].SetActive(false);
                    }


                }

            }
        }
    }


    // OnTriggerExit is called when the Collider other has stopped touching the trigger.
    //private void OnTriggerExit(Collider other)
   // {
       // if (other.gameObject.CompareTag("Enemy"))
        //{
            // Reset or perform any logic when exiting the trigger
            //DamageThershold = 40f; 
        //}
   // }
}