using UnityEngine;
using System.Collections;

public class Examples : MonoBehaviour {

	public GameObject player;
	public Transform playersTrans;

	// Use this for initialization
	void Awake () {
		Debug.Log ("yay2");
	}

	void Start () {
		Debug.Log ("yay1");
	}

	void OnLevelWasLoaded(int arg) {
		Debug.Log ("yay3");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
