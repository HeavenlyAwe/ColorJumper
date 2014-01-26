 using UnityEngine;
using System.Collections;

public class MenuScreen : MonoBehaviour {
	public Texture2D logo;
	public Texture2D startB;
	public Texture2D tutorialB;
	public GUIStyle startStyle;
	public GUIStyle tutorialStyle;
	private float space = 50;

	private float logoWidth = 1470;
	private float logoHeight = 680;

	private float startWidth = 512;
	private float startHeight = 210;

	private float tutorialWidth = 512;
	private float turoialHeight = 127;

	private bool choosePlayer = false;
	private bool seeTutorial = false;

	void Start () {

		if (Screen.width <= 2048) {
			space = 30;
			logoWidth = logoWidth/3;
			logoHeight = logoHeight/3;
			startWidth = startWidth/2;
			startHeight = startHeight/2;
			turoialHeight = turoialHeight/2;
			tutorialWidth = tutorialWidth/2;
		}
	}

	void OnGUI () {

		if (GUI.Button (new Rect (Screen.width/ 2 - logoWidth/2, space, logoWidth, logoHeight), logo, "")) {
		}
		if (!choosePlayer && !seeTutorial) {
			if (GUI.Button (new Rect (Screen.width / 2 - startWidth / 2, space * 2 + logoHeight, startWidth, startHeight), "", startStyle)) {
				choosePlayer = true;
			}
			if (GUI.Button (new Rect (Screen.width / 2 - tutorialWidth / 2, space * 3 + logoHeight + startHeight, tutorialWidth, turoialHeight), "", tutorialStyle)) {
				seeTutorial = true;
			}
		}

		if (seeTutorial) {
			if (GUI.Button(new Rect (Screen.width/2 - 150, space*1 + logoHeight, 300, 250), "This is tutorial picture")) {
				seeTutorial = false;
			}
		}

		if (choosePlayer) {
			if (GUI.Button(new Rect (Screen.width/2 - 100,space + logoHeight, 200, 50), "How many players?")) {
			}
			if (GUI.Button(new Rect(Screen.width/2 - 250 - 50, space * 2 + logoHeight + 50, 100, 100), "Player1")) { 
				Debug.Log("Player 1 chosen");
			}
			if (GUI.Button(new Rect(Screen.width/2 - 100 - 50, space * 2 + logoHeight + 50, 100, 100), "Player2")) { 
				Debug.Log("Player 2 chosen");
			}
			if (GUI.Button(new Rect(Screen.width/2 + 100 - 50, space * 2 + logoHeight + 50, 100, 100), "Player3")) {
				Debug.Log("Player 3 chosen");
			}
			if (GUI.Button(new Rect(Screen.width/2 + 250 - 50, space * 2 + logoHeight + 50, 100, 100), "Player4")) {
				Debug.Log("Player 4 chosen");
			}
			if (GUI.Button(new Rect (Screen.width/2 - startWidth/4 ,space * 3 + logoHeight + 150, startWidth/2, startHeight/2), "", startStyle)) {
				Debug.Log("start game!");
			}
		}
	}
}
