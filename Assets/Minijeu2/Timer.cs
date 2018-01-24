using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

	public Text timer;
	float totalTime = 60f; //2 minutes

	private void Update()
	{
		totalTime -= Time.deltaTime;
		UpdateLevelTimer(totalTime );
	}

	public void UpdateLevelTimer(float totalSeconds)
	{
		int minutes = Mathf.FloorToInt(totalSeconds / 60f);
		int seconds = Mathf.RoundToInt(totalSeconds % 60f);

		string formatedSeconds = seconds.ToString();

		if (seconds == 60)
		{
			seconds = 0;
			minutes += 1;
		}

		timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
		if (totalTime <= 0) {
			TimerEnd ();
		}
	}

	public void TimerEnd() {
		//TODO
		timer.text = "SUCCESS";
	}
}
