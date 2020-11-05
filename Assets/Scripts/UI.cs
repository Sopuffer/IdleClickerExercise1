using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public TMP_Text goldtext;

    public TextMeshProUGUI goldpresstext;
    public TextMeshProUGUI goldfountaintext;
    public TextMeshProUGUI goldfactorytext;

    public TMP_Text pressValText;
    public TMP_Text fountainValText;
    public TMP_Text factoryValText;

    public GameObject gameManager;
    GoldProduction gp;
    public EmptyGraphic eg;
    // Start is called before the first frame update
    void Start()
    {
        gp = gameManager.GetComponent<GoldProduction>();

    }

    void Update()
    {
        DisplayText();
    }
    void DisplayText()
    {
        
            goldtext.text = "Gold: " + eg.gold;

            goldfountaintext.text = "Gold Fountain: " + gp.goldFountains;
            goldpresstext.text = "Gold Press: " + gp.goldPresses;
            goldfactorytext.text = "Gold Factory: " + gp.goldFactories;

        if (gp.pressVal > 0)
        {
            pressValText.text = gp.pressVal.ToString();
        }
            fountainValText.text = gp.fountainVal.ToString();
            factoryValText.text = gp.factoryVal.ToString();
        
    }
}
