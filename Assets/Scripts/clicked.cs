using UnityEngine;
using System.Collections;

public class Clicked : MonoBehaviour
{
    public Transform cam;
    [SerializeField] public Vector3 armOffset;
    [SerializeField] public Vector3 armOffset2;
    public GameObject Bat; 
    public Transform TransBat;
    public Animator batAnimation;

    private bool isSwinging = false;

    void Start()
    {
        batAnimation = Bat.GetComponent<Animator>();
        UpdateBatPosition(); // Initialize position
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isSwinging)
        {
            batAnimation.SetTrigger("Swing");
            StartCoroutine(SwingCooldown());
        }
    }

    void LateUpdate()
    {
        if (!isSwinging)
        {
            UpdateBatPosition();
        }
    }

    void UpdateBatPosition()
    {
        TransBat.position = cam.position + cam.rotation * armOffset;
        //TransBat.rotation = cam.rotation * Quaternion.Euler(armOffset2);
		TransBat.rotation = Quaternion.Euler(0, cam.rotation.eulerAngles.y, 0) * Quaternion.Euler(armOffset2);
		Debug.Log("Restoring Rotation: " + TransBat.rotation.eulerAngles);
    }

    IEnumerator SwingCooldown()
    {
        isSwinging = true;
        yield return new WaitForSeconds(0.5f); // Match animation length
        isSwinging = false;

		Bat.transform.localPosition = Vector3.zero;
        Bat.transform.localRotation = Quaternion.identity;

		UpdateBatPosition();
    }
}
