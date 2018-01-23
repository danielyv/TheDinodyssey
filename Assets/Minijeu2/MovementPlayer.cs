using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
	public int hp = 10;
	public float moveSpeed = 25;
	public GameObject Bullet;
	public float fireRate = 0.2f;
	GameObject a,b,c;

	private float lastPressed = 0f;
	private Rigidbody2D rb;


	void Start() {
		rb = gameObject.GetComponent<Rigidbody2D> ();
		a = transform.Find ("AShoot").gameObject;
		b = transform.Find ("BShoot").gameObject;
		c = transform.Find ("CShoot").gameObject;
	}

	void FixedUpdate ()
	{
		resetForces ();
		movements();
		fire ();

	}
	public void movements () {
		// MoveSpeedAjustee
		float mva = (moveSpeed / 2 + moveSpeed / 4);

		if (Input.GetButton ("Right") && Input.GetButton ("Up")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.right * mva * Time.deltaTime);
			transform.Translate (Vector2.up * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 45);

		} else if (Input.GetButton ("Right") && Input.GetButton ("Down")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.right * mva * Time.deltaTime);
			transform.Translate (Vector2.down * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 315);

		} else if (Input.GetButton ("Left") && Input.GetButton ("Up")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.left * mva * Time.deltaTime);
			transform.Translate (Vector2.up * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 135);


		} else if (Input.GetButton ("Left") && Input.GetButton ("Down")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.left * mva * Time.deltaTime);
			transform.Translate (Vector2.down * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 225);

		} else if (Input.GetButton ("Right")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 0);

		} else if (Input.GetButton ("Left")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 180);

		} else if (Input.GetButton ("Up")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.up * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 90);


		} else if (Input.GetButton ("Down")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.down * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 270);
		}
	}

	public void resetForces() {
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
	}

	public void fire() {
		if (Input.GetButton ("Fire") && lastPressed < Time.time - fireRate) {
			lastPressed = Time.time;
			GameObject bullet1 = Instantiate<GameObject> (Bullet, a.transform.position, Quaternion.identity);
			GameObject bullet2 = Instantiate<GameObject> (Bullet, b.transform.position, Quaternion.identity);
			GameObject bullet3 = Instantiate<GameObject> (Bullet, c.transform.position, Quaternion.identity);
			bullet1.GetComponent<ShootScript> ().Go (Mathf.RoundToInt (transform.eulerAngles.z));
			bullet2.GetComponent<ShootScript> ().Go (Mathf.RoundToInt (transform.eulerAngles.z));
			bullet3.GetComponent<ShootScript> ().Go (Mathf.RoundToInt (transform.eulerAngles.z));
		}
	}

	public void damage() {
		hp--;
		if (hp <=0) {
			die ();
		}
	}

	public void die() {
		Destroy (gameObject);
	}


}
