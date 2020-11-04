using UnityEngine;
using UnityEngine.EventSystems;
public class EmptyGraphic : MonoBehaviour
{
    public int gold;
    
 
    public int assignedGoldAmount;
   
    public GoldProduction gp;
    
    void Update()
    {
       
        
        if(Input.GetMouseButtonDown(0) && isMouseOverUI() && !gp.buttonActive)
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
        gold += amountOfGold();
    }

  private int amountOfGold()
    {
        return assignedGoldAmount;
    }
}
