using UnityEngine;
using TMPro;
public class UI : MonoBehaviour
{
    public TMP_Text goldtext;

    public TMP_Text goldpresstext;
    public TMP_Text goldfountaintext;
    public TMP_Text goldfactorytext;
    GoldProduction gp;
    public EmptyGraphic eg;
    // Start is called before the first frame update
    void Start()
    {
        gp = GetComponent<GoldProduction>();

    }

    // Update is called once per frame
    void Update()
    {
        goldtext.text = "Gold: " + eg.gold;

        goldfountaintext.text = "Gold Fountain: " + gp.goldFountains;
        goldpresstext.text = "Gold Press: " + gp.goldPresses;
        goldfactorytext.text = "Gold Factory: " + gp.goldFactories;

    }
}
