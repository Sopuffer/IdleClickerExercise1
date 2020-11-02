using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class EmptyGraphic : MonoBehaviour
{
    public int gold;
    public TMP_Text goldtext;
    public int GoldAmountPerClick = 5;


    // Update is called once per frame
    void Update()
    {
        goldtext.text = "Gold: " + gold;

        if(Input.GetMouseButtonDown(0) && isMouseOverUI())
        {
            OnClickAddGold();

        }
    }

    public bool isMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void OnClickAddGold()
    {
        gold += GoldAmountPerClick;
    }
}
