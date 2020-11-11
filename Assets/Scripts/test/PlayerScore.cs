using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public Resources _gold;
    GoldProduction gp;
    public int score;
    public int presses;
    public int fountains;
    public int factories;
    // Start is called before the first frame update
    void Start()
    {
        gp = GetComponent<GoldProduction>();
        score = PlayerPrefs.GetInt("Player Score");
        presses = PlayerPrefs.GetInt("Presses");
        fountains = PlayerPrefs.GetInt("Fountains");
        factories = PlayerPrefs.GetInt("Factories");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Player Score", (int)_gold.gold);
        PlayerPrefs.SetInt("Presses", gp.goldPresses);
        PlayerPrefs.SetInt("Fountains", gp.goldFountains);
        PlayerPrefs.SetInt("Factories", gp.goldFactories);

        if (Input.GetKey(KeyCode.D))
        {
            PlayerPrefs.DeleteAll();
        }

    }

   
}
