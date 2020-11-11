using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class UI : MonoBehaviour
{
    public TMP_Text goldtext;

    public TextMeshProUGUI goldpresstext;
    public TextMeshProUGUI goldfountaintext;
    public TextMeshProUGUI goldfactorytext;
    public Text upgradePressText;
    public Text upgradeFountainText;
    public Text upgradeFactoryText;

    public Text pressButtonText;
    public Text fountainButtonText;
    public Text factoryButtonText;


    public TMP_Text pressValText;
    public TMP_Text fountainValText;
    public TMP_Text factoryValText;

    public GameObject gameManager;
    GoldProduction gp;
    public Resources _gold;
    // Start is called before the first frame update
    void Start()
    {
        gp = gameManager.GetComponent<GoldProduction>();
    }

    void Update()
    {
        goldtext.text = "Gold: " + _gold.gold;

        goldfountaintext.text = "Gold Fountain: " + gp.goldFountains;
        goldpresstext.text = "Gold Press: " + gp.goldPresses;
        goldfactorytext.text = "Gold Factory: " + gp.goldFactories;

        pressButtonText.text = "Buy Gold Press: ";
        fountainButtonText.text = "Buy Gold Fountain: ";
        factoryButtonText.text = "Buy Gold Factory: ";

        upgradePressText.text = "Upgrade Press";
        upgradeFountainText.text = "Upgrade Fountain";
        upgradeFactoryText.text = "Upgrade Factory";

        ChangeTextColor();
        InstantiateValText();
    }
    void InstantiateValText()
    {      

        if (gp.pressVal != 0)
        {
            pressValText.text = gp.pressVal.ToString() + "+";
        }
            fountainValText.text = gp.fountainVal.ToString() + "+";
        
            factoryValText.text = gp.factoryVal.ToString() + "+";
        }
        
    void ChangeTextColor()
    {
        if (gp.canBuyGoldPress)
        {
            pressButtonText.color = Color.black;
        }
        else
        {
            pressButtonText.color = Color.red;
        }

        if (gp.canBuyGoldFountain)
        {
            fountainButtonText.color = Color.black;
        }
        else
        {
            fountainButtonText.color = Color.red;
        }

        if (gp.canBuyGoldFactory)
        {
            factoryButtonText.color = Color.black;
        }
        else
        {
            factoryButtonText.color = Color.red;
        }



        if (gp.canUpgradePress)
        {
            upgradePressText.color = Color.black;
        }
        else
        {
            upgradePressText.color = Color.red;
        }

        if (gp.canUpgradeFountain)
        {
            upgradeFountainText.color = Color.black;
        }
        else
        {
            upgradeFountainText.color = Color.red;
        }

        if (gp.canUpgradeFactory)
        {
            upgradeFactoryText.color = Color.black;
        }
        else
        {
            upgradeFactoryText.color = Color.red;
            }
        }
}
