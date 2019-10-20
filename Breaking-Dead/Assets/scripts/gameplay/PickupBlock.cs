using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupBlock : Block {

	#region fields

	[SerializeField]
	PickupEffect effect;
//	float freezeTime; 
//	float speedupTime;
	FreezerEffectActivated freezerEffectActivated; 
	SpeedupEffectActivated speedupEffectActivated;

	#endregion

	#region properties

	public PickupEffect Effect
	{
		get {return effect;}
		set { 
			if (value == PickupEffect.Freezer) {
				effect = value;
//				freezeTime = ConfigurationUtils.FreezeTime;
				freezerEffectActivated = new FreezerEffectActivated();
				EventManager.AddFreezerInvoker (this);
			} else if (value == PickupEffect.Speedup) {
				effect = value;
//				speedupTime = ConfigurationUtils.SpeedupTime;
				speedupEffectActivated = new SpeedupEffectActivated ();
				EventManager.AddSpeedupInvoker (this);
			}
		}
	}

	#endregion

	#region methods
	// Use this for initialization
	protected override void Start () {
		points = ConfigurationUtils.PickupBlockPoint;
		base.Start(); 
	}

	public void AddFreezerEffectListener(UnityAction listener){
		freezerEffectActivated.AddListener(listener); 
	}
		
	public void AddSpeedupEffectListener(UnityAction listener){
		speedupEffectActivated.AddListener (listener);
	}

	protected override void OnCollisionEnter2D(Collision2D col){
		if (effect == PickupEffect.Freezer) {
			freezerEffectActivated.Invoke ();
		} else if (effect == PickupEffect.Speedup) {
			speedupEffectActivated.Invoke ();
		}
		base.OnCollisionEnter2D (col);
	}
	#endregion
}
