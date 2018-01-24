using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovementPlayer : MonoBehaviour
{
	public int hp = 9;
	public float moveSpeed = 25;
	public GameObject Bullet;
	public float fireRate = 0.2f;
	GameObject a,b,c;

	private float lastPressed = 0f;
	private Rigidbody2D rb;
	public Hp sl;

	void Awake() {
		sl = GameObject.Find ("Health Bar").GetComponent<Hp> ();
	}
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

		transform.eulerAngles = new Vector3 (0, 0, 0);

		if (Input.GetButton ("Right") && Input.GetButton ("Up")) {
			transform.Translate (Vector2.right * mva * Time.deltaTime);
			transform.Translate (Vector2.up * mva * Time.deltaTime);

		} else if (Input.GetButton ("Right") && Input.GetButton ("Down")) {
			transform.Translate (Vector2.right * mva * Time.deltaTime);
			transform.Translate (Vector2.down * mva * Time.deltaTime);

		} else if (Input.GetButton ("Left") && Input.GetButton ("Up")) {
			transform.Translate (Vector2.left * mva * Time.deltaTime);
			transform.Translate (Vector2.up * mva * Time.deltaTime);

		} else if (Input.GetButton ("Left") && Input.GetButton ("Down")) {
			transform.Translate (Vector2.left * mva * Time.deltaTime);
			transform.Translate (Vector2.down * mva * Time.deltaTime);

		} else if (Input.GetButton ("Right")) {
			transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);

		} else if (Input.GetButton ("Left")) {
			transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);

		} else if (Input.GetButton ("Up")) {
			transform.Translate (Vector2.up * moveSpeed * Time.deltaTime);

		} else if (Input.GetButton ("Down")) {
			transform.Translate (Vector2.down * moveSpeed * Time.deltaTime);
		}

		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	public void resetForces() {
		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0f;
	}

	public void fireBullets() {
		lastPressed = Time.time;
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
		Vector3 dir = Input.mousePosition - pos;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		float dist = Vector3.Distance (pos, Input.mousePosition)*0.002f;

		GameObject bullet1 = Instantiate<GameObject> (Bullet, a.transform.position, Quaternion.identity);
		GameObject bullet2 = Instantiate<GameObject> (Bullet, b.transform.position, Quaternion.identity);
//		GameObject bullet3 = Instantiate<GameObject> (Bullet, c.transform.position, Quaternion.identity);
//		bullet1.GetComponent<ShootScript> ().Go (Mathf.RoundToInt (transform.eulerAngles.z));
//		bullet2.GetComponent<ShootScript> ().Go (Mathf.RoundToInt (transform.eulerAngles.z));
		bullet1.GetComponent<ShootScript> ().Go (angle, dir.x/dist, dir.y/dist);
		bullet2.GetComponent<ShootScript> ().Go (angle, dir.x/dist, dir.y/dist);
	}

	public void fire() {
		if (lastPressed < Time.time - fireRate) {
			if (Input.GetButton("Fire")) {
				fireBullets ();
			}
		}
	}


	public void damage() {
		hp--;
		sl.changeHP (hp);
		if (hp <=0) {
			die ();
		}

	}

	public void die() {
		Destroy (gameObject);
	}


}
