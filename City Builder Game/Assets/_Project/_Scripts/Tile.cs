using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    //Building Reference for that each tile will have for each Building.
    public Building buildingRef;

    //Checking that, if Tile is occupied by something.
    public bool occupied;

    //Type of Obstacle occupied on the Tile.
    public ObstacleType obstacleType;

    //The Stuff that Tile is being ocupied by.
    public enum ObstacleType
    {
        None,
        Resource,
        Building
    }

    public void SetOccupied(ObstacleType t)
    {
        occupied = true;
        obstacleType = t;
    }
    public void SetOccupied(ObstacleType t, Building b)
    {
        occupied = true;
        obstacleType = t;
        buildingRef = b;
    }

    public void CleanTile()
    {
        occupied = true;
        obstacleType = ObstacleType.None;
    }
}
