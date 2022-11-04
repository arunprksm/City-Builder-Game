using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObject : MonoBehaviour
{
    public ObstacleType obstacleType;
    public int resourceAmount = 10;
    /// <summary>
    /// This is a Method that it is called whenEver the item has been clicked or tapped.
    /// Works on Mobile or PC.
    /// </summary>
    private void OnMouseDown()
    {
        Debug.Log("Clicked On " + gameObject.name);

        //OnClickEvent

        //We can call directly the method that adds the Resource.
        switch (obstacleType)
        {
            case ObstacleType.Wood:
                ResourceManager.Instance.AddWood(resourceAmount);
                break;
            case ObstacleType.Rock:
                ResourceManager.Instance.AddStone(resourceAmount);
                break;
        }
    }

    public enum ObstacleType
    {
        Wood,
        Rock
    }
}
