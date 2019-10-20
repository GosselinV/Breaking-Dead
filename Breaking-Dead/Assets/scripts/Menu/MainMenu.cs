using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	Vector3 pos;

	void Start(){

		Debug.Log (GameData.themeSongIsPlaying);

		if (!GameData.themeSongIsPlaying) {
			AudioSource themeSongAudioSource = (AudioSource)GameObject.FindGameObjectWithTag ("themesong").GetComponent<AudioSource> ();
			themeSongAudioSource.volume = 0.5f;
			themeSongAudioSource.Play ();

		}
		for (int i = 0; i < 4; i++) {
			pos = new Vector3 ((Screen.width / 2), Screen.height * (10f - (float)(2 * i + 1)) / 10f, 0);
			transform.GetChild (i).GetComponent<RectTransform> ().position = pos;
		}
		Debug.Log (GameData.themeSongIsPlaying);
	}


	public void PlayButtonHandle(){
		AudioManager.Play (AudioClipName.RestartEvent);
		SceneManager.LoadScene ("Gameplay");
	}

	public void HelpButtonHandle(){
		MenuManager.mainMenu = gameObject;
		MenuManager.GoToMenu (MenuName.Help, MenuName.Main);
		gameObject.SetActive (false);


		//		GameObject infoMenu = GameObject.Instantiate (Resources.Load ("prefab/INFO"));
//		infoMenu.GetComponent<InfoMenu> ().Name = MenuName.Main;
		//Destroy (gameObject);
	}

	public void QuitButtonHande(){
		Application.Quit ();
	}
}
