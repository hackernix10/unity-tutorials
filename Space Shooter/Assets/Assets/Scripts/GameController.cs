using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;

	void SpawnWaves(){
		Vector3 spawnPosition = new Vector3 ();
		Quaternion spawnRotation = new Quaternion ();
		Instantiate (hazard, spawnPosition, spawnRotation);
	}

	// Use this for initialization
	void Start () {
		SpawnWaves ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
