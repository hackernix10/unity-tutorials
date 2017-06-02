using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValue;
	public float spawnWait;
	public float startWait;
	public int hazardCount;


	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		while(true){
			for(int i = 0; i < hazardCount; ++i){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x,spawnValue.x),spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (Random.Range(0, spawnWait));
			}
		}
	}

}
