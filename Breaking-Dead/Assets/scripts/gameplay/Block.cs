using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Block.
/// </summary>
public class Block : MonoBehaviour {

	#region fields
	protected int points; 
	HUD hud; 
	protected PointsAddedEvent pointAddedEvent;
	BlockDestroyEvent blockDestroyedEvent;

	#endregion

	#region properties

	protected int Points
	{
		get { return points; }
	}

	#endregion

	#region methods

	protected virtual void Start(){
		//hud = GameObject.FindGameObjectWithTag ("HUD").GetComponent<HUD>();
		pointAddedEvent = new PointsAddedEvent();
		blockDestroyedEvent = new BlockDestroyEvent();
		EventManager.AddPointsInvoker (this);
		EventManager.BlockDestroyedInvoker (this);
	}

	virtual protected void OnCollisionEnter2D(Collision2D col){
		//hud.Score (points);
		pointAddedEvent.Invoke(points);
		blockDestroyedEvent.Invoke ();
		Destroy (gameObject);
	}

	public void AddpointAddedListener(UnityAction<int> handle){
		pointAddedEvent.AddListener (handle);
	}

	public void AddBlockDestroyedListener(UnityAction listener){
		blockDestroyedEvent.AddListener (listener);
	}

	#endregion
}
