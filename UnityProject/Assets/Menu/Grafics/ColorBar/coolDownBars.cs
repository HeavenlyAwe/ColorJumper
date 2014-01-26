using UnityEngine;
using System.Collections;

public class coolDownBars : MonoBehaviour {

	public Texture2D colorball;
	public Texture2D colorBallD;// <-death
	public Texture2D colorShiny;
	public Texture2D colorBarEmpthy; // <- death
	public Texture2D colorBarFull;

	public float spacer = 20;

	public float barDisplayWidth;
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
		barDisplayWidth = fullBarWidth;

		level = GameObject.Find ("Level").GetComponent<Level> ();
	}

	void Update() {
		barDisplayWidth -= Time.deltaTime * cooldownSpeed;

		Debug.Log ("++++++++ " + barDisplayWidth);

		if (barDisplayWidth <= 0) {
			barDisplayWidth = 0;
		}
	}

	void OnGUI () {
		// player 1 cooldown bar
		GUI.BeginGroup (new Rect (spacer, spacer, colorBarFull.width * scale, colorBarFull.height * scale));
		GUI.DrawTexture (new Rect(0, 0, fullBarWidth, colorBarFull.height * scale ), colorBarFull);
		GUI.DrawTexture (new Rect(0, 0, barDisplayWidth, colorBarFull.height * scale ), colorBarEmpthy);
		GUI.DrawTexture (new Rect(fullBarWidth -colorball.width * scale, 0,colorball.width * scale, colorball.height * scale), colorball);

		if (!level.players [0].GetComponent<PlayerInformation> ().isAlive) {
			GUI.DrawTexture (new Rect (fullBarWidth - colorball.width * scale, 0, colorShiny.width * scale, colorShiny.height * scale), colorBallD);
		}

		GUI.DrawTexture (new Rect(fullBarWidth -colorball.width * scale, 0,colorShiny.width * scale, colorShiny.height * scale), colorShiny);
		GUI.EndGroup ();

		// player 2 cooldown bar
		GUI.BeginGroup (new Rect (Screen.width - spacer - fullBarWidth, spacer, colorBarFull.width * scale, colorBarFull.height * scale));
		GUI.DrawTexture (new Rect(0, 0, fullBarWidth, colorBarFull.height * scale ), colorBarFull);
		GUI.DrawTexture (new Rect(0, 0, barDisplayWidth, colorBarFull.height * scale ), colorBarEmpthy);
		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorball.width * scale, colorball.height * scale), colorball);

		if (!level.players [1].GetComponent<PlayerInformation> ().isAlive) {
			GUI.DrawTexture (new Rect (fullBarWidth - colorball.width * scale, 0, colorShiny.width * scale, colorShiny.height * scale), colorBallD);
		}

		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorShiny.width * scale, colorShiny.height * scale), colorShiny);
		GUI.EndGroup ();

		// player 3 cooldown bar
		GUI.BeginGroup (new Rect (spacer, Screen.height - spacer - colorBarFull.height * scale, colorBarFull.width * scale, colorBarFull.height * scale));
		GUI.DrawTexture (new Rect(0, 0, fullBarWidth, colorBarFull.height * scale ), colorBarFull);
		GUI.DrawTexture (new Rect(0, 0, barDisplayWidth, colorBarFull.height * scale ), colorBarEmpthy);
		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorball.width * scale, colorball.height * scale), colorball);

		if (!level.players [2].GetComponent<PlayerInformation> ().isAlive) {
			GUI.DrawTexture (new Rect (fullBarWidth - colorball.width * scale, 0, colorShiny.width * scale, colorShiny.height * scale), colorBallD);
		}

		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorShiny.width * scale, colorShiny.height * scale), colorShiny);
		GUI.EndGroup ();

		// player 4 cooldown bar
		GUI.BeginGroup (new Rect (Screen.width - spacer - fullBarWidth, Screen.height - spacer - colorBarFull.height * scale, colorBarFull.width * scale, colorBarFull.height * scale));
		GUI.DrawTexture (new Rect(0, 0, fullBarWidth, colorBarFull.height * scale ), colorBarFull);
		GUI.DrawTexture (new Rect(0, 0, barDisplayWidth, colorBarFull.height * scale ), colorBarEmpthy);
		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorball.width * scale, colorball.height * scale), colorball);

		if (!level.players [3].GetComponent<PlayerInformation> ().isAlive) {
			GUI.DrawTexture (new Rect (fullBarWidth - colorball.width * scale, 0, colorShiny.width * scale, colorShiny.height * scale), colorBallD);
		}

		GUI.DrawTexture (new Rect(fullBarWidth - colorball.width * scale, 0,colorShiny.width * scale, colorShiny.height * scale), colorShiny);
		GUI.EndGroup ();
	}
}
