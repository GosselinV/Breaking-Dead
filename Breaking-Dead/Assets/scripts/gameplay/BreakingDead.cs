using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BreakingDead : MonoBehaviour {


	void Start(){
		EventManager.GameOverListener (GameOverMenu);
		EventManager.BlockDestroyedListener (BlockDestroyedHandle);
	}


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameObject.FindGameObjectWithTag ("PauseMenu") == null && GameObject.FindGameObjectWithTag("INFO") == null) {
				MenuManager.GoToMenu (MenuName.Pause);
			}
		}
	}

	void BlockDestroyedHandle(){
		if (GameObject.FindGameObjectsWithTag ("block").Length <= 1) {
			AudioManager.Play (AudioClipName.DestroyBlockGameOverEvent);
			GameData.clipTime = AudioManager.audioClips [AudioClipName.DestroyBlockGameOverEvent].length;
			GameData.score = GameObject.FindGameObjectWithTag ("HUD").GetComponent<HUD> ().Points;
			SceneManager.LoadScene ("GameOverMenu");
		}
	}

	void GameOverMenu(){
		Time.timeScale = 0.01f;
		Timer waitTime = gameObject.AddComponent<Timer> ();
		waitTime.Duration = AudioManager.audioClips [AudioClipName.BallCountEvent].length * 0.02f;
		waitTime.AddTimerFinishedListener (LoadGameOverScene);
		waitTime.Run ();

	
	}

	void LoadGameOverScene(){
		AudioManager.Play (AudioClipName.BallsCounterGameOverEvent);
		GameData.clipTime = AudioManager.audioClips [AudioClipName.BallsCounterGameOverEvent].length;
		GameData.score = GameObject.FindGameObjectWithTag ("HUD").GetComponent<HUD> ().Points;
		SceneManager.LoadScene ("GameOverMenu");
	}
}
