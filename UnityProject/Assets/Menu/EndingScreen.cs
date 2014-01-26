using UnityEngine;
using System.Collections;

public class EndingScreen : MonoBehaviour {

	public bool ending = false;
	public Texture2D retry;
	public Texture2D quit;
	public GUIStyle retryStyle;
	public GUIStyle quitStyle;

	void OnGUI () {
		if (ending) {
			if (GUI.Button(new Rect(Screen.width/2 - retry.width/4, Screen.height/2 - retry.height/2, retry.width/2, retry.height/2), "", retryStyle))
			{
				Debug.Log("retry game");
				Application.LoadLevel(0);
			}
			if (GUI.Button(new Rect(Screen.width/2 - quit.width/4, Screen.height/2 + 20, quit.width/2, quit.height/2), "", quitStyle)) {
				Application.Quit ();
				Debug.Log("quitgame");
			}
		}
	}
}
