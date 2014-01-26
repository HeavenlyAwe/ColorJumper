using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	// Instance to the tile object
	// public GameObject tile;

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
		spawnPoints[i] = (GameObject) Instantiate (Resources.Load ("SpawnPoint"), playerPosition, Quaternion.identity);
	}

	private void setupLevel(){
		tiles = new GameObject[width, height];
		for (int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++){
				Vector3 pos = new Vector3(i * (tileWidth + tileOffset), 0, j * (tileHeight + tileOffset));
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

	private void setupSounds(){
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

	public void playDeathSound() {
		AudioSource source = gameObject.AddComponent<AudioSource> ();
		source.clip = deathSounds[UnityEngine.Random.Range(0, deathSounds.Length)];
		source.loop = false;
		source.Play ();
	}

	public void playChangeColorSound() {
		AudioSource source = gameObject.AddComponent<AudioSource> ();
		source.clip = changeColorSounds [UnityEngine.Random.Range (0, changeColorSounds.Length)];
		source.loop = false;
		source.Play ();
	}

	public void playJumpSound() {
		AudioSource source = gameObject.AddComponent<AudioSource> ();
		source.clip = jumpSound;
		source.loop = false;
		source.Play ();
	}
}
