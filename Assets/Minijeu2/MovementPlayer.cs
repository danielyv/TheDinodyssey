using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
	public int moveSpeed = 25;

	void Update ()
	{
		// MoveSpeedAjustee
		int mva = moveSpeed / 2 + moveSpeed / 4;
		if (Input.GetButton("Right") && Input.GetButton("Up")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.right * mva * Time.deltaTime);
			transform.Translate (Vector2.up * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 45);
		}

		else if (Input.GetButton("Right") && Input.GetButton("Down")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.right * mva * Time.deltaTime);
			transform.Translate (Vector2.down * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 305);
		}

		else if (Input.GetButton("Left") && Input.GetButton("Up")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.left * mva * Time.deltaTime);
			transform.Translate (Vector2.up * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 135);
		}

		else if (Input.GetButton("Left") && Input.GetButton("Down")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.left * mva * Time.deltaTime);
			transform.Translate (Vector2.down * mva * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 225);
		}

		else if (Input.GetButton("Right")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 0);
		}

		else if (Input.GetButton("Left")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.left * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 180);
		}

		else if (Input.GetButton("Up")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.up * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 90);
		}

		else if (Input.GetButton("Down")) {
			transform.eulerAngles = new Vector3 (0, 0, 0);
			transform.Translate (Vector2.down * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector3 (0, 0, 270);
		}
	}

	void deplaD() {
		transform.eulerAngles = new Vector3 (0, 0, 0);
		transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
	}

	void deplaG() {
	}

	void deplaH() {
	}

	void deplaB() {
	}



}
