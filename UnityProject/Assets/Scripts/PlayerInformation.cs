using UnityEngine;
using System.Collections;

public class PlayerInformation : MonoBehaviour {

	public PlatformInformation.PlatformColor color;
	public bool isAlive;
	public bool isSpawning;
	public bool isDying;

	// Use this for initialization
	void Start () {
		isAlive = true;
		isSpawning = true;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
