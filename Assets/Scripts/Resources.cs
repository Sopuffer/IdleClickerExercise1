using UnityEngine;

[CreateAssetMenu(menuName = "Resources")]
public class Resources : ScriptableObject
{
    //[HideInInspector]
    public int gold;
    public int assignedGoldAmount;
  
    public int Owned
    {
        get => PlayerPrefs.GetInt(name, 1);
        set => PlayerPrefs.SetInt(name, value);
    }
    public void OnClickAddGold()
    {
        Owned += amountOfGold();
    }

  private int amountOfGold()
    {
        return assignedGoldAmount;
    }
}
