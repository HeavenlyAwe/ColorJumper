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

	private Vector3 cameraPosition;
	private Vector3 midPostion;
	public Vector3 meanCenterPoint;
	
	private float distanceBetweenCameraNmidpoint;
	//	private float distanceBetweenPlayers1n2;
	
	//distance between player3 n distanceBetweenPlayers1n2
	private float distanceBetweenPlayer3n12;
	
	public float zoomLevel;
	public float smooth=200;

	public int playerAmount ;

	public Vector3 cameraPos;

	public Vector3 cameraPosFix;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//start of a game zoom out view //not working anymore
		camera.fieldOfView = Mathf.Lerp (camera.fieldOfView,100, Time.deltaTime * smooth);


		
		if(GameObject.Find("Player1")!= null){
			player1 = GameObject.Find("Player1");
			player1position = player1.transform.position;
		}
		
		if(GameObject.Find("Player2") != null){
			player2 = GameObject.Find("Player2"); 
			player2position = player2.transform.position;
			playerAmount = 2;
		}
		
		if(GameObject.Find("Player3")!= null){
			player3 = GameObject.Find("Player3"); 
			player3position = player3.transform.position;
			playerAmount = 3;
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

		if (playerAmount == 4) {
		
//			float m = (player1position.x-player4position.x)/(player1position.y-player4position.y);
//			float constant = player4position.y - m*player4position.x;
//			//equation for 1 and 4 is 
//			player4position.y = player4position.x
//
//
//
//			float m2 = (player2position.x-player3position.x)/(player2position.y-player3position.y);
//			//equation for 1 and 4 is 
//			float constant2 = player3position.y - m*player3position.x;
//            

			meanCenterPoint = (player1position+player2position+player3position+player4position)/4;

			//moving the cameras coordinates according to players position
			cameraPos = new Vector3 (meanCenterPoint.x-20, meanCenterPoint.y * 50, meanCenterPoint.z-200);
			//cameraPos = cameraBoundaries();
			camera.transform.position = Vector3.Lerp (transform.position, cameraPos, Time.deltaTime * smooth);



			//zooming camera in and out according to players position
			camera.fieldOfView = Mathf.Lerp (camera.fieldOfView, zoomLevel, Time.deltaTime * smooth);

		}
	 
	 		
	}

//	Vector3 cameraBoundaries(int i){
//		Level level = GetComponent<Level>();
//	 	
//		if(cameraPos.x<0){
//			cameraPosFix = new Vector3(cameraPos.x+50,cameraPos.y,cameraPos.z);	}
//		if (cameraPos.x > level.width) {
//			cameraPosFix = new Vector3(cameraPos.x-50,cameraPos.y,cameraPos.z);			
//		}
//		if(cameraPos.z <0){
//			cameraPosFix = new Vector3(cameraPos.x,cameraPos.y,cameraPos.z+50);	}
//		if (cameraPos.z > level.height) {
//			cameraPosFix = new Vector3(cameraPos.x,cameraPos.y,cameraPos.z-50);	}
//		} 
//}
}
