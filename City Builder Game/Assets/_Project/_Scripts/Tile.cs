using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    //Building Reference for that each tile will have for each Building.
    public Building buildingRef;


    //Type of Obstacle occupied on the Tile.
    public ObstacleType obstacleType;

    private bool isStarterTile = true;

    //The Stuff that Tile is being ocupied by.
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }
    #region Methods
    public void SetOccupied(ObstacleType t) => obstacleType = t;

    public void SetOccupied(ObstacleType t, Building b)
    {
        obstacleType = t;
        buildingRef = b;
    }

    public void CleanTile() => obstacleType = ObstacleType.None;
    
    public void StarterTileValue(bool value) => isStarterTile = value;

    #endregion

    #region Booleans
    /// <summary>
    /// Checking that, if Tile is occupied by something.
    /// </summary>
    public bool IsOccupied
    {
        get { return obstacleType != ObstacleType.None; }
    }
    /// <summary>
    /// Checking that, if Tile is not isStarterTile.
    /// </summary>
    public bool canSpawnObstacle
    {
        get { return !isStarterTile; }
    }
    #endregion
}
