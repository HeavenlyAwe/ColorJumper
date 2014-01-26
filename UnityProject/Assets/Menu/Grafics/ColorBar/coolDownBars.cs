using UnityEngine;
using System.Collections;

public class coolDownBars : MonoBehaviour {

	public Texture2D colorball;
	public Texture2D colorBallD;// <-death
	public Texture2D colorShiny;
	public Texture2D colorBarEmpthy; // <- death
	public Texture2D colorBarFull;

	public static float MAX_COOLDOWN = 300.0f;

	public float spacer = 20;

	public float barDisplayWidthPlayer1;
	public float barDisplayWidthPlayer2;
	public float barDisplayWidthPlayer3;
	public float barDisplayWidthPlayer4;
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size;
	public Rect value;
	float fullBarWidth;
	float cooldownSpeed = 300.0f;
	float scale = 0.33f;
	Level level;

	void Start () {
		size = new Vector2 (colorBarFull.width * scale, colorBarFull.height * scale);
		value = new Rect(20,40, colorBarEmpthy.width * scale, colorBarEmpthy.height * scale);
		fullBarWidth = colorBarFull.width * scale;
		barDisplayWidthPlayer1 = fullBarWidth;
		barDisplayWidthPlayer2 = fullBarWidth;
		barDisplayWidthPlayer3 = fullBarWidth;
		barDisplayWidthPlayer4 = fullBarWidth;

		level = GameObject.Find ("Level").GetComponent<Level> ();
	}

	void Update() {
		level.players[0].GetComponent<PlayerInformation> ().coolDownLeft -= Time.deltaTime * cooldownSpeed;
		level.players[1].GetComponent<PlayerInformation> ().coolDownLeft -= Time.deltaTime * cooldownSpeed;
		level.players[2].GetComponent<PlayerInformation> ().coolDownLeft -= Time.deltaTime * cooldownSpeed;
		level.players[3].GetComponent<PlayerInformation> ().coolDownLeft -= Time.deltaTime * cooldownSpeed;

		barDisplayWidthPlayer1 = Mathf.Max(0, (level.players[0].GetComponent<PlayerInformation> ().coolDownLeft / MAX_COOLDOWN) * fullBarWidth);
		barDisplayWidthPlayer2 = Mathf.Max(0, (level.players[1].GetComponent<PlayerInformation> ().coolDownLeft / MAX_COOLDOWN) * fullBarWidth);
		barDisplayWidthPlayer3 = Mathf.Max(0, (level.players[2].GetComponent<PlayerInformation> ().coolDownLeft / MAX_COOLDOWN) * fullBarWidth);
		barDisplayWidthPlayer4 = Mathf.Max(0, (level.players[3].GetComponent<PlayerInformation> ().coolDownLeft / MAX_COOLDOWN) * fullBarWidth);

		// dead players have empty bar:
		if (!level.players [0].GetComponent<PlayerInformation> ().isAlive) {
			barDisplayWidthPlayer1 = fullBarWidth;
		}

		if (!level.players [1].GetComponent<PlayerInformation> ().isAlive) {
			barDisplayWidthPlayer2 = fullBarWidth;
		}

		if (!level.players [2].GetComponent<PlayerInformation> ().isAlive) {
			barDisplayWidthPlayer3 = fullBarWidth;
		}

		if (!level.players [3].GetComponent<PlayerInformation> ().isAlive) {
			barDisplayWidthPlayer4 = fullBarWidth;
		}
	}

	void OnGUI () {
		// player 1 cooldown bar
		GUI.BeginGroup (new Rect (spacer, spacer, colorBarFull.width * scale, colorBarFull.height * scale));
		GUI.DrawTexture (new Rect(0, 0, fullBarWidth, colorBarFull.height * scale ), colorBarFull);
		GUI.DrawTexture (new Rect(0, 0, barDisplayWidthPlayer1, colorBarFull.height * scale ), colorBarEmpthy);
		GUI.DrawTexture (new Rect(fullBarWidth -colorball.width * scale, 0,colorball.width * scale, colorball.height * scale), colorball);

		if (!level.players [0].GetComponent<PlayerInformation> ().isAlive) {
			GUI.DrawTexture (new Rect (fullBarWidth - colorball.width * scale, 0, colorShiny.width * scale, colorShiny.height * scale), colorBallD);
		}

		GUI.DrawTexture (new Rect(fullBarWidth -colorball.width * scale, 0,colorShiny.width * scale, colorShiny.height * scale), colorShiny);
		GUI.EndGroup ();

		// player 2 cooldown bar
		GUI.BeginGroup (new Rect (Screen.width - spacer - fullBarWidth, spacer, colorBarFull.width * scale, colorBarFull.height * scale));
		GUI.DrawTexture (new Rect(0, 0, fullBarWidth, colorBarFull.height * scale ), colorBarFull);
		GUI.DrawTexture (new Rect(0, 0, barDisplayWidthPlayer2, colorBarFull.height * scale ), colorBarEmpthy);
		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorball.width * scale, colorball.height * scale), colorball);

		if (!level.players [1].GetComponent<PlayerInformation> ().isAlive) {
			GUI.DrawTexture (new Rect (fullBarWidth - colorball.width * scale, 0, colorShiny.width * scale, colorShiny.height * scale), colorBallD);
		}

		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorShiny.width * scale, colorShiny.height * scale), colorShiny);
		GUI.EndGroup ();

		// player 3 cooldown bar
		GUI.BeginGroup (new Rect (spacer, Screen.height - spacer - colorBarFull.height * scale, colorBarFull.width * scale, colorBarFull.height * scale));
		GUI.DrawTexture (new Rect(0, 0, fullBarWidth, colorBarFull.height * scale ), colorBarFull);
		GUI.DrawTexture (new Rect(0, 0, barDisplayWidthPlayer3, colorBarFull.height * scale ), colorBarEmpthy);
		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorball.width * scale, colorball.height * scale), colorball);

		if (!level.players [2].GetComponent<PlayerInformation> ().isAlive) {
			GUI.DrawTexture (new Rect (fullBarWidth - colorball.width * scale, 0, colorShiny.width * scale, colorShiny.height * scale), colorBallD);
		}

		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorShiny.width * scale, colorShiny.height * scale), colorShiny);
		GUI.EndGroup ();

		// player 4 cooldown bar
		GUI.BeginGroup (new Rect (Screen.width - spacer - fullBarWidth, Screen.height - spacer - colorBarFull.height * scale, colorBarFull.width * scale, colorBarFull.height * scale));
		GUI.DrawTexture (new Rect(0, 0, fullBarWidth, colorBarFull.height * scale ), colorBarFull);
		GUI.DrawTexture (new Rect(0, 0, barDisplayWidthPlayer4, colorBarFull.height * scale ), colorBarEmpthy);
		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorball.width * scale, colorball.height * scale), colorball);

		if (!level.players [3].GetComponent<PlayerInformation> ().isAlive) {
			GUI.DrawTexture (new Rect (fullBarWidth - colorball.width * scale, 0, colorShiny.width * scale, colorShiny.height * scale), colorBallD);
		}

		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorShiny.width * scale, colorShiny.height * scale), colorShiny);
		GUI.EndGroup ();
	}
}
