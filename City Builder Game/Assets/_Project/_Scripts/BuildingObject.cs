using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuildingObject : MonoBehaviour
{
    public Building buildingData;

    [Header("Resource Generation")]
    [Space(8)]

    //This will be the resource that has been created.
    public float buildingResource = 0f;

    //Limit the this building can generate or do.
    public float buildingResourceLimit = 100f;

    //Speed that the resource is Generated.
    public float resourceGenerationSpeed = 5f;

    [Header("UI")]
    [Space(8)]

    public Canvas canvasGO;
    public Slider progressSlider;


    Coroutine buildingBehaviour;

    private void Start()
    {

        if (buildingData.resourceType == Building.ResourceType.Standard || buildingData.resourceType == Building.ResourceType.Premium)
        {
            buildingBehaviour = StartCoroutine(CreateResource());
        }

        if (buildingData.resourceType == Building.ResourceType.Storage)
        {
            canvasGO.gameObject.SetActive(false);
            IncreaseMaxStorage();
        }
    }

    IEnumerator CreateResource()
    {
        //It will create Resources Infinitely.
        while (true)
        {
            if (buildingResource < buildingResourceLimit)
            {
                buildingResource += resourceGenerationSpeed * Time.deltaTime;
                UIUpdate(buildingResource, buildingResourceLimit);
            }
            else
            {
                buildingResource = buildingResourceLimit;
            }
            yield return null;
        }
    }

    private void OnMouseDown()
    {
        if (buildingData.resourceType == Building.ResourceType.Storage)
        {
            return;
        }

        switch (buildingData.resourceType)
        {
            case Building.ResourceType.Standard:
                ResourceManager.Instance.AddstandardC((int) buildingResource);
                break;
            case Building.ResourceType.Premium:
                ResourceManager.Instance.AddpremiumC((int)buildingResource);
                break;
        }
        EmptyResource();
    }
    void EmptyResource()
    {
        buildingResource = 0;
    }
    
    private void IncreaseMaxStorage()
    {
        switch (buildingData.storageType)
        {
            case Building.StorageType.Wood:
                ResourceManager.Instance.IncreaseMaxWood((int) buildingResource);
                break;
            case Building.StorageType.Rock:
                ResourceManager.Instance.IncreaseMaxRock((int) buildingResource);
                break;
        }
        //UIUpdate(buildingResource, buildingResourceLimit);
    }

    public void UIUpdate(float curVal, float maxVal)
    {
        progressSlider.value = curVal;
        progressSlider.maxValue = maxVal;
    }
}