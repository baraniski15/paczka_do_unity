using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerMovementNet : NetworkBehaviour {

	[SerializeField]
	Behaviour[] componentsToDisable;

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
		if (!isLocalPlayer) {
			for (int i = 0; i < componentsToDisable.Length; i++) {
				componentsToDisable [i].enabled = false;
			}
			return;
		}
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
		rb.MoveRotation (Quaternion.Euler (0, rotacjaX, 0));
		rotacjaY = Mathf.Clamp (rotacjaY, -rotacjaYlimit, rotacjaYlimit);
		Camera.main.transform.localRotation = Quaternion.Euler (rotacjaY, 0, 0);
	}
}