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

	public GameObject player1;
	public GameObject player2;


	// Use this for initialization
	void Start () {	
		setupPlayers ();
		setupLevel ();
	}

	private void setupPlayers(){
		players = new GameObject[playerAmount];
		for (int i = 0; i < playerAmount; i++) {
			Vector3 playerPosition = new Vector3(i*10, 2, i*10);
			players[i] = (GameObject)Instantiate(Resources.Load ("Player"), playerPosition, Quaternion.identity);
			players[i].name = "Player" + (i+1);
		}
	}

	private void setupLevel(){
		tiles = new GameObject[width, height];
		for (int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++){
				Vector3 pos = new Vector3(i * (tileWidth + tileOffset), 0, j * (tileHeight + tileOffset));
				tiles[i, j] = (GameObject) Instantiate(Resources.Load ("Tile"), pos, Quaternion.identity);
				tiles[i, j].name = "Tile_x" + i + "_y" + j;
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
