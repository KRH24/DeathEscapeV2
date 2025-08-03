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
	bool resetArms = false;


	void Start()
	{

    
		TransBat.position = cam.position + cam.rotation * armOffset;
		TransBat.rotation = cam.rotation * Quaternion.Euler(armOffset2);

		batAnimation = Bat.GetComponent<Animator>();
		
	}
	
	
	void Update(){

		if (Input.GetMouseButtonDown(0))
		{
			batAnimation.SetTrigger("Swing");
	        resetArms = false;
			StartCoroutine(Reset());
	    }
		
		
	}


	IEnumerator Reset()
	{

	yield return new WaitForSeconds(0.5f);
	resetArms = true;

	}


	void LateUpdate()
	{
		if (resetArms)
		{
			Debug.Log("Resetting Arms");
			TransBat.position = cam.position + cam.rotation * armOffset;
			TransBat.rotation = cam.rotation * Quaternion.Euler(armOffset2);
		}
	}

		
	
}
