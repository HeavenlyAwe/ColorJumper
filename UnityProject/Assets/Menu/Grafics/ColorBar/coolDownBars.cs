using UnityEngine;
using System.Collections;

public class coolDownBars : MonoBehaviour {

	public Texture2D colorball;
	public Texture2D colorBallD;
	public Texture2D colorShiny;
	public Texture2D colorBarEmpthy;
	public Texture2D colorBarFull;

	public float spacer = 20;

	public float barDisplay;
	public Vector2 pos = new Vector2(20,40);
	public Vector2 size;
	public Rect value;

	void Start () {
		size = new Vector2 (colorBarFull.width/3, colorBarFull.height/3);
		value = new Rect(20,40, colorBarEmpthy.width/3, colorBarEmpthy.height/3);
	}

	void Update() {
		barDisplay = Time.time * 0.5f;
	}

	void OnGUI () {
		GUI.BeginGroup (new Rect (spacer, spacer, colorBarFull.width / 3, colorBarFull.height / 3));
		GUI.Label (new Rect(0, 0,colorBarFull.width/3, colorBarFull.height/3 ), colorBarFull, "");
		GUI.Label (new Rect(0, 0,colorBarFull.width/3 * barDisplay, colorBarFull.height/3 ), colorBarEmpthy, "");
		GUI.Label (new Rect(colorBarFull.width/3 -colorball.width/3, 0,colorball.width/3, colorball.height/3), colorball, "");
		GUI.Label (new Rect(colorBarFull.width/3 -colorball.width/3, 0,colorShiny.width/3, colorShiny.height/3), colorShiny, "");
		GUI.EndGroup ();

		GUI.BeginGroup (new Rect (Screen.width - spacer - colorBarFull.width/3, spacer, colorBarFull.width / 3, colorBarFull.height / 3));
		GUI.Label (new Rect(0, 0,colorBarFull.width/3, colorBarFull.height/3 ), colorBarFull, "");
		GUI.Label (new Rect(colorBarFull.width/3 -colorball.width/3, 0,colorball.width/3, colorball.height/3), colorball, "");
		GUI.Label (new Rect(colorBarFull.width/3 -colorball.width/3, 0,colorShiny.width/3, colorShiny.height/3), colorShiny, "");
		GUI.EndGroup ();

		GUI.BeginGroup (new Rect (spacer, Screen.height - spacer - colorBarFull.height/3, colorBarFull.width / 3, colorBarFull.height / 3));
		GUI.Label (new Rect(0, 0,colorBarFull.width/3, colorBarFull.height/3 ), colorBarFull, "");
		GUI.Label (new Rect(colorBarFull.width/3 -colorball.width/3, 0,colorball.width/3, colorball.height/3), colorball, "");
		GUI.Label (new Rect(colorBarFull.width/3 -colorball.width/3, 0,colorShiny.width/3, colorShiny.height/3), colorShiny, "");
		GUI.EndGroup ();
		
		GUI.BeginGroup (new Rect (Screen.width - spacer - colorBarFull.width/3, Screen.height - spacer - colorBarFull.height/3, colorBarFull.width / 3, colorBarFull.height / 3));
		GUI.Label (new Rect(0, 0,colorBarFull.width/3, colorBarFull.height/3 ), colorBarFull, "");
		GUI.Label (new Rect(colorBarFull.width/3 -colorball.width/3, 0,colorball.width/3, colorball.height/3), colorball, "");
		GUI.Label (new Rect(colorBarFull.width/3 -colorball.width/3, 0,colorShiny.width/3, colorShiny.height/3), colorShiny, "");
		GUI.EndGroup ();
	}
}
