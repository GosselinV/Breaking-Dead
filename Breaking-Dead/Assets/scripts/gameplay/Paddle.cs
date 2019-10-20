
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Paddle.
/// </summary>
public class Paddle : MonoBehaviour {

	#region fields
	// kinematic rigidbody2D
	Rigidbody2D rb2d;

	// dynamic rebound support
	float speed; 
	float halfColliderWidth;
	float halfColliderHeight;
	const float BounceAngleHalfRange = 60*Mathf.Deg2Rad;

	// Block events support
	bool frozen; 
	Timer freezeTimer; 
	#endregion

	#region methods
	// initialize fields
	void Start () {
		frozen = false;
		freezeTimer = GetComponent<Timer> (); 
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		speed = ConfigurationUtils.PaddleMoveUnitsPerSecond; 
		halfColliderWidth = gameObject.GetComponent<BoxCollider2D> ().size.x / 2f;
		halfColliderHeight = gameObject.GetComponent<BoxCollider2D> ().size.y / 2f;
		EventManager.AddFreezerListener (FreezePaddle);
	}

	// horizontal movement
	void FixedUpdate(){
		float hAxis = Input.GetAxis ("Horizontal");
		if (hAxis != 0) {
			if (!freezeTimer.Running) {
				Vector3 velocity = new Vector3 (Mathf.Sign (hAxis) * speed, 0, 0);
				Vector3 position = new Vector3 ();
				position = transform.position + velocity * Time.deltaTime;
				position.x = CalculateClampedX (position.x);
				rb2d.MovePosition (position);
			}
		}
	}

	// clamp to screen
	float CalculateClampedX(float x){
		if (x + halfColliderWidth >= ScreenUtils.ScreenRight) {
			return ScreenUtils.ScreenRight - halfColliderWidth;
		} else if (x - halfColliderWidth <= ScreenUtils.ScreenLeft) {
			return ScreenUtils.ScreenLeft + halfColliderWidth;
		} else {
			return x;
		}
	}

	// ball collisions support
	bool IsColOnTop(Collision2D coll){
		if (coll.gameObject.CompareTag("ball")){
			if (coll.gameObject.transform.position.y > gameObject.transform.position.y+halfColliderHeight){
				return true;
			}
		}

		return false;
	}

	/// <summary>
	/// Detects collision with a ball to aim the ball
	/// </summary>
	/// <param name="coll">collision info</param>
	void OnCollisionEnter2D(Collision2D coll)
	{
		AudioManager.Play (AudioClipName.paddle);
		if (IsColOnTop (coll)) {
			// calculate new ball direction
			float ballOffsetFromPaddleCenter = transform.position.x -
			                                   coll.transform.position.x;
			float normalizedBallOffset = ballOffsetFromPaddleCenter /
			                             halfColliderWidth;
			float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
			float angle = Mathf.PI / 2 + angleOffset;
			Vector2 direction = new Vector2 (Mathf.Cos (angle), Mathf.Sin (angle)).normalized;

			// tell ball to set direction to new direction
			Ball ballScript = coll.gameObject.GetComponent<Ball> ();
			ballScript.SetDirection (direction);
		}
	}

	public void FreezePaddle(){
		freezeTimer.Duration = ConfigurationUtils.FreezeTime;
		if (!freezeTimer.Running) {
			AudioManager.Play (AudioClipName.DestroyFreezeBlockEvent);
			freezeTimer.Run ();
		}
	}
	#endregion
}
