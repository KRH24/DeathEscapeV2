using UnityEngine;
using System.Collections;


public class clicked : MonoBehaviour
{
    public GameObject player;
	public Transform cam;
	[SerializeField] public Vector3 armOffset;
	[SerializeField] public Vector3 armOffset2;
	public GameObject Bat; 
	public Transform TransBat;
	private bool isFrozen = false; 
	private Vector3 ogBatPosition; 
	private Quaternion ogBatRotation; 
	
	
	void Start(){
		
		
		TransBat.position = cam.position + cam.rotation * armOffset;
		TransBat.rotation = cam.rotation * Quaternion.Euler(armOffset2);
		
	}
	
	void OnMouseDown(){
		
		if(isFrozen){
			
			
			return; 
		}
		
		
		ogBatRotation = TransBat.rotation; 
		ogBatPosition = TransBat.position;
		
		Bat.GetComponent<Animator>().enabled = true;
		Animator batPlay = Bat.GetComponent<Animator>(); 
		batPlay.Play("Take 001");
		
		//player.GetComponent<FPSController>().enabled = false;
		player.GetComponent<Rigidbody>().isKinematic = true; 
		//cam.GetComponent<CamLook>().enabled = false;
		isFrozen = true;
		
	}
	
	void Update(){
		
		if(isFrozen == true && Input.GetKey(KeyCode.Escape)){
		
		
			//player.GetComponent<FPSController>().enabled = true;
			player.GetComponent<Rigidbody>().isKinematic = false; 
			Bat.GetComponent<Animator>().Rebind();
			Bat.GetComponent<Animator>().Update(0f);
			Bat.GetComponent<Animator>().enabled = false;
			//resetArms = true;
			TransBat.position = ogBatPosition;//might want to set it equal to cam position
			TransBat.rotation = ogBatRotation;//might want to set it equal to cam position
			
			isFrozen = false;
			StartCoroutine(Reset());
			
		}
		
		
		
	}
	
	
	IEnumerator Reset(){
			
			
		yield return new WaitForEndOfFrame();
		//resetArms = false;
			
	}
		
		
	void LateUpdate(){
		//LateUpdate is used after update	
		if(!isFrozen){
		
			
			
			Vector3 yrotate = new Vector3(0f, cam.eulerAngles.y, 0f);
			Quaternion yrotation = Quaternion.Euler(yrotate);//smoothly rotating y

			// Set arms position in world space
			TransBat.position = cam.position + yrotation * armOffset;

			// Set arms rotation in world space
			TransBat.rotation = yrotation * Quaternion.Euler(armOffset2);
			
			
	}

		
	}
}
