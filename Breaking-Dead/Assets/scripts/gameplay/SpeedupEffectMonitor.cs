using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupEffectMonitor : MonoBehaviour {

	public Timer speedTimer;

	void Start(){
		EventManager.AddSpeedupListener (speedup);
		//speedTimer = gameObject.GetComponent<Timer> ();
		speedTimer = gameObject.AddComponent<Timer>();
	}

	public void speedup(){
		speedTimer.Duration = ConfigurationUtils.SpeedupTime;
		if (!speedTimer.Running) {
			AudioManager.Play (AudioClipName.DestroySpeedupBlockEvent);
			speedTimer.Run ();
		}
	}

}
