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

	// Use this for initialization
	void Start () {
	
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
	
	// Update is called once per frame
	void Update () {
		/*
		for (int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				tiles[i,j].transform.position = new Vector3(i * (tile.transform.localScale.x + tileOffset), 0, j * (tile.transform.localScale.z + tileOffset));
			}
		}
		*/

	}

	public GameObject getTile(int x, int z) {
		return tiles[x, z];
	}
}
