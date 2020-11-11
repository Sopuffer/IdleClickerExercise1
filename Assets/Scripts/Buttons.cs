using UnityEngine;
using UnityEngine.EventSystems;

public class Buttons : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public bool isOnButton;
  
    public void OnPointerEnter(PointerEventData eventData)
    {
        isOnButton = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    { 
        isOnButton = false;
    }

}
