using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour {

	Rigidbody2D rb2d;
	Vector2 direction;
	[SerializeField]
	float ballImpulseForce;
	float ballLifetime;
	float ballDelay;
	float ballDirectionAngle;
	bool started = false;
	bool speedStarted = false;
	Timer startTimer;
	Timer speedTimer;

	// events support
	BallsCounterEvent countBallsEvent;
	SpawnBallsEvent spawnBallsEvent; 

	GameObject eventSystem; 
	BallSpawner ballSpawner;


	// Use this for initialization
	void Start () {

		// Events Support
		countBallsEvent = new BallsCounterEvent();
		spawnBallsEvent = new SpawnBallsEvent ();
		EventManager.AddCountBallsInvoker (this);
		EventManager.AddSpawnBallsInvoker (this);


		// Read config data
		ballImpulseForce = ConfigurationUtils.BallImpulseForce;
		ballLifetime = ConfigurationUtils.BallLifetime;
		ballDelay = ConfigurationUtils.BallDelay;

		// setup initial velocity
		rb2d = gameObject.GetComponent<Rigidbody2D> ();

		// speedup spport
		speedTimer = Camera.main.GetComponent<SpeedupEffectMonitor> ().speedTimer;
		speedTimer.AddTimerFinishedListener (SpeedTimerFinished);
		speedTimer.AddTimerStartListener (SpeedTimerStart);
		if (speedTimer.Running){
			SpeedTimerStart();
		}

		// start delay timer. 
		startTimer = GetComponent<Timer> ();
		startTimer.AddTimerFinishedListener (StartTimerFinish);
		startTimer.Duration = ballDelay;
		startTimer.Run ();

		// Balls don't collide
		foreach (GameObject Balls in GameObject.FindGameObjectsWithTag("ball")){
			Physics2D.IgnoreCollision (Balls.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
		}
	}
		
	//Speed Timer Delegates
	void SpeedTimerStart(){
		direction = rb2d.velocity.normalized;
		ballImpulseForce *= 2f; 
		rb2d.AddForce (ballImpulseForce * direction, ForceMode2D.Impulse);
		speedStarted = true;
	}
		
	void SpeedTimerFinished(){
		if (speedStarted){
			direction = rb2d.velocity.normalized;
			ballImpulseForce = ConfigurationUtils.BallImpulseForce;
			SetDirection (direction);
		}
	}

	//StartTimerDelegates
	void StartTimerFinish(){
		if (started) {
//			ballSpawner.SpawnBall();
			spawnBallsEvent.Invoke();
			Destroy (gameObject);
		}
		else if (!started) {
			ballDirectionAngle = Random.Range (Mathf.PI / 4f, 3f * Mathf.PI / 4f);
			direction = new Vector2 (Mathf.Cos (ballDirectionAngle), Mathf.Sin (ballDirectionAngle)).normalized;
			rb2d.AddForce (ballImpulseForce * direction, ForceMode2D.Impulse);
			started = true;
			startTimer.Duration = ballLifetime;
			startTimer.Run ();
		}
	}

	public void OnBecameInvisible(){
		if (gameObject.transform.position.y < ScreenUtils.ScreenBottom) {
			Debug.Log ("Ball OnBecameInvisible()");
			countBallsEvent.Invoke ();
		}

		Destroy (gameObject);
	}

	public void SetDirection(Vector2 direction){
		rb2d.velocity = ballImpulseForce * direction;
	}


	public void AddCountBallsListener(UnityAction listener){
		countBallsEvent.AddListener (listener);
	}

	public void AddSpawnBallsListener(UnityAction listener){
		spawnBallsEvent.AddListener (listener);
	}
}
