using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile
{
    #region Variables
    //Building Reference for that each tile will have for each Building.
    public Building buildingRef;
    
    //Type of Obstacle occupied on the Tile.
    public ObstacleType obstacleType;

    private bool isStarterTile = true;
    #endregion


    #region ObstacleType is being ocupied
    //The Stuff that Tile is being ocupied by.
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }
    #endregion
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
