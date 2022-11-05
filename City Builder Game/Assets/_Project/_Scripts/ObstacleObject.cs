using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public ObstacleType obstacleType;
    public int resourceAmount = 10;

    private ResourceManager resourceManager;
    private UIManager uIManager;

    private void Start()
    {
        uIManager = UIManager.Instance;
        resourceManager = ResourceManager.Instance;
    }
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
        if (usedResource) Destroy(gameObject);
        else Debug.Log("Could not Destroy cause Inventory is Full");
    }

    public enum ObstacleType
    {
        Wood,
        Rock
    }
}