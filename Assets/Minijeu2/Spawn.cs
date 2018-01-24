using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public float rate;
	public GameObject[] ennemies;
	public int waves = 1;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", rate, rate);
	}
	
	void SpawnEnemy() {
		for (int i = 0; i <= waves; i++) {
			float r = Random.Range (0f, 4f);

			// Dessus
			if (r < 1) {
				GameObject g = Instantiate<GameObject> (ennemies [(int)Random.Range (0, ennemies.Length)], new Vector3 (Random.Range (-40f, 40f), 25f, 0), Quaternion.identity);
				g.GetComponent<Enemy> ().speedX = 0;
				g.GetComponent<Enemy> ().speedY = -g.GetComponent<Enemy> ().moveSpeed;
				g.transform.eulerAngles = new Vector3 (0, 0, 0);

				// Dessous
			} else if (r < 2) {
				GameObject g = Instantiate<GameObject> (ennemies [(int)Random.Range (0, ennemies.Length)], new Vector3 (Random.Range (-40f, 40f), -25f, 0), Quaternion.identity);
				g.GetComponent<Enemy> ().speedX = 0;
				g.GetComponent<Enemy> ().speedY = g.GetComponent<Enemy> ().moveSpeed;
				g.transform.eulerAngles = new Vector3 (0, 0, 180);
				// A Gauche
			} else if (r < 3) {
				GameObject g = Instantiate<GameObject> (ennemies [(int)Random.Range (0, ennemies.Length)], new Vector3 (-40f, Random.Range (-25f, 25f), 0), Quaternion.identity);
				g.GetComponent<Enemy> ().speedX = g.GetComponent<Enemy> ().moveSpeed;
				g.GetComponent<Enemy> ().speedY = 0;
				g.transform.eulerAngles = new Vector3 (0, 0, 90);

				// A Droite
			} else {
				GameObject g = Instantiate<GameObject> (ennemies [(int)Random.Range (0, ennemies.Length)], new Vector3 (40f, Random.Range (-25f, 25f), 0), Quaternion.identity);
				g.GetComponent<Enemy> ().speedX = -g.GetComponent<Enemy> ().moveSpeed;
				g.GetComponent<Enemy> ().speedY = 0;

				g.transform.eulerAngles = new Vector3 (0, 0, 270);
			}
		}	
	
	}
	// Update is called once per frame
	void Update () {
		
	}
}
