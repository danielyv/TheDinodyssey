using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
	public int moveSpeed = 25;
	public GameObject Bullet;

	private Vector3 v;
	private float lastPressed = 0;


	void Start() {
		v = transform.position;
		v.x += 2;
	}

	void Update ()
	{
		// MoveSpeedAjustee
		int mva = moveSpeed / 2 + moveSpeed / 4;


		if (Input.GetButton ("Right") && Input.GetButton ("Up")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.right * mva * Time.deltaTime);
			transform.Translate (Vector2.up * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 45);

			v = transform.position;
			v.x += 2;
			v.y += 2;

		} else if (Input.GetButton ("Right") && Input.GetButton ("Down")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.right * mva * Time.deltaTime);
			transform.Translate (Vector2.down * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 315);

			v = transform.position;
			v.x += 2;
			v.y -= 2;

		} else if (Input.GetButton ("Left") && Input.GetButton ("Up")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.left * mva * Time.deltaTime);
			transform.Translate (Vector2.up * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 135);

			v = transform.position;
			v.x -= 2;
			v.y += 2;


		} else if (Input.GetButton ("Left") && Input.GetButton ("Down")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.left * mva * Time.deltaTime);
			transform.Translate (Vector2.down * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 225);

			v = transform.position;
			v.x -= 2;
			v.y -= 2;

		} else if (Input.GetButton ("Right")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 0);

			v = transform.position;
			v.x += 2;

		} else if (Input.GetButton ("Left")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 180);

			v = transform.position;
			v.x -= 2;
		} else if (Input.GetButton ("Up")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.up * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 90);

			v = transform.position;
			v.y += 2;

		} else if (Input.GetButton ("Down")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.down * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 270);

			v = transform.position;
			v.y -= 2;
		}

		if (Input.GetButton ("Fire") && lastPressed < Time.time-0.2) {
			lastPressed = Time.time;
			GameObject bullet=Instantiate<GameObject> (Bullet, v, Quaternion.identity);
			bullet.GetComponent<ShootScript> ().Go(Mathf.RoundToInt(transform.eulerAngles.z));
		}


	}


}
