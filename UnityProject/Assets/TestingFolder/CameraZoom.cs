using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour {
	
	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	
	private Vector3 player1position;
	private Vector3 player2position;
	private Vector3 player3position;
	private Vector3 player4position; 

	private Vector3 midPostion;
	public Vector3 meanCenterPoint;
	
	private float distanceBetweenCameraNmidpoint;
	//	private float distanceBetweenPlayers1n2;
	
	//distance between player3 n distanceBetweenPlayers1n2
	private float distanceBetweenPlayer3n12;
	
	public float zoomLevel=400;
	public float smooth=200;
	
	public int playerAmount ;
	
	public Vector3 cameraPos;
	
	public Vector3 cameraPosFix;

	public float  y;


	Level level;

	public float dist1;
	public float dist2;
	float dist3;
	float dist4;
	//Level level;
	Vector3 boardMidPoint;

	public Vector3 dist;

	void Start () {
	//	camera.transform.position (60f, 200f, -125f);
		level = GetComponent<Level> ();
		var w = ((level.width+10)/2);
		var h = ((level.height+10)/2);
		boardMidPoint = new Vector3(w, 0f,h); 
	}
	
	// Update is called once per frame
	void Update () {
		
		 level = GetComponent<Level> ();

		if(GameObject.Find("Player1")!= null){
			player1 = GameObject.Find("Player1");
			player1position = player1.transform.position;
		}
		
		if(GameObject.Find("Player2") != null){
			player2 = GameObject.Find("Player2"); 
			player2position = player2.transform.position;
			playerAmount = 2;
			
			dist1 = Vector3.Distance(player1position,player2position);
		}
		
		if(GameObject.Find("Player3")!= null){
			player3 = GameObject.Find("Player3"); 
			player3position = player3.transform.position;
			playerAmount = 3;
			
			dist2 = Vector3.Distance(player1position,player3position);
		}
		
		
		if(GameObject.Find("Player4")!= null){
			player4 = GameObject.Find("Player4"); 
			player4position = player4.transform.position;
			playerAmount = 4;
		}
		
		
		///Find the midpoint to fixate the camera according to players position
		if (playerAmount == 1) {
			meanCenterPoint = player1position;
			//moving the cameras coordinates according to players position
			Vector3 cameraPos = new Vector3 (meanCenterPoint.x+50, meanCenterPoint.y * 50, meanCenterPoint.z+50);
			camera.transform.position = Vector3.Lerp (transform.position, cameraPos, Time.deltaTime * smooth);
			
			//zooming camera in and out according to players position
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView, zoomLevel, Time.deltaTime * smooth);
		}
		
		if (playerAmount == 2) {
			meanCenterPoint = (player1position+player2position)/2;
			//moving the cameras coordinates according to players position
			Vector3 cameraPos = new Vector3 (meanCenterPoint.x-20, meanCenterPoint.y * 50, meanCenterPoint.z-50);
			camera.transform.position = Vector3.Lerp (transform.position, cameraPos, Time.deltaTime * smooth);
			
			//zooming camera in and out according to players position
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView, zoomLevel, Time.deltaTime * smooth);
		}
		
		if (playerAmount == 3) {
			midPostion = (player1position + player2position) / 2;
			meanCenterPoint = (player3position + midPostion) / 2;  
			
			//zoomLevel = midpositionBetweenPlayer3n12/5;
			
			//moving the cameras coordinates according to players position
			Vector3 cameraPos = new Vector3 (meanCenterPoint.x-20, meanCenterPoint.y * 50, meanCenterPoint.z-50);
			camera.transform.position = Vector3.Lerp (transform.position, cameraPos, Time.deltaTime * smooth);
			
			//zooming camera in and out according to players position
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView, zoomLevel, Time.deltaTime * smooth);
		}

		bool h;
		  
		if (playerAmount == 4   ) {

			meanCenterPoint = (player1position+player2position+player3position+player4position)/4;
			meanCenterPoint.y = (float)200;
			//moving the cameras coordinates according to players position
 
			cameraPos = new Vector3 (meanCenterPoint.x, 200, meanCenterPoint.z-200);
			 			
		 	camera.transform.position = Vector3.Lerp (transform.position, cameraPos, Time.deltaTime * smooth);

			 //zooming camera in and out according to players position
		 

			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView,30,(float)0.1); 
			  
		} 
		//center
		dist = new Vector3 (dist1/2,0f,dist2/2);
		var distanc1 = Vector3.Distance (player1position, dist);
		if (distanc1 < 50) {
						camera.fieldOfView = Mathf.Lerp (camera.fieldOfView, 20, (float)0.1); 

//						float tiltAroundX = 60;
//						Quaternion target = Quaternion.Euler (tiltAroundX, 0, 0);
//						camera.transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * 2.0F);
//						camera.transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y, camera.transform.position.z + 10);
//						h = false;
				} 
	//	else {
	//		h = true;
//		}


		var distanc2 = Vector3.Distance (player2position, dist);
		if ( distanc2 < 50) {
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView,20,(float)0.1); 
		}

		var distanc3 = Vector3.Distance (player3position, dist);
		if ( distanc3 < 50) {
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView,20,(float)0.1); 
		}

		var distanc4 = Vector3.Distance (player4position, dist);
		if ( distanc4 < 50) {
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView,20,(float)0.1); 
		}


	} 
}
