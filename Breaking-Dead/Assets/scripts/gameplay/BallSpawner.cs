using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

	#region fields

	//work variables
	float spawnTime;
	float minSpawnTime; 
	float maxSpawnTime;

	// dummy ball object to get collider radius
 	GameObject ball;
	float ballColliderRadius;
	float paddleHeight;

	// to check for spawn free zone
	Vector2 ballLocation;

	// to randomly spawn balls. 
	Timer spawnTimer;

	//GameOver support
	GameOverEvent gameOverEvent; 

	#endregion

	#region methods

	/// <summary>
	/// Get collider radius and start spawnTimer.
	/// </summary>
	void Start(){
		minSpawnTime = ConfigurationUtils.MinSpawntime;
		maxSpawnTime  = ConfigurationUtils.MaxSpawnTime;
		// spawn initial ball and get collider radius for spawnball() method. 
		ball = Instantiate((GameObject)Resources.Load("prefabs/ball"));
		ballColliderRadius = ball.GetComponent<CircleCollider2D> ().radius;
		paddleHeight = GameObject.FindGameObjectWithTag ("paddle").GetComponent<BoxCollider2D> ().size.y;

		// start ball spawning timer
		spawnTimer = gameObject.AddComponent<Timer>();
		spawnTimer.AddTimerFinishedListener (SpawnBall);
		spawnTimer.AddTimerFinishedListener (StartTimer);
		StartTimer ();

		// SpawnBalls event support
		EventManager.AddCountBallsListener(SpawnBall);
		EventManager.AddSpawnBallsListener (SpawnBall);

	}

		
	//Randomize timer duration for spawning balls
	void StartTimer(){
		spawnTime = Random.Range (minSpawnTime, maxSpawnTime);
		spawnTimer.Duration = spawnTime;
		spawnTimer.Run ();
	}

	//Spawn balls in random, free locations
	void SpawnBall(){
		bool spawned = false;
		while (!spawned) {
			float randY = Random.Range (ScreenUtils.ScreenBottom + paddleHeight, ScreenUtils.ScreenTop);
			float randX = Random.Range (ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
			ballLocation = new Vector2 (randX, randY);
			if (Physics2D.OverlapCircle (ballLocation, ballColliderRadius) == null) {
				Instantiate ((GameObject)Resources.Load ("prefabs/ball"), ballLocation, Quaternion.identity);
				spawned = true;
				spawnTime = Random.Range (minSpawnTime, maxSpawnTime);
			}
		}
	}


	#endregion
}
