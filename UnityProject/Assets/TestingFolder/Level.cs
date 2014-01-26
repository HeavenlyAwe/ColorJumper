using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	// Instance to the tile object
	// public GameObject tile;

	Material materialGreen;
	Material materialRed;
	Material materialBlue;
	Material materialYellow;

	// The grid of the level
	public GameObject[,] tiles;
	public int width = 10;
	public int height = 10;

	public int tileWidth = 10;
	public int tileHeight = 10;

	public float tileOffset = 0.5f;
	public float playerSpawnHeight = 15;

	public Camera camera;

	public GameObject[] players;
	public PlayerInformation[] playerInformations;
	private float[] deathTimers;	// used for managing respawns
	public float deathTimerMax = 2;
	private int[] respawnAmounts;
	public int respawnAmount;

	public int playerAmount = 2;
	private Vector3[] spawnCoordinates;
	public GameObject[] spawnPoints;
	private float[] spawnPointTimers;
	public float spawnPointTimerMax = 10;


	
	private AudioSource[] audioSource;

	private AudioClip[] deathSounds;
	public AudioClip deathSound1;
	public AudioClip deathSound2;
	// public AudioClip deathSound3;

	private AudioClip[] changeColorSounds;
	public AudioClip changeColor1;
	public AudioClip changeColor2;
	public AudioClip changeColor3;
	public AudioClip changeColor4;

	public AudioClip jumpSound;

	// Use this for initialization
	void Start () {
		materialGreen = (Material) Resources.Load ("Prefabs/Materials/character_green");
		materialRed = (Material) Resources.Load ("Prefabs/Materials/character_red");
		materialBlue = (Material) Resources.Load ("Prefabs/Materials/character_blue");
		materialYellow = (Material) Resources.Load ("Prefabs/Materials/character_yellow");

		setupLevel ();
		setupSounds ();
		setupPlayers ();
	}

	private void setupPlayers(){
		spawnCoordinates = new Vector3[4];
		spawnCoordinates [0] = new Vector3 (0, playerSpawnHeight, 0);
		spawnCoordinates [1] = new Vector3 (width * (tileWidth + tileOffset) - tileWidth, 20, 0);
		spawnCoordinates [2] = new Vector3 (0, 20, height * (tileHeight + tileOffset) - tileHeight);
		spawnCoordinates [3] = new Vector3(width * (tileWidth + tileOffset) - tileWidth, 20, height * (tileHeight + tileOffset) - tileHeight);

		players = new GameObject[playerAmount];
		playerInformations = new PlayerInformation[playerAmount];
		deathTimers = new float[playerAmount];
		respawnAmounts = new int[playerAmount];

		spawnPointTimers = new float[playerAmount];
		spawnPoints = new GameObject[playerAmount];

		for (int i = 0; i < playerAmount; i++) {
			spawnPlayer(i);
			respawnAmounts[i] = respawnAmount;
		}
	}

	private void spawnPlayer(int i){
		Vector3 playerPosition = spawnCoordinates[i];
		if (players [i] == null) {
			players[i] = (GameObject)Instantiate(Resources.Load ("Maincharacter"), playerPosition, Quaternion.identity);
			players[i].name = "Player" + (i+1);
			System.Array platformColorArray = System.Enum.GetValues(typeof(PlatformInformation.PlatformColor));
			players[i].GetComponent<PlayerInformation>().color = (PlatformInformation.PlatformColor)platformColorArray.GetValue(i);
			playerInformations[i] = players[i].GetComponent<PlayerInformation>();
		} else {
			players[i].transform.position = playerPosition;
			System.Array platformColorArray = System.Enum.GetValues(typeof(PlatformInformation.PlatformColor));
			players[i].GetComponent<PlayerInformation>().color = (PlatformInformation.PlatformColor)platformColorArray.GetValue(i);
		}
		playerInformations [i].isAlive = true;
		playerInformations [i].isSpawning = true;
		playerInformations [i].isDying = false;

		if (playerInformations[i].color == PlatformInformation.PlatformColor.RED) {
			players[i].GetComponentInChildren<SkinnedMeshRenderer>().renderer.material = materialRed;
		}
		else if (playerInformations[i].color == PlatformInformation.PlatformColor.BLUE) {
			players[i].GetComponentInChildren<SkinnedMeshRenderer>().renderer.material = materialBlue;
		}
		else if (playerInformations[i].color == PlatformInformation.PlatformColor.YELLOW) {
			players[i].GetComponentInChildren<SkinnedMeshRenderer>().renderer.material = materialYellow;
		}
		else if (playerInformations[i].color == PlatformInformation.PlatformColor.GREEN) {
			players[i].GetComponentInChildren<SkinnedMeshRenderer>().renderer.material = materialGreen;
		}

		spawnPoints[i] = (GameObject) Instantiate (Resources.Load ("SpawnPoint"), playerPosition, Quaternion.identity);
	}

	private void setupLevel(){
		tiles = new GameObject[width, height];
		for (int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++){
				Vector3 pos = new Vector3(i * (tileWidth + tileOffset), 0, j * (tileHeight + tileOffset));
				if (i == 0 && j == 0 && playerAmount >= 1 ||
				    i == width - 1 && j == 0 && playerAmount >= 2 ||
				    i == 0 && j == height - 1 && playerAmount >= 3 ||
				    i == width - 1 && j == height - 1 && playerAmount >= 4) {
					tiles[i, j] = (GameObject) Instantiate(Resources.Load ("Prefabs/Platform_SpawnPoint"), pos, Quaternion.identity);
					tiles[i, j].name = "Tile_x" + i + "_y" + j;
				} else if (i == Mathf.Round(width / 2) && j == Mathf.Round(height / 2)) {
						tiles[i, j] = (GameObject) Instantiate(Resources.Load ("Prefabs/Platform_Goal"), pos, Quaternion.identity);
					tiles[i, j].name = "Tile_x" + i + "_y" + j;
				} else {
					tiles[i, j] = (GameObject) Instantiate(Resources.Load ("Prefabs/Platform"), pos, Quaternion.identity);
					tiles[i, j].name = "Tile_x" + i + "_y" + j;

					// choose random color for the tile:
					PlatformInformation platformInfo = tiles[i,j].GetComponent<PlatformInformation>();
					System.Array platformColorArray = System.Enum.GetValues(typeof(PlatformInformation.PlatformColor));
					int randomColorNumber = UnityEngine.Random.Range(0, platformColorArray.Length);
					platformInfo.platformColor = (PlatformInformation.PlatformColor)platformColorArray.GetValue(randomColorNumber);


					Material material = (Material) Resources.Load ("Prefabs/Materials/platform_red");

					if (platformInfo.platformColor == PlatformInformation.PlatformColor.RED) {
						material = (Material) Resources.Load ("Prefabs/Materials/platform_red");
					}
					else if (platformInfo.platformColor == PlatformInformation.PlatformColor.BLUE) {
						material = (Material) Resources.Load ("Prefabs/Materials/platform_blue");
					}
					else if (platformInfo.platformColor == PlatformInformation.PlatformColor.YELLOW) {
						material = (Material) Resources.Load ("Prefabs/Materials/platform_yellow");
					}
					else if (platformInfo.platformColor == PlatformInformation.PlatformColor.GREEN) {
						material = (Material) Resources.Load ("Prefabs/Materials/platform_green");
					}

					platformInfo.tileObject.renderer.material = material;
				}
			}
		}
	}

	private void setupSounds(){
		audioSource = new AudioSource[10];
		for (int i = 0; i < audioSource.Length; i++){
			audioSource[i] = gameObject.AddComponent<AudioSource> ();
		}
		deathSounds = new AudioClip[]{deathSound1, deathSound2}; //, deathSound3};
		changeColorSounds = new AudioClip[]{changeColor1, changeColor2, changeColor3, changeColor4};
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = camera.transform.position;

		for (int i = 0; i < players.Length; i++) {
			if(!playerInformations[i].isAlive){
				deathTimers[i] += Time.deltaTime;
				if (deathTimers[i] >= deathTimerMax) {
					if(respawnAmounts[i] > 0){
						respawnAmounts[i]--;
						spawnPlayer(i);
						deathTimers[i] = 0;
					}
				}
			}

			spawnPointTimers[i] += Time.deltaTime;
			if(spawnPointTimers[i] >= spawnPointTimerMax){
				spawnPointTimers[i] = 0;
				Destroy(spawnPoints[i]);
			}
		}

	}

	public GameObject getTile(int x, int z) {
		return tiles[x, z];
	}

	public ArrayList getCurrentlyActiveColors() {
		ArrayList colors = new ArrayList();

		for (int i = 0; i < players.Length; i++) {

			if (players[i].GetComponent<PlayerInformation>().isAlive &&
			                     !colors.Contains(players[i].GetComponent<PlayerInformation>().color)) {
				colors.Add(players[i].GetComponent<PlayerInformation>().color);
			}
		}

		return colors;
	}

	public void playDeathSound(){
		for(int i=0; i < audioSource.Length; i++){
			if (audioSource[i] != null && !audioSource[i].isPlaying) {
				audioSource[i].clip = deathSounds [UnityEngine.Random.Range (0, deathSounds.Length)];
				audioSource[i].loop = false;
				audioSource[i].Play ();
			}
		}
	}

	public void playChangeColorSound() {
		for (int i=0; i < audioSource.Length; i++) {
			if (audioSource[i] != null && !audioSource[i].isPlaying) {
				audioSource[i].clip = changeColorSounds [UnityEngine.Random.Range (0, changeColorSounds.Length)];
				audioSource[i].loop = false;
				audioSource[i].Play ();
			}
		}
	}

	public void playJumpSound() {
		for(int i=0; i < audioSource.Length; i++){
			if (audioSource[i] != null && !audioSource[i].isPlaying) {
				audioSource[i].clip = jumpSound;
				audioSource[i].loop = false;
				audioSource[i].volume = 0.1f;
				audioSource[i].Play ();
			}
		}
	}
}
