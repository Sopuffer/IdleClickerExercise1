using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class GoldProduction : MonoBehaviour
{
    public GameObject[] buttons;
    public ButtonHighlighted[] bh;
    public GameObject floatingPressText;
    public GameObject floatingFountainText;
    public GameObject floatingFactoryText;

    public int priceOnGoldPr;
    public int priceOnGoldFou;
    public int priceOnGoldFa;

    public int pressGold;
    public int fountainGold;
    public int factoryGold;



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

    

    public EmptyGraphic eg;

    public int goldPresses = 0;
    public int goldFountains = 0;
    public int goldFactories = 0;


    private void Awake()
    {
        buttons = GameObject.FindGameObjectsWithTag("button");
    }
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {   
                bh[i] = buttons[i].GetComponent<ButtonHighlighted>();
        }
        
    }

    void Update()
    {
        time += Time.deltaTime;
        

        if (eg.gold >= priceOnGoldPress())
        {
            canBuyGoldPress = true;
        }

        if(eg.gold < priceOnGoldPress())
        {
            canBuyGoldPress = false;
        }
        
        if(eg.gold >= priceOnGoldFountain())
        {
            canBuyGoldFountain = true;
        }

        if (eg.gold < priceOnGoldFountain())
        {
            canBuyGoldFountain = false;
        }

        if (eg.gold >= priceOnGoldFactory())
        {
            canBuyGoldFactory = true;
        }

        if (eg.gold < priceOnGoldFactory())
        {
            canBuyGoldFactory = false;
        }

        MouseOverButtons();
        if( time > maxTime)
        {
            if (hasGoldPress)
            {
                pressVal = pressGold * goldPresses;
                eg.gold += (int)pressVal;

                    GameObject prefabObject = Instantiate(floatingPressText) as GameObject;
                    prefabObject.transform.SetParent(GameObject.FindGameObjectWithTag("PressValSpawner").transform, false);
                
            }

            if (hasGoldFountain)
            {
                fountainVal = fountainGold * goldFountains;
                eg.gold += (int)fountainVal;

                GameObject prefabObject = Instantiate(floatingFountainText) as GameObject;
                prefabObject.transform.SetParent(GameObject.FindGameObjectWithTag("FountainValSpawner").transform, false);


            }

            if (hasGoldFactory)
            {
                factoryVal = factoryGold * goldFactories;
                eg.gold += (int)factoryVal;

                GameObject prefabObject = Instantiate(floatingFactoryText) as GameObject;
                prefabObject.transform.SetParent(GameObject.FindGameObjectWithTag("FactoryValSpawner").transform, false);
            }

            time = 0;
        }


    }

    public void MouseOverButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (bh[i].isOnButton)
            {
                buttonActive = true;
                break;
            }
            else
            {
                buttonActive = false;
            }
            
        }
    }

    public void OnClickAddGoldPress()
    {
        if (canBuyGoldPress)
        {
            hasGoldPress = true;
            goldPresses++;
            eg.gold -= priceOnGoldPress();
        }
    }

    public void OnClickAddGoldFountain()
    {
        if (canBuyGoldFountain)
        {
            hasGoldFountain = true;
            goldFountains++;
            eg.gold -= priceOnGoldFountain();
        }
    }

    public void OnClickAddGoldFactory()
    {
        if (canBuyGoldFactory)
        {
            hasGoldFactory = true;
            goldFactories++;
            eg.gold -= priceOnGoldFactory();
        }
    }

    public void FloatingTextSpawn()
    {

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
}
