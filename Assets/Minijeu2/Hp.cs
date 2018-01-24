using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour {

	public Slider sl;
	private int currentHP = 10;

	void Awake() {
		sl = GetComponent<Slider> ();
	}
		
	void Update() {
		sl.value = currentHP;
	}

	public void changeHP(int dHP) {
		currentHP = dHP;
	}
}

