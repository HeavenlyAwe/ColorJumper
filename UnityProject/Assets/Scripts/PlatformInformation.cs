using UnityEngine;
using System.Collections;

public class PlatformInformation : MonoBehaviour {
	public enum PlatformColor {
		RED = 0,
		BLUE = 1,
		GREEN = 2,
		YELLOW = 3
	};

	public PlatformColor platformColor;
	public FadingEffect fadingEffect;
	public GameObject tileObject;

	// Use this for initialization
	void Start () {
		fadingEffect = GetComponentInChildren<FadingEffect> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
