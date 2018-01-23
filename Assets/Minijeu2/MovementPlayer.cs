using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour {
	public float moveSpeed = 20f;

	void Update()
	{
		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Vector2.right * moveSpeed * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (Vector2.up * moveSpeed * Time.deltaTime);

		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (Vector2.down * moveSpeed * Time.deltaTime);

		}

	}
}
