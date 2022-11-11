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
                GameManager.Instance.SpawnBuilding(GameManager.Instance.buildingToPlace, this);
                tileData.SetOccupied(Tile.ObstacleType.Building);
            }
            else
            {
                Debug.Log("building to place is NULL");
            }
        }
    }
    #endregion
}
