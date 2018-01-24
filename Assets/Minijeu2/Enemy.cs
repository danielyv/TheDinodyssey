using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float hp = 1;
	public GameObject Bullet;
	public float moveSpeed = 12;
	public float speedX = 12;
	public float speedY = 0;
	public bool canShoot;
	public float fireRate = 0.5f;




	private Rigidbody2D rb;

	void Awake() {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
		
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		if (canShoot) {
			fireRate = fireRate+(Random.Range(fireRate/-2,fireRate/2));
			InvokeRepeating ("Shoot", fireRate, fireRate);
		}
			
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//resetForces ();
		movements ();
		
	}

	void movements () {
		//transform.eulerAngles = new Vector2 (0, 0);
		rb.velocity = new Vector2(speedX, speedY);

	}

	void resetForces () {
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
	}

	public void damage() {
		hp--;
		if (hp <= 0) {
			die ();
		}
	}

	void die() {
		Destroy (gameObject);
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag != "Enemy") {
			damage ();

			if (col.gameObject.tag == "SpaceshipPlayer") {
				col.gameObject.GetComponent<MovementPlayer>().damage ();
				die ();
			}
		}
	}

	void OnBecameInvisible() {
		die();
	} 

	void Shoot () {
		GameObject temp = Instantiate<GameObject> (Bullet, transform.position, Quaternion.identity);
		temp.GetComponent<ShootScript> ().TirEnemy (speedX, speedY);
	}

}
