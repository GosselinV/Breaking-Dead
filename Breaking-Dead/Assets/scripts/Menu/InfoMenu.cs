using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMenu : MonoBehaviour {

	#region fields

	float spacing;
	float width;
	float height;
	float heightOffset;
	float widthOffset;
	float xpos;
	float ypos;
	Vector3 translate;
	MenuName name;

	#endregion

	#region properties

	public MenuName Name{
		set { name = value; }
	}

	#endregion

	void Start(){
		spacing = 75f; 
		Transform background = transform.GetChild (0);
		Transform backButton = transform.GetChild (1);
	
			
		width = background.GetComponent<RectTransform>().rect.width;
		if (width > Screen.width) {
			width = Screen.width;
		}
		widthOffset = (Screen.width - transform.GetChild(0).GetComponent<RectTransform>().rect.width)/2f;

		height = background.GetComponent<RectTransform> ().rect.height;
		if (height > Screen.height) {
			height = Screen.height;
		}
		heightOffset = backButton.GetComponent<RectTransform>().rect.height/2f;

		translate = new Vector3 (0, height / 2f - heightOffset - spacing, 0);
		backButton.transform.Translate (translate);

		ypos = backButton.transform.position.y - transform.GetChild(2).GetComponent<RectTransform>().rect.height/2f - spacing;
		xpos = widthOffset;

		for (int i = 2; i <= 7; i++) {
			xpos += spacing;
//			xpos += transform.GetChild (i).GetComponent<RectTransform> ().rect.width / 2f;
			translate = new Vector3(xpos, ypos, 0);
			transform.GetChild (i).transform.position = translate;

		}

		ypos -= transform.GetChild(8).GetComponent<RectTransform>().rect.height/2f;
		xpos = widthOffset;

		for (int i = 8; i <= 9; i++) {
			xpos += spacing;
//			xpos += transform.GetChild (i).GetComponent<RectTransform> ().rect.width / 2f;
			translate = new Vector3( xpos, ypos, 0);
			transform.GetChild (i).transform.position = translate;

		}

		ypos -= transform.GetChild(10).GetComponent<RectTransform>().rect.height/2f;
		xpos = widthOffset;

		for (int i = 10; i <= 11; i++) {
			xpos += spacing;
//			xpos += transform.GetChild (i).GetComponent<RectTransform> ().rect.width / 4f;
			translate = new Vector3(xpos, ypos, 0);
			transform.GetChild (i).transform.position = translate;
		}

		ypos -= transform.GetChild(12).GetComponent<RectTransform>().rect.height/2f;
		xpos = widthOffset;
		for (int i = 12; i <= 13; i++) {
			xpos += spacing;
//			xpos+= transform.GetChild (i).GetComponent<RectTransform> ().rect.width / 4f;
			translate = new Vector3(xpos, ypos, 0);
			transform.GetChild (i).transform.position = translate;

		}
	}

	public void BackButtonHandle(){
		if (name == MenuName.Main) {
			MenuManager.mainMenu.SetActive(true);
		} else {
			MenuManager.GoToMenu (name);
		}
		Destroy (gameObject);
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			BackButtonHandle ();
		}
	}
}
