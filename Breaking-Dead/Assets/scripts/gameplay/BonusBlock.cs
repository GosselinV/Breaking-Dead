using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block {

	// Use this for initialization
	protected override void Start () {
		points = ConfigurationUtils.BonusBlockPoint;
		base.Start(); 
	}
		
	override protected void OnCollisionEnter2D(Collision2D col){
		AudioManager.Play (AudioClipName.DestroyBonusBlockEvent);
		base.OnCollisionEnter2D (col);
	}
}
