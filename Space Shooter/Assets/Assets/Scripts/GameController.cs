using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValue;

	public float hazardCount;
	public float hazardSpeed;
	public float spawnWait;
	public float waveWait;
	public float startWait;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		for(int waveNumber = 1; waveNumber <= 20; waveNumber++, hazardCount += 5){
			/* Rigidbody rbh = hazard.GetComponent<Rigidbody>();
			hazardSpeed += (Mathf.Log10 (waveNumber*10));
			rbh.velocity = hazard.transform.forward * (10+hazardSpeed); */
			Debug.Log ("Wave " + waveNumber);
			Debug.Log ("Hazards " + hazardCount);

			for(int i = 0; i < hazardCount; ++i){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x,spawnValue.x),spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (Random.Range(0, spawnWait));
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

}
