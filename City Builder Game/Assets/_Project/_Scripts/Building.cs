using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    //Building ID for Referencing the exact type of Building.
    public int BuildingID;

    //Width X Axis that will be used inside the Grid.
    public int Width = 0;

    //Length Z Axis that will be used inside the Grid.
    public int Length = 0;

    //Type of Functionality of the Building.
    public ResourceType resourceType = ResourceType.None;

    public enum ResourceType
    {
        None,
        Standard,
        Premium
    }
}
