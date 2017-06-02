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

	public GUIText scoreText;
	public GUIText waveText;
	private int score;
	private int wave;

	// Use this for initialization
	void Start () {
		score = 0;
		wave = 1;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
		
	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

	void UpdateWave(){
		waveText.text = "Wave " + wave;
	}


	IEnumerator SpawnWaves(){
		yield return new WaitForSeconds (startWait);
		for(int waveNumber = 1; waveNumber <= 20; waveNumber++, hazardCount += 5){
			/* Rigidbody rbh = hazard.GetComponent<Rigidbody>();
			hazardSpeed += (Mathf.Log10 (waveNumber*10));
			rbh.velocity = hazard.transform.forward * (10+hazardSpeed); */
			Debug.Log ("Wave " + waveNumber);
			Debug.Log ("Hazards " + hazardCount);

			UpdateWave ();
			WaveTextFadeIn ();
			yield return new WaitForSeconds (waveWait);
			WaveTextFadeOut ();

			for(int i = 0; i < hazardCount; ++i){
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x,spawnValue.x),spawnValue.y, spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (Random.Range(0, spawnWait));
			}
		}
	}

	IEnumerator WaveTextFadeIn(){
		waveText.color = new Color (waveText.color.r, waveText.color.g, waveText.color.b, 0);
		while (waveText.color.a < 1.0f) {
			waveText.color = new Color (waveText.color.r, waveText.color.g, waveText.color.b, waveText.color.a + (Time.deltaTime / 1f));
			yield return null;
		}
	}

	IEnumerator WaveTextFadeOut(){
		waveText.color = new Color (waveText.color.r, waveText.color.g, waveText.color.b, 1);
		while (waveText.color.a > 0.0f) {
			waveText.color = new Color (waveText.color.r, waveText.color.g, waveText.color.b, waveText.color.a - (Time.deltaTime / 1f));
			yield return null;
		}
	}

}
