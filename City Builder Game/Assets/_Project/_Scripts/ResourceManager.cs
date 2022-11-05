using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UIManager;

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

    internal UIManager uIManager;

    private static ResourceManager instance;
    public static ResourceManager Instance { get { return instance; } }

    #region Encapsulated Values
    public int Wood { get => wood; set => wood = value; }
    public int Stone { get => stone; set => stone = value; }
    public int PremiumC { get => premiumC; set => premiumC = value; }
    public int StandardC { get => standardC; set => standardC = value; }
    #endregion
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

    private void Start()
    {
        uIManager = UIManager.Instance;
    }

    private void Update()
    {
        if (debugBool)
        {
            PrintCurrentResources();
            debugBool = false;
        }
    }

    public int GetWood()
    {
        return wood;
    }

    public int GetStone()
    {
        return stone;
    }

    // not working
    ///// <summary>
    ///// Adds more currentResourceRef to the Inventory.
    ///// </summary>
    ///// <param name="standardUIReference"></param>
    ///// <param name="currentResourceRef"></param>
    ///// <param name="maxresourceRef"></param>
    ///// <param name="amount">Amount to add directly to our existing currentResourceRef</param>
    ///// <returns></returns>
    //public bool AddResource(StandardUIReference standardUIReference, int currentResourceRef, int maxresourceRef, int amount)
    //{
    //    if ((currentResourceRef + amount) <= maxresourceRef)
    //    {
    //        currentResourceRef += amount;
    //        //TODO: Update the wood UI to show the correct amount of wood.
    //        //Updates the corresponding UI.
    //        uIManager.UpdateUIReference(standardUIReference, currentResourceRef, maxresourceRef);
    //        return true;
    //    }
    //    return false;
    //}


    // working
    /// <summary>
    /// Adds more Wood to the Inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing Wood</param>
    public bool AddWood(int amount)
    {
        if ((Wood + amount) <= maxWood)
        {
            Wood += amount;
            //TODO: Update the wood UI to show the correct amount of wood.
            //Updates the corresponding UI.
            uIManager.UpdateUIReference(uIManager.wood_UI, Wood, maxWood);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Adds more Stone to the Inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing Stone</param>
    public bool AddStone(int amount)
    {
        if ((Stone + amount) <= maxStone)
        {
            Stone += amount;
            //TODO: Update the stone UI to show the correct amount of stone.
            //Updates the corresponding UI.
            uIManager.UpdateUIReference(uIManager.stone_UI, Stone, maxStone);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Adds more premiumC to the Inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing premiumC</param>
    public bool AddpremiumC(int amount)
    {
        if ((premiumC + amount) <= maxPremiumC)
        {
            PremiumC += amount;
            //TODO: Update the premiumC UI to show the correct amount of premiumC.
            //Updates the corresponding UI.

            uIManager.UpdateUIReference(uIManager.premiumC_UI, PremiumC, maxPremiumC);
            return true;
        }
        return false;

    }
    /// <summary>
    /// Adds more standardC to the Inventory.
    /// </summary>
    /// <param name="amount">Amount to add directly to our existing standardC</param>
    public bool AddstandardC(int amount)
    {
        if ((standardC + amount) <= maxStandardC)
        {
            StandardC += amount;
            //TODO: Update the standardC UI to show the correct amount of standardC.
            //Updates the corresponding UI.

            uIManager.UpdateUIReference(uIManager.standardC_UI, StandardC, maxStandardC);
            return true;
        }
        return false;

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
        Debug.Log("Wood " + Wood);
        Debug.Log("Stone " + Stone);
        Debug.Log("Premium " + PremiumC);
        Debug.Log("Standard " + StandardC);
    }
}
