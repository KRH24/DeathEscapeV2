using UnityEngine;
using System.Collections;


public class Clicked : MonoBehaviour
{
    public GameObject player;
	public Transform cam;
	[SerializeField] public Vector3 armOffset;
	[SerializeField] public Vector3 armOffset2;
	public GameObject Bat; 
	public Transform TransBat;
	private Vector3 ogBatPosition; 
	private Quaternion ogBatRotation;
	public Animator batAnimation;


	void Start()
	{


		TransBat.position = cam.position + cam.rotation * armOffset;
		TransBat.rotation = cam.rotation * Quaternion.Euler(armOffset2);

		ogBatRotation = TransBat.rotation;
		ogBatPosition = TransBat.position;

		batAnimation = Bat.GetComponent<Animator>();
		
	}
	
	
	void Update(){

		if (Input.GetMouseButtonDown(0))
		{


			Bat.GetComponent<Animator>().enabled = true;
			batAnimation.SetTrigger("Swing");

			StartCoroutine(Reset());
	}
		
		
	}


	IEnumerator Reset()
	{


		yield return new WaitForSeconds(0.5f);
		//resetArms = false;
		
		TransBat.rotation = ogBatRotation;
		TransBat.position = ogBatPosition;
			
	}
		
		
	

		
	
}
