using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ToolClicker : MonoBehaviour, IPointerClickHandler
{
    public GameObject player;
    public string toolID;

    private bool isSelected;

    Image backdrop;

    void Start()
    {
        backdrop = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        player.GetComponent<PlayerController>().SetTool(toolID);
        GetComponentInParent<ToolSwitcher>().SetActiveTool();
        SetSelected();
    }

    public void SetSelected()
    {
        isSelected = true;
        backdrop.color = new Color32(200, 0, 0, 128);
    }

    public void Deselect()
    {
        isSelected = false;
        backdrop.color = new Color32(0, 0, 0, 128);
    }
}
