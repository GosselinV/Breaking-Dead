using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
	}
	
	public void ResumeButtonHandle(){
		Time.timeScale = 1;
		Destroy (gameObject);
	}

	public void HelpButtonHandle(){
		MenuManager.GoToMenu (MenuName.Help);
		Destroy (gameObject);
	}

	public void MainMenuButtonHandle(){
		Time.timeScale = 1;
		MenuManager.GoToMenu (MenuName.Main);
	}


}
