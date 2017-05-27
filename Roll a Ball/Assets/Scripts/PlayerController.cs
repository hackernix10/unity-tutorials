using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int score;

	public Text countText;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb 	  = GetComponent<Rigidbody>();
		score = 0;
		UpdateCountText ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Called before any physics calculations
    void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
	
		rb.AddForce(new Vector3(moveHorizontal, 0.0f, moveVertical) * speed);
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")) {
			other.gameObject.SetActive (false);
			score++;
			UpdateCountText ();
		}
	}

	void UpdateCountText(){
		countText.text = "Count: " + score.ToString();
	}
}