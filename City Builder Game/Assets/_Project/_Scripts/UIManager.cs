using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : SingletonGenerics<UIManager>
{
    #region Variables
    [Header("References")]
    [Space(8)]

    //References for our UI Containers.
    public StandardUIReference wood_UI;
    public StandardUIReference stone_UI;
    public StandardUIReference standardC_UI;
    public StandardUIReference premiumC_UI;
    ResourceManager rm;
    #endregion

    #region Start()
    private void Start()
    {
        rm = ResourceManager.Instance;
        UpdateAll();
    }
    #endregion

    #region UpdateUIReference()
    /// <summary>
    /// Updates the UIRef Value
    /// </summary>
    /// <param name="uIRef">sets the uIReference</param>
    /// <param name="currentValue">sets the current value of uIReference slider and text</param>
    /// <param name="maxValue">sets the max value of uIReference slider and text</param>
    public void UpdateUIReference(StandardUIReference uIRef, int currentValue, int maxValue)
    {
        //set the text in the UI.
        uIRef.currentUI.text = currentValue.ToString();
        uIRef.maxUI.text ="Max: " + maxValue.ToString();

        //set the slider.
        uIRef.slider.maxValue = maxValue;
        uIRef.slider.value = currentValue;
    }
    #endregion

    #region UpdateAll()
    private void UpdateAll()
    {
        UpdateUIReference(wood_UI, rm.Wood, rm.maxWood);
        UpdateUIReference(stone_UI, rm.Stone, rm.maxStone);
        UpdateUIReference(premiumC_UI, rm.PremiumC, rm.maxPremiumC);
        UpdateUIReference(standardC_UI, rm.StandardC, rm.maxStandardC);
    }
    #endregion


    #region StandardUIReference Serializable class
    //Main class for setting up UI Containers.
    [System.Serializable]
    public class StandardUIReference
    {
        public Slider slider;
        public TextMeshProUGUI maxUI;
        public TextMeshProUGUI currentUI;
    }
    #endregion
}
