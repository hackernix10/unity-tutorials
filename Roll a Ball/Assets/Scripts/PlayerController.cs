using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int score;
	const int MAX_SCORE = 8;

	public Text countText;
	public Text winText;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb 	  		 = GetComponent<Rigidbody>();
		score 		 = 0;
		winText.text = "";
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
			if (score == MAX_SCORE) {
				winText.text = "You Win";
			}
		}
	}

	void UpdateCountText(){
		countText.text = "Count: " + score.ToString();
	}

}