using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

	public int speed=8;
	public Vector2Int direction;
	public int orientation;

	public void Go () {
		if(orientation == 0){
			direction = new Vector2 (speed,0);
		}
		else if(orientation == 45){
			direction = new Vector2 (speed/2 + speed/4,speed/2 + speed/4);
		}
		else if(orientation == 90){
			direction = new Vector2 (0,speed);
		}
		else if(orientation == 135){
			direction = new Vector2 (speed/2,speed/2);
		}
		else if(orientation == 180){
			direction = new Vector2 (speed,speed);
		}

		Rigidbody2D r2d = GetComponent<Rigidbody2D>() as Rigidbody2D;

		r2d.velocity = direction;
	}
}
