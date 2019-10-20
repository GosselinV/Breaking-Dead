using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	float clipTime;
	Timer showTimer;

	public float ClipTime{
		set { clipTime = value; }
	}

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;

		Transform score = transform.GetChild (2);
		Transform scoreText = transform.GetChild (3);

		float height = score.GetComponent<RectTransform> ().rect.height / 2f;
		score.transform.position = new Vector3 (Screen.width * 7f / 15f , height * 2.5f, 0);
		scoreText.transform.position = new Vector3 (score.transform.position.x + scoreText.GetComponent<RectTransform> ().rect.width, height * 2.75f, 0);
		scoreText.GetComponent<Text> ().text = GameData.score.ToString();

		showTimer = gameObject.AddComponent<Timer> ();
		showTimer.AddTimerFinishedListener (ShowButtons);
		showTimer.Duration = GameData.clipTime;
		showTimer.Run ();
	}

	public void MainMenuButtonHandle(){
		MenuManager.GoToMenu (MenuName.Main);
	}

	public void RestartButtonHandle(){
		AudioManager.Play (AudioClipName.RestartEvent);
		SceneManager.LoadScene ("GamePlay");
	}

	void ShowButtons(){
//		Time.timeScale = 0;
		GameObject mainMenuButton = Instantiate ((GameObject)Resources.Load ("prefabs/MainMenuButton"), transform);
		float height = mainMenuButton.GetComponent<RectTransform> ().rect.height;
		mainMenuButton.GetComponent<Transform>().position = new Vector3 (Screen.width/2f, height/2f, 0);
		mainMenuButton.GetComponent<Button> ().onClick.AddListener (MainMenuButtonHandle);
		GameObject restartButton = Instantiate ((GameObject)Resources.Load ("prefabs/RestartButton"), transform);
		restartButton.GetComponent<Transform> ().position = new Vector3 (Screen.width / 2f, Screen.height - height, 0); 
		restartButton.GetComponent<Button> ().onClick.AddListener (RestartButtonHandle);
	}
}
