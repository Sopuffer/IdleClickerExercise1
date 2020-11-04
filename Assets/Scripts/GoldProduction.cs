using UnityEngine;

public class GoldProduction : MonoBehaviour
{
    public GameObject[] buttons;
    public ButtonHighlighted[] bh;
    

    public int priceOnGoldPr;
    public int priceOnGoldFou;
    public int priceOnGoldFa;

    public int pressGold;
    public int fountainGold;
    public int factoryGold;



    float time;
    float maxTime = 0.5f;

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
                eg.gold += pressGold * goldPresses;
            }

            if (hasGoldFountain)
            {
                eg.gold += fountainGold * goldFountains;
            }

            if (hasGoldFactory)
            {
                eg.gold += factoryGold * goldFactories;
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
