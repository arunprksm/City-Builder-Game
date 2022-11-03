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
                SpawnTile(x * tileSize, z * tileSize);
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
        tempTile.transform.position = new Vector3(xPos,0f, zPos);
        tempTile.transform.SetParent(tilesContainer);
        return tempTile.GetComponent<TileObject>();
    }

}
