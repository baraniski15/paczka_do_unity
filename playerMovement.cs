using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	public Rigidbody rb;
	public float p_Speed;
	float rotacjaYlimit = 90;
	float rotacjaY = 0;
	float rotacjaX = 0;

	// Use this for initialization
	void Start () {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		sterowanie ();
	}

	void sterowanie() {
		rotacjaX += Input.GetAxis("Mouse X");
		rotacjaY -= Input.GetAxis ("Mouse Y");
		float ruchX = Input.GetAxis ("Vertical");
		float ruchZ = Input.GetAxis ("Horizontal");
		Vector3 poruszanieX = transform.forward * ruchX * p_Speed * Time.deltaTime;
		Vector3 poruszanieZ = transform.right * ruchZ * p_Speed * Time.deltaTime;
		rb.MovePosition (rb.position + poruszanieX + poruszanieZ);
		//transform.rotation = Quaternion.Euler (0, rotacjaX, 0);
		rotacjaY = Mathf.Clamp (rotacjaY, -rotacjaYlimit, rotacjaYlimit);
		Camera.main.transform.localRotation = Quaternion.Euler (rotacjaY, 0, 0);
		rb.MoveRotation (Quaternion.Euler (0, rotacjaX, 0));
	}
}