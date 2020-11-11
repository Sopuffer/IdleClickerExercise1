using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResourceProducer : MonoBehaviour
{
    public Data data;
    public Text titleText;
    public FloatingText popupPrefab;
    public Purchasable amount;
    public Purchasable upgrade;
    float elapsedTime;

    public void Setup(Data d)
    {
        data = d;
        gameObject.name = data.name;
        amount.SetUp(data, "Count");
        upgrade.SetUp(data, "Level");

    }

    public void Purchase() => amount.Purchase();
    public void Upgrade() => upgrade.Purchase();
  

    void Update()
    {
        UpdateProduction();
        UpdateTitleLabel();
        amount.Update();
        upgrade.Update();
    }

    void UpdateProduction()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= data.productionTime)
        {
            Produce();
            elapsedTime -= data.productionTime;
        }

    }
    void UpdateTitleLabel()
    {
        titleText.text = ToString();
    }

    public override string ToString()
    {
        return amount.Amount + "x " + data.name + " Level " + upgrade.Amount; 
    }

    void Produce()
    {
        if(amount.Amount == 0)
        {
            return;
        }
        var productionAmount = data.getProductionAmount(upgrade.Amount, amount.Amount);
        productionAmount.Create();
        var instance = Instantiate(popupPrefab, transform);
        instance.GetComponent<Text>().text = productionAmount.ToString();
    }
}
