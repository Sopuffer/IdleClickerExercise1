using UnityEngine;
using UnityEngine.EventSystems;

public class EmptyGraphic : MonoBehaviour
{
    public bool buttonActive;
    public GameObject[] buttons;
    public Buttons[] bh;
    public Resources _addGold;

    private void Awake()
    {
        buttons = GameObject.FindGameObjectsWithTag("button");
    }
    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            bh[i] = buttons[i].GetComponent<Buttons>();
        }
    }
    private void Update()
    {
        MouseOverButtons();

        if (Input.GetMouseButtonDown(0) && isMouseOverUI() && !buttonActive)
        {
            _addGold.OnClickAddGold();
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

    public bool isMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
