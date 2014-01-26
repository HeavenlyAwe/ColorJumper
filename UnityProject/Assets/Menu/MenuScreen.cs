 using UnityEngine;
using System.Collections;

public class MenuScreen : MonoBehaviour {
	public Texture2D logo;
	public Texture2D startB;
	public Texture2D tutorialB;
	public GUIStyle startStyle;
	public GUIStyle tutorialStyle;
	public GUIStyle player1S;
	public GUIStyle player2S;
	public GUIStyle player3S;
	public GUIStyle player4S;
	public Texture2D players;
	public Texture2D tutorialTexture;
	private bool player1Selected;
	private bool player2Selected;
	private bool player3Selected;
	private bool player4Selected;
	public Texture2D player1Active;
	public Texture2D player1NotAct;
	public Texture2D player2Active;
	public Texture2D player2NotAct;
	public Texture2D player3Active;
	public Texture2D player3NotAct;
	public Texture2D player4Active;
	public Texture2D player4NotAct;
	private float space = 50;

	private float playerWidth = 128;
	private float playerHeight = 128;

	private float playersWidth = 512;
	private float playersHeight = 63;

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
			if (GUI.Button(new Rect (Screen.width/2 - tutorialTexture.width/4, space*1 + logoHeight/2, tutorialTexture.width/2, tutorialTexture.height/2), tutorialTexture, "")) {
				seeTutorial = false;
			}
		}

		if (choosePlayer) {
			if (GUI.Button(new Rect (Screen.width/2 - playersWidth/2,space + logoHeight, playersWidth, playersHeight), players ,"")) {
			}
			if (GUI.Button(new Rect(Screen.width/2 - 250 - 50, space * 2 + logoHeight + 50, playerWidth, playerHeight), "", player1S)) {
				player1Selected = !player1Selected;

				if (player1Selected) {
					player1S.normal.background = player1Active;
				}
				else {
					player1S.normal.background = player1NotAct;
				}
				Debug.Log("Player 1 chosen");
			}
			if (GUI.Button(new Rect(Screen.width/2 - 100 - 50, space * 2 + logoHeight + 50, playerWidth, playerHeight), "", player2S)) { 
				player2Selected = !player2Selected;
				
				if (player2Selected) {
					player2S.normal.background = player2Active;
				}
				else {
					player2S.normal.background = player2NotAct;
				}
				Debug.Log("Player 2 chosen");
			}
			if (GUI.Button(new Rect(Screen.width/2 + 100 - 50, space * 2 + logoHeight + 50, playerWidth, playerHeight), "", player3S)) {
				player3Selected = !player3Selected;
				
				if (player3Selected) {
					player3S.normal.background = player3Active;
				}
				else {
					player3S.normal.background = player3NotAct;
				}
				Debug.Log("Player 3 chosen");
			}
			if (GUI.Button(new Rect(Screen.width/2 + 250 - 50, space * 2 + logoHeight + 50, playerWidth, playerHeight), "", player4S)) {
				player4Selected = !player4Selected;
				
				if (player4Selected) {
					player4S.normal.background = player4Active;
				}
				else {
					player4S.normal.background = player4NotAct;
				}
				Debug.Log("Player 4 chosen");
			}
			if (GUI.Button(new Rect (Screen.width/2 - startWidth/4 ,space * 3 + logoHeight + 150, startWidth/2, startHeight/2), "", startStyle)) {
				Application.LoadLevel(0);
				Debug.Log("start game!");
			}
		}
	}
}
