using UnityEngine;
using System.Collections;

public class InformationPasser : MonoBehaviour {

	void Awake() {
		gameObject.transform.parent.gameObject.GetComponent<PlatformInformation> ().tileObject = gameObject;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
