using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosionAsteroid;
	public GameObject explosionPlayer;
	private GameController gameController;

	public int scoreValue;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		} else {
			Debug.LogError ("Cannot find GameController script");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag != "Boundary") {

			if (other.tag == "Player") {
				Instantiate (explosionPlayer, other.transform.position, other.transform.rotation);
			}

			if (other.tag == "Bolt") {
				gameController.AddScore (scoreValue);
			}
				
			Instantiate (explosionAsteroid, transform.position, transform.rotation);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
