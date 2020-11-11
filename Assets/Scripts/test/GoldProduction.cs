using System.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoldProduction : MonoBehaviour
{
  
    public GameObject floatingPressText;
    public GameObject floatingFountainText;
    public GameObject floatingFactoryText;
    PlayerScore ps;

    public int priceOnGoldPr;
    public int priceOnGoldFou;
    public int priceOnGoldFa;

    public int pricePressUpg;
    public int priceFountainUpg;
    public int priceFactoryUpg;

    public int pressGold;
    public int fountainGold;
    public int factoryGold;

    float costMultiplier = 1.1f;
    float costUpgradeMultiplier = 5f;

    float time;
    float maxTime = 0.5f;
    public float pressVal;
    public float fountainVal;
    public float factoryVal;

    public bool buttonActive;
    public bool canBuyGoldPress;
    public bool canBuyGoldFountain;
    public bool canBuyGoldFactory;
    public bool hasGoldPress;
    public bool hasGoldFountain;
    public bool hasGoldFactory;

    public bool canUpgradePress;
    public bool canUpgradeFountain;
    public bool canUpgradeFactory;

    public bool hasUpgradedPress;
    public bool hasUpgradedFountain;
    public bool hasUpgradedFactory;

    public Resources _gold;

    public int goldPresses = 0;
    public int goldFountains = 0;
    public int goldFactories = 0;

    int pressUpgrades = 0;
    int fountainUpgrades = 0;
    int factoryUpgrades = 0;

    void Start()
    {
        ps = GetComponent<PlayerScore>();
       
        goldFountains = ps.fountains;
        goldFactories = ps.factories;
        goldPresses = ps.presses;
        _gold.gold = 0;

    }

    void Update()
    {
        time += Time.deltaTime;

        BuyGoldProducers();
        GoldProductionUpdateText();
        UpgradeGoldProducer();

    }

    public void BuyGoldProducers()
    {
        if (!hasGoldPress)
        {
            if (_gold.gold >= priceOnGoldPress())
            {
                canBuyGoldPress = true;
            }

            if (_gold.gold < priceOnGoldPress())
            {
                canBuyGoldPress = false;
            }
        }
        else
        {
            if(_gold.gold >= Amount(priceOnGoldPress()))
            {
                canBuyGoldPress = true;

            }

            if (_gold.gold < Amount(priceOnGoldPress()))
            {
                canBuyGoldPress = false;
            }
        }
        if (!hasGoldFountain)
        {
            if (_gold.gold >= priceOnGoldFountain())
            {
                canBuyGoldFountain = true;
            }

            if (_gold.gold < priceOnGoldFountain())
            {
                canBuyGoldFountain = false;
            }
        }
        else
        {
            if(_gold.gold >= Amount(priceOnGoldFountain()))
            {
                canBuyGoldFountain = true;
            }
            else
            {
                canBuyGoldFountain = false;

            }
        }
        if (!hasGoldFactory)
        {
            if (_gold.gold >= priceOnGoldFactory())
            {
                canBuyGoldFactory = true;
            }

            if (_gold.gold < priceOnGoldFactory())
            {
                canBuyGoldFactory = false;
            }
        }
        else
        {
            if (_gold.gold >= Amount(priceOnGoldFactory()))
            {
                canBuyGoldFactory = true;
            }

            if (_gold.gold < Amount(priceOnGoldFactory()))
            {
                canBuyGoldFactory = false;
            }
        }
    }
    public void UpgradeGoldProducer()
    {
       
            if (_gold.gold >= Amount(priceOnGoldPress()))
            {
                canUpgradePress = true;
            }

            if (_gold.gold < Amount(priceOnGoldPress()))
            {
                canUpgradePress = false;
            }
     
            if (_gold.gold >= Amount(priceOnGoldFountain()))
            {
                canUpgradeFountain = true;
            }

            if (_gold.gold < Amount(priceOnGoldFountain()))
            {
                canUpgradeFountain = false;
            }
      
            if (_gold.gold >= Amount(priceOnGoldFactory()))
            {
                canUpgradeFactory = true;
            }

            if (_gold.gold < Amount(priceOnGoldFactory()))
            {
                canUpgradeFactory = false;
            }
     
    }
    public void GoldProductionUpdateText()
    {

        if (goldPresses != 0)
        {
            hasGoldPress = true;
        }

        if (goldFountains != 0)
        {
            hasGoldFountain = true;

        }

        if (goldFactories != 0)
        {
            hasGoldFactory = true;
        }

        if (time > maxTime)
        {
            if (hasGoldPress)
            {
                pressVal = pressGold * goldPresses;

                if (hasUpgradedPress)
                {
                    int temp = 0;
                    temp++;
                    var result = Upgrade((int)pressVal);
                    pressVal = pressVal + result * temp;
                    
                  
                }
                _gold.gold += (int)pressVal;

                GameObject prefabObject = Instantiate(floatingPressText);
                prefabObject.transform.SetParent(GameObject.FindGameObjectWithTag("PressValSpawner").transform, false);
            }



            //if (hasGoldFountain)
            //{
            //    fountainVal = fountainGold * goldFountains;

            //    if (hasUpgradedFountain)
            //    {
            //        var result =Upgrade();
            //        fountainVal = fountainVal + result;
            //    }
            //    _gold.gold += (int)fountainVal;
            //    GameObject prefabObject = Instantiate(floatingFountainText);
            //    prefabObject.transform.SetParent(GameObject.FindGameObjectWithTag("FountainValSpawner").transform, false);


            //}

            //if (hasGoldFactory)
            //{
            //    factoryVal = factoryGold * goldFactories;

            //    if (hasUpgradedFactory)
            //    {
            //        var result = 0.05f * factoryUpgrades;
            //        factoryVal = factoryVal + result;
            //    }
            //    _gold.gold += (int)factoryVal;

            //    GameObject prefabObject = Instantiate(floatingFactoryText);
            //    prefabObject.transform.SetParent(GameObject.FindGameObjectWithTag("FactoryValSpawner").transform, false);
            //}

            time = 0;
        }
    }
    public void OnClickAddGoldPress()
    {
        if (canBuyGoldPress)
        {      
            if (!hasGoldPress)
            {
                _gold.gold -= priceOnGoldPress();
            }
            else
            {
                _gold.gold -= Amount(priceOnGoldPress());
                priceOnGoldPr = Amount(priceOnGoldPress());
            }

            hasGoldPress = true;
            goldPresses++;

        }
    }

    public void OnClickAddGoldFountain()
    {
        if (canBuyGoldFountain)
        {
          
            if(!hasGoldFountain)
            {
                _gold.gold -= priceOnGoldFountain();
            }

            else
            {
                _gold.gold -= Amount(priceOnGoldFountain());
                priceOnGoldFou = Amount(priceOnGoldFountain());
            }

            hasGoldFountain = true;
            goldFountains++;
        }
    }

    public void OnClickAddGoldFactory()
    {
        if (canBuyGoldFactory)
        {
         
            if (!hasGoldFactory)
            {
                _gold.gold -= priceOnGoldFactory();
            }

            else
            {
                _gold.gold -= Amount(priceOnGoldFactory());
                priceOnGoldFa = Amount(priceOnGoldFactory());
            }

            hasGoldFactory = true;
            goldFactories++;
        }
    }

    public void OnClickUpgradePress()
    {
        if (canUpgradePress)
        {
            if (!hasUpgradedPress)
            {
                hasUpgradedPress = true;
            }
                _gold.gold -= Upgrade(priceOnGoldPress());
                priceOnGoldPr = Upgrade(priceOnGoldPress());
            pressUpgrades++;
        }
    }

    public void OnClickUpgradeFountain()
    {
        if (canUpgradeFountain)
        {
            if (!hasUpgradedFountain)
            {
                hasUpgradedFountain = true;
            }

            _gold.gold -= Upgrade(priceOnGoldFountain());
            priceOnGoldFou = Upgrade((priceOnGoldFountain()));
            fountainUpgrades++;
        }
            
    }

    public void OnClickUpgradeFactory()
    {
        if (canBuyGoldFactory)
        {
            if (!hasUpgradedFactory)
            {
                hasUpgradedFactory = true;
            }
                _gold.gold -= Upgrade(priceOnGoldFactory());
                priceOnGoldFa = Upgrade(priceOnGoldFactory());
            factoryUpgrades++;
        }
    }
    private int priceOnGoldPress()
    {
        return priceOnGoldPr;

    }
    private int priceOnGoldFountain()
    {
        return priceOnGoldFou;
    }

    private int priceOnGoldFactory()
    {
        return priceOnGoldFa;
    }

    private int Amount(int amount)
    { 
        var result = amount * costMultiplier;
        return Mathf.RoundToInt(result);
    }

    private int Upgrade(float upgradeamount)
    {
        var result = (upgradeamount * (costUpgradeMultiplier/100));
        return Mathf.RoundToInt(result);

    }

}
