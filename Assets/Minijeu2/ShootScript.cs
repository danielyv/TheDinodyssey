using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	public int speed;

	public void Go (int orientation,float dirx, float diry) {
		transform.eulerAngles = new Vector3 (0, 0, orientation);
		Rigidbody2D r2d = GetComponent<Rigidbody2D>() as Rigidbody2D;
		r2d.velocity = new Vector2(dirx/speed,diry/speed);
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
