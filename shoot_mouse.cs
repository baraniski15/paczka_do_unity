using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_mouse : MonoBehaviour {

	shoot_gun b;

	// Use this for initialization
	void Start () {
		b = GetComponentInChildren<shoot_gun> ();
		Debug.Log ("działam");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButtonDown (0)){
			b.shoot ();
		}
	}
}
