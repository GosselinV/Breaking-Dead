using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager {

	public static GameObject mainMenu;

	public static void GoToMenu(MenuName menu, MenuName previous = MenuName.Pause, float time = 0f){

		switch (menu) {
		case(MenuName.Main):
			SceneManager.LoadScene ("MainMenu");
			break;
		case(MenuName.Pause):
			GameObject.Instantiate ((GameObject)Resources.Load ("prefabs/PauseMenu"));
			break;
		case(MenuName.Help):
			GameObject infoMenu = GameObject.Instantiate ((GameObject)Resources.Load ("prefabs/INFO"));
			infoMenu.GetComponent<InfoMenu> ().Name = previous;
			break;
		case(MenuName.GameOver):
			
			GameObject gameOverMenu = GameObject.Instantiate ((GameObject)Resources.Load ("prefabs/GameOverMenu"));
			gameOverMenu.GetComponent<GameOverMenu>().ClipTime = time;
			break;
		}

	}
}
