using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByShooting : MonoBehaviour {
	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
