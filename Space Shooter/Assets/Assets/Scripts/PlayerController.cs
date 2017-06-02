using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tiltZ;
	public float tiltX;

	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn;

	public float  fireRate = 0.5f;
	private float nextFire = 0.0f;

	void Update(){
		if (Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	//called before each fixed physics step.
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Rigidbody rb = GetComponent<Rigidbody>();

		rb.velocity = new Vector3 (moveHorizontal, 0.0f, moveVertical) * speed;

		//constrain player object to play field
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		rb.rotation = Quaternion.Euler(rb.velocity.z * tiltX, 0.0f, rb.velocity.x * -tiltZ);
	}
}
