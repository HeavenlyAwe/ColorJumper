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

	public GameObject[] players;
	public int playerAmount = 2;


	public AudioSource deathSound1;

	// Use this for initialization
	void Start () {	
		setupPlayers ();
		setupLevel ();
	}

	private void setupPlayers(){
		players = new GameObject[playerAmount];
		for (int i = 0; i < playerAmount; i++) {
			Vector3 playerPosition = new Vector3(i*10, 10, i*10);
			players[i] = (GameObject)Instantiate(Resources.Load ("Player"), playerPosition, Quaternion.identity);
			players[i].name = "Player" + (i+1);
		}
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
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	public GameObject getTile(int x, int z) {
		return tiles[x, z];
	}
}
