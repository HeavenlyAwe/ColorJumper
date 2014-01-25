using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

	// Instance to the tile object
	public GameObject tile;

	// The grid of the level
	public GameObject[,] tiles;
	public int width = 10;
	public int height = 10;

	public float tileOffset = 0.5f;

	// Use this for initialization
	void Start () {
	
		tile.transform.position = new Vector3 (0, -50, 0);

		tiles = new GameObject[width, height];
		for (int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++){
				tiles[i, j] = (GameObject) Instantiate(tile);
				tiles[i, j].transform.localScale.Set(tile.transform.localScale.x, 0, tile.transform.localScale.z);
				tiles[i, j].name = "Tile_x" + i + "_y" + j;
			}
		}
	
		// Just hiding the original tile, otherwise it'll be placed on the first tile... I can't figure out how to delete it...
		tile.renderer.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				tiles[i,j].transform.position = new Vector3(i * (tile.transform.localScale.x + tileOffset), 0, j * (tile.transform.localScale.z + tileOffset));
			}
		}

	}

	public GameObject getTile(int x, int z) {
		return tiles[x, z];
	}
}
