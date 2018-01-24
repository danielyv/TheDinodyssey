using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	private float start;

	public void Start() {
		start = Time.time;
	}


	public void Go (float orientation,float dirx, float diry) {
//		if (start < Time.time -3) {
//			die ();
//		}
		transform.eulerAngles = new Vector3 (0, 0, orientation);
		Rigidbody2D r2d = GetComponent<Rigidbody2D>() as Rigidbody2D;
		r2d.velocity = new Vector2 (dirx/10, diry/10);
	}

	public void TirEnemy(float dirx, float diry) {
		Rigidbody2D r2d = GetComponent<Rigidbody2D>() as Rigidbody2D;
		r2d.velocity = new Vector2 (dirx*2, diry*2);
	}

	void OnBecameInvisible() {
		// Destroy the bullet 
		die();
	}

	void die() {
		Destroy (gameObject);
	}


	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Enemy") {
			die ();
			col.gameObject.GetComponent<Enemy> ().damage ();
		} else if (col.gameObject.tag == "SpaceshipPlayer") {
			die ();
			col.gameObject.GetComponent<MovementPlayer> ().damage ();
		}

	}
}
