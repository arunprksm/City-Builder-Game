using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    #region Variables
    public Tile tileData;

    [Header("World Tile Data")]
    [Space(8)]

    //Position of the Tile.
    public int xPos = 0;
    public int zPos = 0;
    #endregion

    #region OnMouseDown()
    private void OnMouseDown()
    {
        //Debug.Log("Clicked on " +gameObject.name);

        if (!tileData.IsOccupied)
        {
            if (GameManager.Instance.buildingToPlace != null)
            {
                List<TileObject> iteratedTiles = new List<TileObject>();
                //flag for checking if we are able to build in here.
                bool canPlaceBuildingHere = true;

                try
                {
                    //Checking adjacent tiles.
                    for (int x = xPos; x < xPos + GameManager.Instance.buildingToPlace.buildingData.Width; x++)
                    {
                        if (canPlaceBuildingHere)
                        {
                            for (int z = zPos; z < zPos + GameManager.Instance.buildingToPlace.buildingData.Length; z++)
                            {
                                iteratedTiles.Add(GameManager.Instance.tileGrid[x, z]);
                                if (GameManager.Instance.tileGrid[x, z].tileData.IsOccupied)
                                {
                                    canPlaceBuildingHere = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            //canPlaceBuildingHere &= GameManager.Instance.tileGrid[x, z].tileData.IsOccupied;
                            break;
                        }
                    }
                }
                catch (System.IndexOutOfRangeException)
                {
                    Debug.Log("There were No Tiles");
                    return;
                }


                if (canPlaceBuildingHere)
                {
                    GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, iteratedTiles);
                }
                else
                {
                    Debug.Log("Could Not place Building");
                }
            }
            else
            {
                Debug.Log("building to place is NULL");
            }
        }
    }
    #endregion
}
