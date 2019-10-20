using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HUD : MonoBehaviour {

	#region fields

	// text fields support
	Text scoreText;
	Text ballsText;
	const string scorePrefix = "Score : ";
	const string ballsPrefix = "Balls : ";
	int score = 0;
	int balls; 

	// GameOver support
	GameOverEvent gameOver = new GameOverEvent();

	#endregion

	#region Properties

	public int Points{
		get {return score;}
	}

	#endregion

	// Use this for initialization
	void Start () {
		// fields initialisation
		balls = ConfigurationUtils.BallsPerGame;
		scoreText = GameObject.FindGameObjectWithTag ("scoretext").GetComponent<Text>();
		scoreText.text = scorePrefix + score.ToString();
		ballsText = GameObject.FindGameObjectWithTag ("ballstext").GetComponent<Text> ();
		ballsText.text = ballsPrefix + balls.ToString();

		// Events Support
		EventManager.AddPointListener (Score);
		EventManager.AddCountBallsListener (Balls);
		EventManager.GameOverInvoker (this);
	}

	public void AddGameOverListener(UnityAction listener){
		gameOver.AddListener (listener);
	}

	void Score(int points){
		score += points;
		scoreText.text = scorePrefix + score.ToString ();
	}

	void Balls(){
		AudioManager.Play (AudioClipName.BallCountEvent);
		balls -= 1;
		if (balls >= 0) {
			ballsText.text = ballsPrefix + balls.ToString ();
		}
		if (balls <= 0) {
			gameOver.Invoke ();
		}
	}

}
