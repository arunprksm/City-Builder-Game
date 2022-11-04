using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class ResourceManager : MonoBehaviour
{
    [Header("Resources")]
    [Space(8)]

    //sets the max amount of wood
    public int maxWood;
    private int wood = 0;

    //sets the max amount of stone
    public int maxStone;
    private int stone = 0;

    //sets the max amount of premiumCurrency
    public int maxPremiumC;
    private int premiumC = 0;

    //sets the max amount of standardCurrency
    public int maxStandardC;
    private int standardC = 0;


    private static ResourceManager instance;
    public static ResourceManager Instance { get { return instance; } }

    public bool debugBool = false;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (debugBool)
        {
            PrintCurrentResources();
            debugBool = false;
        }
    }

    /// <summary>
    /// Adds more Wood to the Inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing Wood</param>
    public void AddWood(int amount)
    {
        wood += amount;
        //TODO: Update the wood UI to show the correct amount of wood.
    }

    /// <summary>
    /// Adds more Stone to the Inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing Stone</param>
    public void AddStone(int amount)
    {
        stone += amount;
        //TODO: Update the stone UI to show the correct amount of stone.
    }

    /// <summary>
    /// Adds more premiumC to the Inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing premiumC</param>
    public void AddpremiumC(int amount)
    {
        premiumC += amount;
        //TODO: Update the premiumC UI to show the correct amount of premiumC.
    }
    /// <summary>
    /// Adds more standardC to the Inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing standardC</param>
    public void AddstandardC(int amount)
    {
        standardC += amount;
        //TODO: Update the standardC UI to show the correct amount of standardC.
    }

    //void OnDestroy()
    //{
    //    if (this == instance) 
    //    { 
    //        instance = null;
    //    }
    //}

    private void PrintCurrentResources()
    {
        Debug.Log("Wood " + wood);
        Debug.Log("Stone " + stone);
        Debug.Log("Premium " + premiumC);
        Debug.Log("Standard " + standardC);
    }
}
