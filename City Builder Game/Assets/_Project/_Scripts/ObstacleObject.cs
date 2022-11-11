using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    #region Variables
    public ObstacleType obstacleType;
    public int resourceAmount = 10;

    private TileObject refTile;

    private ResourceManager resourceManager;
    private UIManager uIManager;
    #endregion

    #region Start()
    private void Start()
    {
        uIManager = UIManager.Instance;
        resourceManager = ResourceManager.Instance;
    }
    #endregion

    #region OnMouseDown()
    /// <summary>
    /// This is a Method that it is called whenEver the item has been clicked or tapped.
    /// Works on Mobile or PC.
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log("Clicked On " + gameObject.name);
        bool usedResource = false;
        //OnClickEvent

        //We can call directly the method that adds the Resource.
        switch (obstacleType)
        {
            case ObstacleType.Wood:
                usedResource = resourceManager.AddWood(resourceAmount);
                //ResourceManager.Instance.AddWood(resourceAmount);
                //usedResource = ResourceManager.Instance.AddResource(uIManager.wood_UI, ResourceManager.Instance.Wood, ResourceManager.Instance.maxWood, resourceAmount);
                break;

            case ObstacleType.Rock:
                usedResource = resourceManager.AddStone(resourceAmount);
                //ResourceManager.Instance.AddStone(resourceAmount);
                //usedResource = resourceManager.AddResource(resourceManager.uIManager.stone_UI, resourceManager.Stone, resourceManager.maxStone, resourceAmount);
                break;
        }
        if (usedResource)
        {
            refTile.tileData.CleanTile();
            Destroy(gameObject);
        }
        else Debug.Log("Could not Destroy cause Inventory is Full");
    }
    #endregion

    #region SetTileReference()
    public void SetTileReference(TileObject tObj)
    {
        refTile = tObj;
    }
    #endregion


    #region enum ObstacleType
    public enum ObstacleType
    {
        Wood,
        Rock
    }
    #endregion
}