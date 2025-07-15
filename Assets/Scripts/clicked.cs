using UnityEngine;
using System.Collections;


public class clicked : MonoBehaviour
{
    public GameObject player;
	public Transform cam;
	[SerializeField] public Vector3 batOffset;
	[SerializeField] public Vector3 batOffset2;
	public GameObject Bat; 
	public Transform TransBat;
	private Vector3 ogBatPosition; 
	private Quaternion ogBatRotation;
	public Animator batAnimation;
	
	
	void Start(){
		
		
		TransBat.position = cam.position + cam.rotation * batOffset;
		TransBat.rotation = cam.rotation * Quaternion.Euler(batOffset2);
		
	}
	
	
	void Update(){

		if (Input.GetMouseButtonDown(0))
		{



			ogBatRotation = TransBat.rotation;
			ogBatPosition = TransBat.position;

			Bat.GetComponent<Animator>().enabled = true;
		    batAnimation.SetTrigger("Swing");
		
		//player.GetComponent<FPSController>().enabled = false;
			//player.GetComponent<Rigidbody>().isKinematic = true; 
			//cam.GetComponent<CamLook>().enabled = false;
			//isFrozen = true;

		}
		
		
		
		
		
	}
	
}
