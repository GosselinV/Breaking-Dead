using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block {


	// Use this for initialization
	protected override void Start () {
		points = ConfigurationUtils.StdBlockPoint;
		base.Start(); 
	}

	override protected void OnCollisionEnter2D(Collision2D col){
		AudioManager.Play (AudioClipName.zombie4);
		base.OnCollisionEnter2D (col);
	}
}
