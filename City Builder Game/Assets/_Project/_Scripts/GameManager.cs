using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Builder")]
    [Space(8)]
    public GameObject tilePrefab;
    public int levelWidth;
    public int levelLength;

    public Transform tilesContainer;
    public float tileSize = 1;
    public float tileEndHeight = 1;


    [Header("Resources")]
    [Space(8)]

    public GameObject woodPrefab;
    public GameObject rockPrefab;

    [Range(0, 1)]
    public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;

    private void Start()
    {
        CreateLevel();
    }
    /// <summary>
    /// Create our grid depending on our level width and length.
    /// </summary>
    public void CreateLevel()
    {
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                TileObject spawnedTile = SpawnTile(x * tileSize, z * tileSize);
                if (x < xBounds || z < zBounds || z >= (levelLength - zBounds) || x >= (levelWidth - xBounds))
                {
                    // We can spawn an obstacles in there.
                    spawnedTile.data.StarterTileValue(false);
                }

                if (spawnedTile.data.canSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;
                    if (spawnObstacle)
                    {
                        //Handle the Spawning Obstacle functionality.
                        //Debug.Log("Spawned Obstacle on " + spawnedTile.gameObject.name);

                        //Debug Delete Later
                        //spawnedTile.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                        spawnedTile.data.SetOccupied(Tile.ObstacleType.Resource);
                        SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);
                    }
                }
            }
        }
    }
    /// <summary>
    /// Spawns and return a tileObject.
    /// </summary>
    /// <param name="xPos">X Position inside the World</param>
    /// <param name="zPos">Z Position inside the World</param>
    /// <returns></returns>
    private TileObject SpawnTile(float xPos, float zPos)
    {
        //This will spawn the tile.
        GameObject tempTile = Instantiate(tilePrefab);
        tempTile.transform.position = new Vector3(xPos, 0f, zPos);
        tempTile.transform.SetParent(tilesContainer);

        tempTile.name = "Tile " + xPos + " - " + zPos;
        //Check if the tile is able to hold an Obstacle.

        //TODO: Make this to not get a Component.
        return tempTile.GetComponent<TileObject>();
    }

    /// <summary>
    /// Will spawn a Resources directly in the CoOrdinates.
    /// </summary>
    /// <param name="xPos">X position of the Obstacle</param>
    /// <param name="zPos">Z position of the Obstacle</param>
    public void SpawnObstacle(float xPos, float zPos)
    {
        //It has the 50% chance of spawning a Wood Obstacle.
        bool isWood = Random.value <= 0.5f;

        GameObject spawnedObstacle = null;

        //check whether we spawn a Wood Obstacle or a Stone Obstacle
        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
        }
        else
        {
            spawnedObstacle = Instantiate(rockPrefab);
        }
        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);

    }
}
