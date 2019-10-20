using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {

	GameObject standardBlock;
	GameObject bonusBlock;
	GameObject pickupBlock;
	GameObject paddle; 

	int rows;

	// Use this for initialization
	void Awake () {
		paddle = (GameObject)Instantiate(Resources.Load("prefabs/paddle"));	
		rows = 3;	
	}

	public void LoadTiles()
	{
		standardBlock = (GameObject)Instantiate (Resources.Load ("prefabs/StandardBlock"));
		float tileColliderWidth = standardBlock.GetComponent<BoxCollider2D> ().size.x * standardBlock.transform.localScale[0];
		float tileColliderHeight = standardBlock.GetComponent<BoxCollider2D> ().size.y * standardBlock.transform.localScale[1];
		int numTiles = (int)Mathf.Floor((ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / tileColliderWidth);
		float tileSpace = (ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft) / (float)numTiles;
		Destroy (standardBlock);

		for (int j = 0; j<rows; j++){
			for (int i = 0; i < numTiles; i++) {
				Vector3 position = new Vector3 (ScreenUtils.ScreenLeft + (1 + 2 * i) * tileSpace / 2, ScreenUtils.ScreenTop - ScreenUtils.ScreenTop/5f - (j+1f/2f)*tileColliderHeight, 0);
				SpawnBlock(ChoseBlock (), position);

			}

		}
	}

	string ChoseBlock(){
		int whichBlock = Random.Range (0, 10);
		//switch (whichBlock) {
		//case(0):
		if (whichBlock == 0) {
			return "prefabs/BonusBlock";
		} else if (whichBlock == 1) {
//			SpawnBlock ("prefabs/PickupBlock", new Vector3(0,0,0);
//			break;
//		case(1):
			return "prefabs/PickupBlock";
		} else {
//			break;
//		default:
			return "prefabs/StandardBlock";
		}
			//			break;	
	}	

	void SpawnBlock(string blockStr, Vector3 position){
		GameObject block = (GameObject)Instantiate (Resources.Load (blockStr), position, Quaternion.identity);
		if (blockStr == "prefabs/StandardBlock") {			
			int whichSprite = Random.Range (0, 5);
			switch (whichSprite) {
			case(0):
				block.GetComponent<SpriteRenderer> ().sprite = ZombieSprites.sprites [ZombieSprites.SpritesName.z1];
				break;
			case(1):
				block.GetComponent<SpriteRenderer> ().sprite = ZombieSprites.sprites [ZombieSprites.SpritesName.z2];
				break;
			case(2):
				block.GetComponent<SpriteRenderer> ().sprite = ZombieSprites.sprites [ZombieSprites.SpritesName.z3];
				break;
			case(3):
				block.GetComponent<SpriteRenderer> ().sprite = ZombieSprites.sprites [ZombieSprites.SpritesName.z4];
				break;
			case(4):
				block.GetComponent<SpriteRenderer> ().sprite = ZombieSprites.sprites [ZombieSprites.SpritesName.z5];
				break;
			}
		} else if (blockStr == "prefabs/PickupBlock") {
			int whichSprite = Random.Range (0, 2);
			switch (whichSprite) {
			case(0):
				block.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/speeder");
				block.GetComponent<PickupBlock> ().Effect = PickupEffect.Speedup;
				break;
			case(1):
				block.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("sprites/freezer");
				block.GetComponent<PickupBlock> ().Effect = PickupEffect.Freezer;
				break;
			}

		}
	}
}
