using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Building
{
    #region Variables
    //Building ID for Referencing the exact type of Building.
    public int BuildingID;

    //Width X Axis that will be used inside the Grid.
    public int Width = 0;

    //Length Z Axis that will be used inside the Grid.
    public int Length = 0;

    //visual of the building.
    public GameObject buildingModel;

    //small padding in case the building is clipping through the floor.
    public float yPadding = 0;
    //Type of Functionality of the Building.
    public ResourceType resourceType = ResourceType.None;

    public StorageType storageType = StorageType.None;

    //[HideInInspector]
    public BuildingObject refOfBuilding;

    #endregion

    #region ResourceType enum
    public enum ResourceType
    {
        None,
        Standard,
        Premium,
        Storage
    }
    #endregion

    #region StorageType enum
    public enum StorageType
    {
        None,
        Wood,
        Rock
    }

    #endregion
}
