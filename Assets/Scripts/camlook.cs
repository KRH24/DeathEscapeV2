using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLook : MonoBehaviour
{
	public float mouseSensitivity = 100f; // how fast the camera moves
	public Transform player; // assign your Player GameObject here

	float xRotation = 0f; // vertical rotation of the camera

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked; // hides and locks the mouse to center
	}

	void Update()
	{
		// Get mouse movement input
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


		// Adjust vertical (up/down) camera rotation
		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f); //keeps cam from flipping

		//apply rotation to cam(up/down)
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

		// Rotate the player body left/right
		player.Rotate(Vector3.up * mouseX);

		
	}


}
