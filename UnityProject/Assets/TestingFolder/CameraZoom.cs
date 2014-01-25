using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	private Vector3 player1position;
	private Vector3 player2position;
	private Vector3 cameraPosition;
	private Vector3 midPostion;

	private float distanceBetweenCameraNmidpoint;
	private float distanceBetweenPlayers;

	public float zoomSpeed;
	public float smooth=5;

	// Use this for initialization
	void Start () {
	
		player1 = GameObject.FindGameObjectWithTag ("Player1");
		player2 = GameObject.FindGameObjectWithTag ("Player2"); 
	}
	
	// Update is called once per frame
	void Update () {
 
		player1position = player1.transform.position;
		player2position = player2.transform.position;

	
		 
		midPostion = (player1position + player2position) / 2;
		distanceBetweenCameraNmidpoint = Vector3.Distance (Camera.main.transform.position, midPostion);

		distanceBetweenPlayers = Vector2.Distance (player1position, player2position);

//		if (distanceBetweenPlayers > 0)
//		{
	 		zoomSpeed = distanceBetweenPlayers / 10;


	 		camera.fieldOfView=Mathf.Lerp(camera.fieldOfView,zoomSpeed,Time.deltaTime*smooth);
	 
// 	    }

	
	
	}
}
