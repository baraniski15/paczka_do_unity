using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_gun : MonoBehaviour {

	public Rigidbody bullet;
	public Transform bullet_transform;
	public float pre_pocisku;

	public void shoot () {
		Rigidbody shoot_instant;
		shoot_instant = Instantiate (bullet, bullet_transform.position, bullet_transform.rotation);
		shoot_instant.AddForce (bullet_transform.forward * pre_pocisku);
	}
}