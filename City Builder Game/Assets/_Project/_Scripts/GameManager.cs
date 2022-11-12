using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonGenerics<GameManager>
{
    #region Variables
    [Header("Builder")]
    [Space(8)]
    public GameObject tilePrefab;
    public int levelWidth;
    public int levelLength;

    public Transform tilesContainer;
    public float tileSize = 1;
    public float tileEndHeight = 1;

    [Space(8)]
    //This is the Grid that directly stores the all of the information.
    public TileObject[,] tileGrid = new TileObject[0, 0];
    [Header("Resources")]
    [Space(8)]

    public GameObject woodPrefab;
    public GameObject rockPrefab;

    public Transform resourcesContainer;

    [Range(0, 1)]
    public float obstacleChance = 0.3f;

    public int xBounds = 3;
    public int zBounds = 3;

    [Space(8)]

    //Debug Method(Selected building).
    public BuildingObject buildingToPlace;
    #endregion
    #region Start
    private void Start()
    {
        CreateLevel();
    }
    #endregion

    #region CreateLevel()
    /// <summary>
    /// Create our grid depending on our level width and length.
    /// </summary>
    public void CreateLevel()
    {
        List<TileObject> visualGid = new List<TileObject>();
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                //Directly spwans a tile.
                TileObject spawnedTile = SpawnTile(x * tileSize, z * tileSize);

                //Sets the TileObject world space Data.
                spawnedTile.xPos = x;
                spawnedTile.zPos = z;

                //Checks Whenever we can spwan an Obstacle inside a tile, using the bounds (xBounds, zBounds) parameters.
                if (x < xBounds || z < zBounds || z >= (levelLength - zBounds) || x >= (levelWidth - xBounds))
                {
                    // We can spawn an obstacles in there.
                    spawnedTile.tileData.StarterTileValue(false);
                }

                if (spawnedTile.tileData.canSpawnObstacle)
                {
                    bool spawnObstacle = Random.value <= obstacleChance;
                    if (spawnObstacle)
                    {
                        spawnedTile.tileData.SetOccupied(Tile.ObstacleType.Resource);
                        ObstacleObject tmpObstacle = SpawnObstacle(spawnedTile.transform.position.x, spawnedTile.transform.position.z);
                        tmpObstacle.SetTileReference(spawnedTile);
                    }
                }
                //Adds the Spawned visual tileObject inside the List.
                visualGid.Add(spawnedTile);
            }
        }
        CreateGrid(visualGid);
    }
    #endregion

    #region SpawnTile()
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
    #endregion

    #region SpawnObstacle()

    /// <summary>
    /// Will spawn a Resources directly in the CoOrdinates.
    /// </summary>
    /// <param name="xPos">X position of the Obstacle</param>
    /// <param name="zPos">Z position of the Obstacle</param>
    ObstacleObject SpawnObstacle(float xPos, float zPos)
    {
        //It has the 50% chance of spawning a Wood Obstacle.
        bool isWood = Random.value <= 0.5f;

        GameObject spawnedObstacle = null;

        //check whether we spawn a Wood Obstacle or a Stone Obstacle
        if (isWood)
        {
            spawnedObstacle = Instantiate(woodPrefab);
            spawnedObstacle.name = "Wood " + xPos + " - " + zPos;
        }
        else
        {
            spawnedObstacle = Instantiate(rockPrefab);
            spawnedObstacle.name = "Rock " + xPos + " - " + zPos;
        }

        //sets the position and the parent of the spawned Resources.
        spawnedObstacle.transform.position = new Vector3(xPos, tileEndHeight, zPos);
        spawnedObstacle.transform.SetParent(resourcesContainer);

        return spawnedObstacle.GetComponent<ObstacleObject>();
    }
    #endregion

    #region CreateGrid()
    /// <summary>
    /// Create tile Grid to add the Buildings.
    /// </summary>
    public void CreateGrid(List<TileObject> refVisualGrid)
    {
        //set the size of Tile Grid.
        tileGrid = new TileObject[levelWidth, levelLength];


        //Iterates through all of the Tile Grid.
        for (int x = 0; x < levelWidth; x++)
        {
            for (int z = 0; z < levelLength; z++)
            {
                //Connects the tile grid directly to visual Grid.
                tileGrid[x, z] = refVisualGrid.Find(v => v.xPos == x && v.zPos == z);
                //Debug.Log(tileGrid[x, z].gameObject.name);
            }
        }
    }
    #endregion

    #region SpawnBuilding()

    /// <summary>
    /// Handles the placing system of the building.
    /// </summary>
    /// <param name="building">Building to Place</param>
    /// <param name="tile">Tile to place the building</param>
    /// 
    public void SpawnBuilding(BuildingObject building, List<TileObject> tiles)
    {
        float sumX = 0;
        float sumZ = 0;

        GameObject spawnedBuilding = Instantiate(building.gameObject);
        //old position
        //Vector3 pos = new Vector3(tile.xPos, tileEndHeight, tile.zPos);

        for (int i = 0; i < tiles.Count; i++)
        {

            //sum value of x positions of all tiles.
            //sum value of z positions of all tiles.
            sumX += tiles[i].xPos;
            sumZ += tiles[i].zPos;

            tiles[i].tileData.SetOccupied(Tile.ObstacleType.Building);
            Debug.Log("Placed Building in " + tiles[i].xPos + " - " + tiles[i].zPos);
        }

        //Sets the correct position.
        Vector3 pos = new Vector3((sumX / tiles.Count), building.buildingData.yPadding, (sumZ / tiles.Count));
        spawnedBuilding.transform.position = pos;
    }
    #endregion
}

//public void SpawnBuilding(BuildingObject building, TileObject tile)
    //{
    //    if (tile.tileData.IsOccupied && tile.tileData.obstacleType == Tile.ObstacleType.Building)
    //    {
    //        tileEndHeight++;
    //        tile.tileData.SetOccupied(Tile.ObstacleType.Building);
    //        GameObject spawnedBuilding = Instantiate(building.gameObject);
    //        Vector3 pos = new Vector3(tile.xPos, tileEndHeight, tile.zPos);
    //        spawnedBuilding.transform.position = pos;
    //    }
    //    else
    //    {
    //        tileEndHeight = 1;
    //        tile.tileData.SetOccupied(Tile.ObstacleType.Building);
    //        GameObject spawnedBuilding = Instantiate(building.gameObject);
    //        Vector3 pos = new Vector3(tile.xPos, tileEndHeight, tile.zPos);
    //        spawnedBuilding.transform.position = pos;
    //    }
    //}