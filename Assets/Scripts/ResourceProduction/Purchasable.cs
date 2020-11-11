using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Purchasable : MonoBehaviour
{
    public Text buttonLabel;

    Data data;
    string productionID;

    bool isAffordable => data.getActualCosts(Amount).isAffordable;
 public int Amount
    {
        get => PlayerPrefs.GetInt(data.name + " " + productionID, 0);
        set => PlayerPrefs.SetInt(data.name + " " + productionID, value);

    }

    public void SetUp(Data d, string productid)
    {
        data = d;
        productionID = productid;
        UpdateCostLabel();
    }
    public void Purchase()
    {
        if (!isAffordable)
        {
            return;
        }

        data.getActualCosts(Amount).Consume();
        Amount += 1;
        UpdateCostLabel();
    }
    void UpdateCostLabel()
    {
        var updatedCosts = data.getActualCosts(Amount);
        buttonLabel.text = "Add " + productionID + " for " + updatedCosts;
    }

    public void Update() => UpdateTextColor();

    void UpdateTextColor() => buttonLabel.color = isAffordable ? Color.black : Color.red;
    
}
