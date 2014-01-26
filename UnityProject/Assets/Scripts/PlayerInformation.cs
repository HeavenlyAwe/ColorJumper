using UnityEngine;
using System.Collections;

public class PlayerInformation : MonoBehaviour {

	public PlatformInformation.PlatformColor color;
	public bool isAlive;
	public bool isSpawning;
	public bool isDying;
	public float coolDownLeft;

	// Use this for initialization
	void Start () {
		isAlive = true;
		isSpawning = true;
		coolDownLeft = coolDownBars.MAX_COOLDOWN;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
