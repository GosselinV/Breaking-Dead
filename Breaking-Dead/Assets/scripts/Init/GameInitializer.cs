using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{

	LevelLoader levelLoader;
    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
        // initialize screen utils
		ScreenUtils.Initialize();
		ZombieSprites.Initialize ();
		ConfigurationUtils.Initialize ();
	}

	void Start(){
		levelLoader = Camera.main.GetComponent<LevelLoader> ();
		levelLoader.LoadTiles ();
			
	}


}
