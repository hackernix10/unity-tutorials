using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByShooting : MonoBehaviour {

	public GameObject explosionAsteroid;
	public GameObject explosionPlayer;

	void OnTriggerEnter(Collider other){
		if (other.tag != "Boundary") {

			if (other.tag == "Player") {
				Instantiate (explosionPlayer, other.transform.position, other.transform.rotation);
			}

			Instantiate (explosionAsteroid, transform.position, transform.rotation);

			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
